using Microsoft.AspNetCore.Mvc;

namespace FindInternship.Web.Controllers
{
    public class ProfileController : Controller
    {
        public async Task<IActionResult> MyProfile()
        {
            return await Task.Run(() => View());
        }
    }
}
