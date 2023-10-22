using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Statistics;
using FindInternship.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FindInternship.Web.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IStatisticService statisticService;

        public HomeController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}