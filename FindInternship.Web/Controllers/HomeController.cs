using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Email;
using FindInternship.Core.Models.Profile;
using FindInternship.Core.Models.Statistics;
using FindInternship.Core.Services;
using FindInternship.Web.Extensions;
using FindInternship.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IStatisticService statisticService;
        private readonly IEmailService emailService;
        private readonly ITeacherService teacherService;
        private readonly ICompanyService companyService;

        public HomeController(IStatisticService statisticService, IEmailService emailService, ITeacherService teacherService, 
            ICompanyService companyService)
        {
            this.statisticService = statisticService;
            this.emailService = emailService;
            this.teacherService = teacherService;
            this.companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }

            if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("Teacher", "Home", new {id = ""});
            }
            
            StatisticViewModel model = new StatisticViewModel();
            model.Internships = await statisticService.GetInternshipsCountAsync();
            model.Meetings = await statisticService.GetMeetingsArrangedCountAsync();
            model.HappyUsers = await statisticService.GetHappyUsersCountAsync();

            if (User.IsInRole("Student"))
            {
                //TODO: Change redirection when student schedule is ready
                return RedirectToAction("All", "Meeting");
            }

            if (User.IsInRole("Company"))
            {
                return RedirectToAction("CompanyClasses", "Class");
            }

            return View(model);
        }

        public async Task<IActionResult> Teacher(string id)
        {
            string userId = User.GetId()!;

            bool isTeacher = await teacherService.IsTeacherAsync(string.IsNullOrEmpty(id) ? userId : id);
            
            if (!isTeacher)
            {
                TempData[ErrorMessage] = "Трябва да бъдете учител";
                return RedirectToAction("Index", "Home");
            }

            string teacherId = await teacherService.GetTeacherIdAsync(string.IsNullOrEmpty(id) ? userId : id);
            var model = await teacherService.GetTeacherStudentsAsync(teacherId);

            return View(model);
        }
        
        [HttpGet]
        public IActionResult Contact()
        {
            Message message = new Message();
            return View(message);
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Message model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await emailService.SendEmailAsync(model);

            }
            catch(Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return View(model);
            }

            TempData[SuccessMessage] = "Успешно изпратен имейл";

            return RedirectToAction("Index");
        }


        
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 400 || statusCode == 404) 
            {
                return View("Error404");
            }
            else if(statusCode == 403)
            {
                return View("Error403");
            }

            return View();
        }
    }
}