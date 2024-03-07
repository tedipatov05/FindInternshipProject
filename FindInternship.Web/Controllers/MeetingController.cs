using FindInternship.Common;
using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Meeting;
using FindInternship.Core.Services;
using FindInternship.Data.Models;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingService meetingService;
        private readonly IUserService userService;
        private readonly ICompanyService companyService;
        private readonly ITeacherService teacherService;
        private readonly IStudentService studentService;
        private readonly IClassService classService;
        private readonly ILectorService lectorService;
        private readonly IDocumentService documentService;
        private readonly IMaterialService materialService;

        public MeetingController(IMeetingService meetingService, IUserService userService, ICompanyService companyService, ITeacherService teacherService, IStudentService studentService, IClassService classService, ILectorService lectorService, IDocumentService documentService, IMaterialService materialService)
        {
            this.meetingService = meetingService;
            this.userService = userService;
            this.companyService = companyService;
            this.teacherService = teacherService;
            this.studentService = studentService;
            this.classService = classService;
            this.lectorService = lectorService;
            this.documentService = documentService;
            this.materialService = materialService;
        }


        public async Task<IActionResult> All(int days = 0)
        {

            AllMeetingsViewModel model = new AllMeetingsViewModel();
            model.Days = days;
            model.Month = DateTime.Now.AddDays(days).ToString("MMMM", CultureInfo.InvariantCulture);
            string userId = User.GetId()!;
            if (string.IsNullOrEmpty(userId))
            {
                TempData[ErrorMessage] = "Неправилен потребител";
                return RedirectToAction("Login", "Account");
            }

            try
            {
                bool isTeacher = await teacherService.IsTeacherAsync(userId);
                bool isCompany = await companyService.IsCompanyAsync(userId);
                bool isStudent = await studentService.IsStudent(userId);

                if (isTeacher)
                {
                    string? teacherId = await teacherService.GetTeacherIdAsync(userId);
                    model.ClassId = await teacherService.GetTeacherClassIdAsync(userId);
                    model.DayNow = await meetingService.GetClassMeetingsForDayAsync(days, teacherId!);
                    model.DayTomorrow = await meetingService.GetClassMeetingsForDayAsync(days + 1, teacherId!);
                    model.Day2 = await meetingService.GetClassMeetingsForDayAsync(days + 2, teacherId!);
                    model.Day3 = await meetingService.GetClassMeetingsForDayAsync(days + 3, teacherId!);
                    model.Day4 = await meetingService.GetClassMeetingsForDayAsync(days + 4, teacherId!);
                    model.Day5 = await meetingService.GetClassMeetingsForDayAsync(days + 5, teacherId!);
                    model.Day6 = await meetingService.GetClassMeetingsForDayAsync(days + 6, teacherId!);

                }
                else if (isCompany)
                {
                    string? companyId = await companyService.GetCompanyIdAsync(userId);
                    model.DayNow = await meetingService.GetAllCompanyMeetingsForDayAsync(days, companyId!);
                    model.DayTomorrow = await meetingService.GetAllCompanyMeetingsForDayAsync(days + 1, companyId!);
                    model.Day2 = await meetingService.GetAllCompanyMeetingsForDayAsync(days + 2, companyId!);
                    model.Day3 = await meetingService.GetAllCompanyMeetingsForDayAsync(days + 3, companyId!);
                    model.Day4 = await meetingService.GetAllCompanyMeetingsForDayAsync(days + 4, companyId!);
                    model.Day5 = await meetingService.GetAllCompanyMeetingsForDayAsync(days + 5, companyId!);
                    model.Day6 = await meetingService.GetAllCompanyMeetingsForDayAsync(days + 6, companyId!);


                    model.CompanyClasses = await classService.GetClassMeetingAsync(companyId!);
                    model.CompanyLectors = await lectorService.GetAllCompanyLectorsAsync(companyId!);


                }
                else if (isStudent)
                {
                    string? studentId = await studentService.GetStudentId(userId);
                    string? studentTeacherId = await studentService.GetStudentTeacherIdAsync(studentId!);
                    model.ClassId = await studentService.GetStudentClassIdAsync(studentId!);
                    model.DayNow = await meetingService.GetClassMeetingsForDayAsync(days + 0, studentTeacherId!);
                    model.DayTomorrow = await meetingService.GetClassMeetingsForDayAsync(days + 1, studentTeacherId!);
                    model.Day2 = await meetingService.GetClassMeetingsForDayAsync(days + 2, studentTeacherId!);
                    model.Day3 = await meetingService.GetClassMeetingsForDayAsync(days + 3, studentTeacherId!);
                    model.Day4 = await meetingService.GetClassMeetingsForDayAsync(days + 4, studentTeacherId!);
                    model.Day5 = await meetingService.GetClassMeetingsForDayAsync(days + 5, studentTeacherId!);
                    model.Day6 = await meetingService.GetClassMeetingsForDayAsync(days + 6, studentTeacherId!);

                }
                else
                {
                    TempData[ErrorMessage] = "Неправилен потебител";
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        [Route("Meeting/Create")]
        public async Task<IActionResult> Create(string classId, string lectorId, string title, DateTime start, DateTime end, string address, string description, List<IFormFile> files)
        {
            string userId = User.GetId()!;

            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Този потребител не може да добавя срещи";
                return RedirectToAction("All", "Meeting");
            }

            bool isExists = await meetingService.IsMeetingExistsAsync(start, end, classId);
            if (isExists)
            {
                return new JsonResult(new { isExists, ClassIdNull = false });
            }

            if (classId == null)
            {
                return new JsonResult(new { ClassIdNull = true });
            }

            try
            {

                string? teacherUserId = await teacherService.GetTeacherUserIdByClassAsync(classId);
                string? companyId = await companyService.GetCompanyIdAsync(userId);

                bool isExistsInCompany = await meetingService.IsMeetingExistsInCompanyAsync(start, end, companyId!, classId);
                if (isExistsInCompany)
                {
                    return new JsonResult(new { isExists = true, ClassIdNull = false });
                }

                List<string> receiversIds = await studentService.GetStudentCompanyIdsAsync(companyId!, classId);

                receiversIds.Add(teacherUserId!);

                FormMeetingViewModel model = new FormMeetingViewModel()
                {
                    Title = title,
                    Start = start,
                    End = end,
                    Address = address,
                    LectorId = lectorId,
                    Description = description,
                };

                if (start >= end)
                {
                    TempData[ErrorMessage] = "Неправилна начална дата";
                    return this.RedirectToAction("All", "Meeting");

                }

                string meetingId = await meetingService.CreateAsync(model, companyId!, classId);


                List<string> materialsIds = new();

                foreach (var file in files)
                {
                    string url = await documentService.UploadDocumentAsync(file, "projectDocuments");
                    string id = await materialService.CreateAsync(url, file.FileName, meetingId);
                }


                TempData[SuccessMessage] = "Успешно добавена среща";
                return new JsonResult(new { MeetingId = meetingId, ReceiversIds = receiversIds, isExists = false, ClassIdNull = false });


            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("All", "Meeting");
            }


        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            string userId = User.GetId()!;
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да реедактираш срещи";
                return this.RedirectToAction("All");
            }
            string? companyId = await companyService.GetCompanyIdAsync(userId);
            bool isInCompanySchedule = await companyService.IsInCompanyScheduleAsync(companyId!, id);

            if (!isInCompanySchedule)
            {
                TempData[ErrorMessage] = "Тази среща не е във вашия график";
                return this.RedirectToAction("All");
            }

            var meeting = await meetingService.GetMeetingForEditAsync(id);

            if (meeting == null)
            {
                TempData[ErrorMessage] = "Тази среща не съществува";
                return this.RedirectToAction("All");
            }

            return View(meeting);

        }

        [HttpPost]
        [Route("Meeting/Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] string id, string title, DateTime start, DateTime end,
            string address, string companyId)
        {
            string userId = User.GetId()!;
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да редактираш срещи";
                return this.RedirectToAction("All");
            }

            //string? companyId = await companyService.GetCompanyIdAsync(userId);
            bool isInCompanySchedule = await companyService.IsInCompanyScheduleAsync(companyId!, id);

            if (!isInCompanySchedule)
            {
                TempData[ErrorMessage] = "Тази среща не е във вашия график";
                return this.RedirectToAction("All");
            }

            var receiversIds = await studentService.GetCompanyStudentIdsAsync(companyId!, id);
            string? teacherUserId = await teacherService.GetTeacherUserIdByMeetingIdAsync(id);

            receiversIds.Add(teacherUserId!);

            var meetingOld = await meetingService.GetMeetingForEditAsync(id);

            FormMeetingViewModel model = new FormMeetingViewModel()
            {
                Address = address,
                End = end,
                Start = start,
                Title = title,
            };

            bool isExistsInCompany = await meetingService.IsMeetingExistsInCompanyAsync(start, end, companyId!, "");
            if (isExistsInCompany && (DateTime.Compare(meetingOld!.Start, model.Start) != 0 || DateTime.Compare(meetingOld.End, model.End) != 0))
            {
                return new JsonResult(new { isExists = true });
            }


            await meetingService.EditMeetingAsync(id, model);

            TempData[SuccessMessage] = "Успешно променена среща";

            return new JsonResult(new { MeetingId = id, Model = model, ReceiversIds = receiversIds, IsExists = false });
        }

        [HttpGet]
        [Route("/Meeting/Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            string userId = User.GetId()!;

            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Ти трябва да бъдеш фирма, за да изтриваш срещи";
                return this.RedirectToAction("All");
            }
            string? companyId = await companyService.GetCompanyIdAsync(userId);
            bool isInCompanySchedule = await companyService.IsInCompanyScheduleAsync(companyId!, id);

            if (!isInCompanySchedule)
            {
                TempData[ErrorMessage] = "Тази среща не е в твоя график";
                return this.RedirectToAction("All");
            }

            var model = await meetingService.GetMeetingForDeleteAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] = "Тази среща не съществува";
                return this.RedirectToAction("All");
            }

            return View(model);
        }

        [HttpPost]
        [Route("/Meeting/Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id, PreDeleteMeetingViewModel model)
        {
            string userId = User.GetId()!;

            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Ти трябва да бъдеш фирма, за да изтриваш срещи";
                return this.RedirectToAction("All");
            }
            string? companyId = await companyService.GetCompanyIdAsync(userId);
            bool isInCompanySchedule = await companyService.IsInCompanyScheduleAsync(companyId!, id);

            if (!isInCompanySchedule)
            {
                TempData[ErrorMessage] = "Тази среща не е в твоя график";
                return this.RedirectToAction("All");
            }

            var receiversIds = await studentService.GetCompanyStudentIdsAsync(companyId!, id);
            string? teacherUserId = await teacherService.GetTeacherUserIdByMeetingIdAsync(id);

            receiversIds.Add(teacherUserId!);

            await meetingService.DeleteMeetingAsync(id);

            TempData[SuccessMessage] = "Успешно изтрита среща";

            return new JsonResult(new { ReceiversIds = receiversIds, meetingId = id });


        }
        [HttpGet]
        [Route("/Meeting/Details/{id}")]
        public async Task<IActionResult> Details([FromRoute] string id)
        {
            string? userId = User.GetId();
            bool isCompany = await companyService.IsCompanyAsync(userId!);
            bool isTeacher = await teacherService.IsTeacherAsync(userId!);
            bool isStudent = await studentService.IsStudent(userId!);


            bool isMeetingExists = await meetingService.IsExistsByIdAsync(id!);

            if (isCompany)
            {
                string? companyId = await companyService.GetCompanyIdAsync(userId!);
                bool isInCompanySchedule = await companyService.IsInCompanyScheduleAsync(companyId!, id);
                if (!isInCompanySchedule)
                {
                    TempData[ErrorMessage] = "Тази среща не е в твоя график";
                    return new JsonResult(new { isExists = false });
                }
                if (!isMeetingExists)
                {
                    TempData[ErrorMessage] = "Тази среща не съществува";
                    return new JsonResult(new { isExists = false });
                }

                var meeting = await meetingService.GetDetailsForMeetingAsync(id);

                return new JsonResult(new { meeting, isExists = true, isCompany });


            }
            else if (isTeacher || isStudent)
            {
                if (!isMeetingExists)
                {
                    TempData[ErrorMessage] = "Тази среща не съществува";
                    return new JsonResult(new { isExists = false });
                }

                var meeting = await meetingService.GetDetailsForMeetingAsync(id);

                return new JsonResult(new { meeting, isExists = true, isCompany = false });
            }

            return new JsonResult(new { isExists = isMeetingExists});

        }


    }
}
