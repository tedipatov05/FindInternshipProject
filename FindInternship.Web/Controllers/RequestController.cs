using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Request;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using static FindInternship.Common.NotificationConstants;


namespace FindInternship.Web.Controllers
{
    public class RequestController : Controller
    {
        private ICompanyService companyService;
        private ITeacherService teacherService;
        private IRequestService requestService;

        public RequestController(ICompanyService companyService, ITeacherService teacherService, IRequestService requestService)
        {
            this.companyService = companyService;
            this.teacherService = teacherService;
            this.requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(string companyUserId)
        {
            bool isCompany = await companyService.IsCompanyAsync(companyUserId);
            if(!isCompany) 
            {
                TempData[ErrorMessage] = "Тази фирма не съществува";
                return RedirectToAction("All", "Company");
            }

            bool isTeacher = await teacherService.IsTeacherAsync(User.GetId());
            if(!isTeacher)
            {
                TempData[ErrorMessage] = "Трябва да бъдеш учител за да узпращаш молби за практика ";
                return RedirectToAction("All", "Company");
            }

            
            CreateRequestModel model = new CreateRequestModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string companyUserId, CreateRequestModel model)
        {
            
            bool isCompany = await companyService.IsCompanyAsync(companyUserId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Тази фирма не съществува";
                return RedirectToAction("All", "Company");
            }

            bool isTeacher = await teacherService.IsTeacherAsync(User.GetId());
            if (!isTeacher)
            {
                TempData[ErrorMessage] = "Трябва да бъдеш учител за да узпращаш молби за практика ";
                return RedirectToAction("All", "Company");
            }

            if(!ModelState.IsValid) 
            {
                return View(model);
            }

            try
            {
                string classId = await teacherService.GetTeacherClassIdAsync(User.GetId());
                string companyId = await companyService.GetCompanyIdAsync(companyUserId);

                model.ClassId = classId;
                model.CompanyId = companyId;

                await requestService.Create(model);

            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("All", "Company");
            }


            TempData[SuccessMessage] = "Успешно изпратена молба за практика";
            return RedirectToAction("All", "Company");
        }
    }
}
