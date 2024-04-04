using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Request;
using FindInternship.Core.Models.Student;
using FindInternship.Core.Models.Users;
using FindInternship.Core.Services;
using FindInternship.Data.Models;
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
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Тази фирма не съществува";
                return RedirectToAction("All", "Company");
            }

            string? companyName = await companyService.GetCompanyNameByIdAsync(companyUserId);

            bool isTeacher = await teacherService.IsTeacherAsync(User.GetId()!);

            if (!isTeacher)
            {
                TempData[ErrorMessage] = "Трябва да бъдеш учител за да изпращаш молби за практика ";
                return RedirectToAction("All", "Company");
            }

            //TODO: Check all students have company

            //bool haveCompany = await teacherService.IsTeacherClassHaveCompanyAsync(User.GetId()!);
            //if (haveCompany)
            //{
            //    TempData[ErrorMessage] = "Вашият клас вече има фирма за стаж";
            //    return RedirectToAction("All", "Company");

            //}

            return View("Create", companyName);
        }


        [HttpPost]
        [Route("Request/Create")]
        public async Task<IActionResult> Create(string company, string topic, string message)
        {
            string? companyUserId = await companyService.GetCompanyIdByNameAsync(company);

            bool isCompany = await companyService.IsCompanyAsync(companyUserId!);
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

                string? classId = await teacherService.GetTeacherClassIdAsync(User.GetId()!);
                string? companyId = await companyService.GetCompanyIdAsync(companyUserId!);
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

            return new JsonResult(new { RequestId = requestId, CompanyUserId = companyUserId });

        }

        [HttpGet]
        public async Task<IActionResult> CompanyRequests()
        {
            string userId = User.GetId()!;


            bool isCompany = await companyService.IsCompanyAsync(userId);

            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да имаш достъп";
                return RedirectToAction("Index", "Home");
            }

            string? companyId = await companyService.GetCompanyIdAsync(userId);
            var companyRequests = await requestService.GetAllCompanyRequestsByIdAsync(companyId!);

            return View("All", companyRequests);

        }

        [HttpGet]
        public async Task<IActionResult> ClassRequests()
        {
            string userId = User.GetId()!;

            bool isTeacher = await teacherService.IsTeacherAsync(userId);
            if (!isTeacher)
            {
                TempData[ErrorMessage] = "Трябва да си учител за да имаш достъп";
                return RedirectToAction("Index", "Home");
            }

            string? classId = await teacherService.GetTeacherClassIdAsync(userId);
            var classRequests = await requestService.GetAllClassRequestsByIdAsync(classId!);

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


            if (newStatus == RequestStatusEnum.Accepted.ToString())
            {
                var companyId = await companyService.GetCompanyIdAsync(userId);

                var classId = await classService.GetClassIdAsync(id);

                bool resultAccepted = await requestService.EditRequestStatus(newStatus, id);

                return new JsonResult(new { IsEdited = resultAccepted, CompanyUserId = userId});

            }

            bool result = await requestService.EditRequestStatus(newStatus, id);

            return new JsonResult(new { IsEdited = result, CompanyUserId = userId});

        }

        [HttpGet]
        public async Task<IActionResult> ChooseStudents(string requestId)
        {
            string userId = User.GetId()!;
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да променяш статуса.";
                return RedirectToAction("Index", "Home");
            }
            string classId = await classService.GetClassIdAsync(requestId)!;

            bool isAllStudentsHaveGroup = await classService.AllClassStudentsAreInGroup(classId!);
            if(!isAllStudentsHaveGroup)
            {
                TempData[ErrorMessage] = "Всички ученици от този клас за заети";
                return RedirectToAction("CompanyRequests");
            }

            bool isRequestExists = await requestService.IsRequestExistsByIdAsync(requestId);
            if (!isRequestExists)
            {
                TempData[ErrorMessage] = "Тази молба за практика не съществува";
                return RedirectToAction("Index", "Home");
            }

            var students = await studentService.GetStudentsForChooseAsync(requestId);
            ChooseStudentViewModel model = new ChooseStudentViewModel();
            model.Users = students;
            model.RequestId = requestId;

            return View(model);

        }

        [HttpPost]
        [Route("/Request/ChooseStudents")]
        public async Task<IActionResult> ChooseStudents(IList<string> studentIds, string requestId)
        {
            string userId = User.GetId()!;
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да променяш статуса.";
                return RedirectToAction("Index", "Home");
            }

            if (studentIds.Count == 0)
            {
                return new JsonResult(new { isAllExists = false, Result = false, isEditedRequest = false });
            }

            
            bool result = await studentService.AddStudentToCompanyIternsAsync(studentIds.ToList(), userId);
            bool isEditedRequest = await requestService.EditRequestStatus("Accepted", requestId);

            return new JsonResult(new { IsAllExists = true, Result = result, isEditedRequest = true});



        }

    }
}
