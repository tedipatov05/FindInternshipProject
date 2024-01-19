using Microsoft.AspNetCore.Mvc;

namespace FindInternship.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
