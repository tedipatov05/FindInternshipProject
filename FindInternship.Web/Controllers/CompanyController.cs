using Microsoft.AspNetCore.Mvc;

namespace FindInternship.Web.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
