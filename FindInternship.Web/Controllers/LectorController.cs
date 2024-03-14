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
        private readonly ILectorService lectorService;

        public LectorController(ICompanyService companyService, IUserService userService, IImageService imageService, ILectorService lectorService)
        {
            this.companyService = companyService;
            this.userService = userService;
            this.imageService = imageService;
            this.lectorService = lectorService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string userId = User.GetId()!;
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да добавяш преподаватели";
                return RedirectToAction("Index", "Home");
            }

            AddLectorViewModel model = new AddLectorViewModel();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddLectorViewModel model)
        {
            string userId = User.GetId()!;
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма за да добавяш преподаватели";
                return RedirectToAction("Index", "Home");
            }

            if(model.ProfilePicture == null)
            {
                ModelState.AddModelError(nameof(model.ProfilePicture), "Снимката е задължителна");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            
            
            try
            {
                string? companyId = await companyService.GetCompanyIdAsync(userId);

                string profilePicture = await imageService.UploadImageAsync(model.ProfilePicture!, "projectImages", model.Name);

                await companyService.AddLectorToCompany(companyId!, model, profilePicture);

                TempData[SuccessMessage] = "Успешно добавен преподавател";
                return RedirectToAction("MyProfile", "Profile", new { userId = userId});
            }
            catch (Exception )
            {
                return RedirectToAction("MyProfile", "Profile", new { userId = userId });
            }
            
        }

        public async Task<IActionResult> Delete(string id)
        {
            string userId = User.GetId()!;
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма, за да изтриваш преподаватели";
                return RedirectToAction("MyProfile", "Profile", new { userId });
            }

            bool isLectorExists = await lectorService.IsLectorExistsAsync(id);
            if (!isLectorExists)
            {
                TempData[ErrorMessage] = "Този преподавател не съществува";
                return RedirectToAction("MyProfile", "Profile", new { userId });
            }

            string? companyId = await companyService.GetCompanyIdAsync(userId);
            bool isInCompanyLectors = await companyService.IsLectorInCompany(companyId!, id);
            if (!isInCompanyLectors)
            {
                TempData[ErrorMessage] = "Този преподавател не е в твоята фирма";
                return RedirectToAction("MyProfile", "Profile", new { userId });
            }

            try
            {
                await lectorService.DeleteAsync(id);

                TempData[SuccessMessage] = "Успешно изтрит преподавател";
                return RedirectToAction("MyProfile", "Profile", new { userId });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Неочаквана грешка възникна";
                return RedirectToAction("MyProfile", "Profile", new { userId });
            }
           



        }
        
    }
}
