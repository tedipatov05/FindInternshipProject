using Microsoft.AspNetCore.Mvc;

namespace FindInternship.Web.Areas.Admin.Controllers
{
    public class AbilityController : BaseController
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
