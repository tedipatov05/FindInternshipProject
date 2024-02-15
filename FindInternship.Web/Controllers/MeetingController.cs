using FindInternship.Common;
using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Meeting;
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

        public MeetingController(IMeetingService meetingService, IUserService userService, ICompanyService companyService, ITeacherService teacherService, IStudentService studentService, IClassService classService)
        {
            this.meetingService = meetingService;
            this.userService = userService;
            this.companyService = companyService;
            this.teacherService = teacherService;
            this.studentService = studentService;
            this.classService = classService;
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

                }
                else if (isCompany)
                {
                    string? companyId = await companyService.GetCompanyIdAsync(userId);
                    model.DayNow = await meetingService.GetAllCompanyMeetingsForDayAsync(days, companyId!);
                    model.DayTomorrow = await meetingService.GetAllCompanyMeetingsForDayAsync(days + 1, companyId!);
                    model.Day2 = await meetingService.GetAllCompanyMeetingsForDayAsync(days + 2, companyId!);
                    model.Day3 = await meetingService.GetAllCompanyMeetingsForDayAsync(days + 3, companyId!);
                    model.Day4 = await meetingService.GetAllCompanyMeetingsForDayAsync(days + 4, companyId!);
                    model.CompanyClasses = await classService.GetClassMeetingAsync(companyId!);

                }
                else if (isStudent)
                {
                    string?  studentId = await studentService.GetStudentId(userId);
                    string? studentTeacherId = await studentService.GetStudentTeacherIdAsync(studentId!);
                    model.ClassId = await studentService.GetStudentClassIdAsync(studentId!);
                    model.DayNow = await meetingService.GetClassMeetingsForDayAsync(days + 0, studentTeacherId!);
                    model.DayTomorrow = await meetingService.GetClassMeetingsForDayAsync(days + 1, studentTeacherId!);
                    model.Day2 = await meetingService.GetClassMeetingsForDayAsync(days + 2, studentTeacherId!);
                    model.Day3 = await meetingService.GetClassMeetingsForDayAsync(days + 3, studentTeacherId!);
                    model.Day4 = await meetingService.GetClassMeetingsForDayAsync(days + 4, studentTeacherId!);

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
        public async Task<IActionResult> Create(string classId, string title, DateTime start, DateTime end, string address)
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
                return new JsonResult(new {isExists, ClassIdNull = false });
            }

            if(classId == null)
            {
                return new JsonResult(new { ClassIdNull = true });
            }

            try
            {

                string? teacherUserId = await teacherService.GetTeacherUserIdByClassAsync(classId);
                string? companyId = await companyService.GetCompanyIdAsync(userId);
               
                List<string> receiversIds = await studentService.GetStudentCompanyIdsAsync(companyId!, classId);

                receiversIds.Add(teacherUserId!);

                FormMeetingViewModel model = new FormMeetingViewModel()
                {
                    Title = title,
                    Start = start,
                    End = end,
                    Address = address
                };

                if (start >= end)
                {
                    TempData[ErrorMessage] = "Неправилна начална дата";
                    return this.RedirectToAction("All", "Meeting");

                }

                string meetingId = await meetingService.CreateAsync(model, companyId!, classId);

                TempData[SuccessMessage] = "Успешно добавена среща";
                return new JsonResult(new { MeetingId=meetingId, ReceiversIds = receiversIds, isExists=false, ClassIdNull = false });


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

            if(meeting == null)
            {
                TempData[ErrorMessage] = "Тази среща не съществува";
                return this.RedirectToAction("All");
            }

            return View(meeting);

        }

        [HttpPost]
        [Route("Meeting/Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] string id, string title, DateTime start, DateTime end,
            string address)
        {
            string userId = User.GetId()!;
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да редактираш срещи";
                return this.RedirectToAction("All");
            }

            string? companyId = await companyService.GetCompanyIdAsync(userId);
            bool isInCompanySchedule = await companyService.IsInCompanyScheduleAsync(companyId!, id);

            if (!isInCompanySchedule)
            {
                TempData[ErrorMessage] = "Тази среща не е във вашия график";
                return this.RedirectToAction("All");
            }


            var receiversIds = await studentService.GetCompanyStudentIdsAsync(companyId!, id);
            string? teacherUserId = await teacherService.GetTeacherUserIdByMeetingIdAsync(id);

            receiversIds.Add(teacherUserId!);

            FormMeetingViewModel model = new FormMeetingViewModel()
            {
                Address = address,
                End = end,
                Start = start,
                Title = title,
            };

            await meetingService.EditMeetingAsync(id, model);


            return new JsonResult(new { MeetingId = id, Model = model, ReceiversIds = receiversIds });
        }

        [HttpGet]
        [Route("/Meeting/Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute]string id)
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

            return new JsonResult(new {ReceiversIds = receiversIds, meetingId = id });


        }


    }
}
