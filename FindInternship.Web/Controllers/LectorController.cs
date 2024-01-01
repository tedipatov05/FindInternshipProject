using System.Drawing.Imaging;
using FindInternship.Common;
using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Lector;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{
    public class LectorController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IUserService userService;
        private readonly IImageService imageService;

        public LectorController(ICompanyService companyService, IUserService userService, IImageService imageService)
        {
            this.companyService = companyService;
            this.userService = userService;
            this.imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string userId = User.GetId();
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да добавяш лектори";
                return RedirectToAction("Index", "Home");
            }

            AddLectorViewModel model = new AddLectorViewModel();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddLectorViewModel model)
        {
            string userId = User.GetId();
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да добавяш лектори";
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            try
            {
                string companyId = await companyService.GetCompanyIdAsync(userId);

                string profilePicture = await imageService.UploadImageToLectorAsync(model.ProfilePicture, "projectImages", model.Name);

                await companyService.AddLectorToCompany(companyId, model, profilePicture);

                TempData[SuccessMessage] = "Успешно добавен лектор";
                return RedirectToAction("MyProfile", "Profile", new { userId = userId});
            }
            catch (Exception ex)
            {
                return RedirectToAction("MyProfile", "Profile", new { userId = userId });
            }
            

        }
    }
}
