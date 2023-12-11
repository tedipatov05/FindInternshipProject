using Microsoft.AspNetCore.Mvc;

namespace FindInternship.Web.Controllers
{
    public class MeetingController : Controller
    {

        public IActionResult All()
        {
            return View();
        }
    }
}
