﻿using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Request;
using FindInternship.Core.Services;
using FindInternship.Data.Models.Enums;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using static FindInternship.Common.NotificationConstants;


namespace FindInternship.Web.Controllers
{
    public class RequestController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly ITeacherService teacherService; 
        private readonly IRequestService requestService;
        private readonly IClassService classService;
        private readonly IStudentService studentService;

		public RequestController(ICompanyService companyService, ITeacherService teacherService, IRequestService requestService, IClassService classService, IStudentService studentService)
		{
			this.companyService = companyService;
			this.teacherService = teacherService;
			this.requestService = requestService;
			this.classService = classService;
            this.studentService = studentService;
		}

		[HttpGet]
        public async Task<IActionResult> CreateView(string companyUserId)
        {
            bool isCompany = await companyService.IsCompanyAsync(companyUserId);
            if(!isCompany) 
            {
                TempData[ErrorMessage] = "Тази фирма не съществува";
                return RedirectToAction("All", "Company");
            }

            string companyName = await companyService.GetCompanyNameByIdAsync(companyUserId);

            bool isTeacher = await teacherService.IsTeacherAsync(User.GetId()!);
           
            if(!isTeacher)
            {
                TempData[ErrorMessage] = "Трябва да бъдеш учител за да узпращаш молби за практика ";
                return RedirectToAction("All", "Company");
            }

            return View("Create", companyName);
        }


        [HttpPost]
        [Route("Request/Create")]
        public async Task<IActionResult> Create(string company, string topic, string message)
        {
            string companyUserId = await companyService.GetCompanyIdByNameAsync(company);

            bool isCompany = await companyService.IsCompanyAsync(companyUserId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Тази фирма не съществува";
                return this.RedirectToAction("All", "Company");
            }

            bool isTeacher = await teacherService.IsTeacherAsync(User.GetId()!);
            if (!isTeacher)
            {
                TempData[ErrorMessage] = "Трябва да бъдеш учител за да изпращаш молби за практика ";
                return this.RedirectToAction("All", "Company");
            }
            string requestId;

            try
            {

                string classId = await teacherService.GetTeacherClassIdAsync(User.GetId()!);
                string companyId = await companyService.GetCompanyIdAsync(companyUserId);
                CreateRequestModel model = new CreateRequestModel();

                model.Message = message;
                model.Topic = topic;

                model.ClassId = classId;
                model.CompanyId = companyId;

                requestId = await requestService.Create(model);

            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("All", "Company");
            }

            TempData[SuccessMessage] = "Успешно изпратена молба за практика";
            
            return new JsonResult(new {RequestId=requestId, CompanyUserId = companyUserId});

        }

        [HttpGet]
        public async Task<IActionResult> CompanyRequests()
        {
            string userId = User.GetId()!;

            
            bool isCompany = await companyService.IsCompanyAsync(userId);

            if(!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да имаш достъп";
                return RedirectToAction("Index", "Home");
            }

            string companyId = await companyService.GetCompanyIdAsync(userId);
            var companyRequests = await requestService.GetAllCompanyRequestsByIdAsync(companyId);

            return View("All", companyRequests);

        }

        [HttpGet]
        public async Task<IActionResult> ClassRequests()
        {
            string userId = User.GetId()!;

            bool isTeacher = await teacherService.IsTeacherAsync(userId);
            if(!isTeacher)
            {
                TempData[ErrorMessage] = "Трябва да си учител за да имаш достъп";
                return RedirectToAction("Index", "Home");
            }

            string classId = await teacherService.GetTeacherClassIdAsync(userId);
            var classRequests = await requestService.GetAllClassRequestsByIdAsync(classId);

            return View("All", classRequests);

        }

        [HttpPost]
        public async Task<IActionResult> EditStatus(string newStatus, string id)
        {
            string userId = User.GetId()!;

            bool isCompany = await companyService.IsCompanyAsync(userId);

            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да променяш статуса.";
                return RedirectToAction("Index", "Home");
            }

            bool result = await requestService.EditRequestStatus(newStatus, id);

            if(newStatus == RequestStatusEnum.Accepted.ToString())
            {
                var companyId = await companyService.GetCompanyIdAsync(userId);

                var classId = await classService.GetClassIdAsync(id);

                await companyService.AddClassToCompany(classId, companyId);

                //TODO: Remove comments :)

                //var studentIds = await studentService.GetStudentCompanyIdsAsync(companyId, classId);


                //return new JsonResult(new { IsEdited = result, CompanyUserId = userId, ClassId = classId, StudentIds = studentIds });

            }


            return new JsonResult(new { IsEdited = result, CompanyUserId = userId });

        }
    }
}
