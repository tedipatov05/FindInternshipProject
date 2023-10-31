using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Email;
using FindInternship.Core.Models.Statistics;
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

        public HomeController(IStatisticService statisticService, IEmailService emailService)
        {
            this.statisticService = statisticService;
            this.emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            StatisticViewModel model = new StatisticViewModel();
            model.Internships = await statisticService.GetInternshipsCountAsync();
            model.Meetings = await statisticService.GetMeetingsArrangedCountAsync();
            model.HappyUsers = await statisticService.GetHappyUsersCountAsync();

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

            TempData[SuccessMessage] = "Successfully sended email";
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}