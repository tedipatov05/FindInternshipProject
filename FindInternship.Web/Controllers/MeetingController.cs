﻿using FindInternship.Common;
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
        private readonly ICompanyInternsService companyInternsService;

        public MeetingController(IMeetingService meetingService, IUserService userService, ICompanyService companyService, ITeacherService teacherService, IStudentService studentService, IClassService classService, ILectorService lectorService, IDocumentService documentService, IMaterialService materialService, ICompanyInternsService companyInternsService)
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
            this.companyInternsService = companyInternsService;
        }


        public async Task<IActionResult> All(string? groupId, int days = 0)
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
                    model.GroupId = groupId;
                    model.DayNow = await meetingService.GetCompanyInternsMeetingsForDayAsync(days, groupId!);
                    model.DayTomorrow = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 1, groupId!);
                    model.Day2 = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 2, groupId!);
                    model.Day3 = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 3, groupId!);
                    model.Day4 = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 4, groupId!);
                    model.Day5 = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 5, groupId!);
                    model.Day6 = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 6, groupId!);

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


                    model.CompanyClasses = await companyInternsService.GetClassMeetingAsync(companyId!);
                    model.CompanyLectors = await lectorService.GetAllCompanyLectorsAsync(companyId!);


                }
                else if (isStudent)
                {
                    string? studentId = await studentService.GetStudentId(userId);
                    string? studentTeacherId = await studentService.GetStudentTeacherIdAsync(studentId!);
                    model.GroupId = await studentService.GetStudentGroupIdAsync(studentId!);
                    model.DayNow = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 0, model.GroupId!);
                    model.DayTomorrow = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 1, model.GroupId!);
                    model.Day2 = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 2, model.GroupId!);
                    model.Day3 = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 3, model.GroupId!);
                    model.Day4 = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 4, model.GroupId!);
                    model.Day5 = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 5, model.GroupId!);
                    model.Day6 = await meetingService.GetCompanyInternsMeetingsForDayAsync(days + 6, model.GroupId!);

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
        public async Task<IActionResult> Create(string classId, string lectorId, string title, DateTime start, DateTime end, string? address, string description,bool isOnline, List<IFormFile> files)
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

                string? teacherUserId = await teacherService.GetTeacherUserIdByCompanyInternIdAsync(classId);
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
                    IsOnline = isOnline,
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
            meeting.Materials = await materialService.GetAllMeetingMatrialsAsync(id);


            return View(meeting);

        }

        [HttpPost]
        [Route("Meeting/Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] string id, string title, DateTime start, DateTime end,
            string? address, string companyId, string description, bool isOnline ,List<IFormFile> files)
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
                Description = description,
            };

            await meetingService.EditMeetingAsync(id, model);

            if (files.Count != 0)
            {
                await materialService.DeleteAllMeetingMaterials(id);
                foreach (var file in files)
                {
                    string url = await documentService.UploadDocumentAsync(file, "projectDocuments");
                    string materialId = await materialService.CreateAsync(url, file.FileName, id);
                }

            }

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
            if (!isMeetingExists)
            {
                TempData[ErrorMessage] = "Тази среща не съществува";
                return new JsonResult(new { isExists = false });
            }

            bool isMeetingHaveRoom = await meetingService.IsMeetingAlreadyHaveRoomAsync(id);
            if (isCompany)
            {
                string? companyId = await companyService.GetCompanyIdAsync(userId!);
                bool isInCompanySchedule = await companyService.IsInCompanyScheduleAsync(companyId!, id);
                if (!isInCompanySchedule)
                {
                    TempData[ErrorMessage] = "Тази среща не е в твоя график";
                    return new JsonResult(new { isExists = false });
                }
                
                var meeting = await meetingService.GetDetailsForMeetingAsync(id);

                return new JsonResult(new { meeting, isExists = true, isCompany, isHaveRoom = isMeetingHaveRoom, isTeacher=false });


            }
            else if (isTeacher || isStudent)
            {
                
                var meeting = await meetingService.GetDetailsForMeetingAsync(id);

                return new JsonResult(new { meeting, isExists = true, isCompany = false, isHaveRoom = isMeetingHaveRoom, isTeacher });
            }

            return new JsonResult(new { isExists = isMeetingExists});

        }


    }
}
