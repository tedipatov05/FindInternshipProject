using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Email;
using FindInternship.Core.Models.Profile;
using FindInternship.Core.Models.Statistics;
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

        public HomeController(IStatisticService statisticService, IEmailService emailService, ITeacherService teacherService)
        {
            this.statisticService = statisticService;
            this.emailService = emailService;
            this.teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {

            if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("Teacher", "Home");
            }
            
            StatisticViewModel model = new StatisticViewModel();
            model.Internships = await statisticService.GetInternshipsCountAsync();
            model.Meetings = await statisticService.GetMeetingsArrangedCountAsync();
            model.HappyUsers = await statisticService.GetHappyUsersCountAsync();

            if (User.IsInRole("Student"))
            {
                //TO DO: Change redirection when student view is ready
                return View(model);
            }

            return View(model);
        }

        public async Task<IActionResult> Teacher()
        {
            string userId = User.GetId();

            bool isTeacher = await teacherService.IsTeacherAsync(userId);

            if (!isTeacher)
            {
                TempData[ErrorMessage] = "You should be a teacher";
                return RedirectToAction("Index", "Home");
            }

            string teacherId = await teacherService.GetTeacherIdAsync(userId);
            var model = await teacherService.GetTeacherStudentsAsync(teacherId);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
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

            TempData[SuccessMessage] = "Successfully sent email";

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}