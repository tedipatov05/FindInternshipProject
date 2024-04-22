using Microsoft.AspNetCore.Mvc;

namespace FindInternship.Web.Controllers
{
    public class BlogController : Controller
    {
        

        public async Task<IActionResult> BlogHome()
        {
            return View();
        }
    }
}
