using FindInternship.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FindInternship.Web.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileService profileService;
        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        public async Task<IActionResult> MyProfile(string userId, string role)
        {
            var model = await profileService.GetProfileAsync(userId, role);
            return View(model);
        }

        public IActionResult Student()
        {
            return View();
        }
    }
}
