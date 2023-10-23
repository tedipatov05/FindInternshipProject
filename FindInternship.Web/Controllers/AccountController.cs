using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Account;
using FindInternship.Core.Services;
using FindInternship.Data.Models;
using FindInternship.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private IImageService imageService;
        private IStudentService studentService;
        private IClassService classService;

        public AccountController(IUserService userService, UserManager<User> userManager, SignInManager<User> singInManager, IImageService imageService, IStudentService studentService, IClassService classService)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = singInManager;
            this.imageService = imageService;
            this.studentService = studentService;
            this.classService = classService;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            model.Classes = await classService.AllClassesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (await userService.IsUserExistsByEmailAsync(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Потребител с този имейл вече съществува.");


            }
            if (await userService.IsUserExistsByPhoneAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Потребител с този телефонен номер вече съществува.");

            }
            if (!ModelState.IsValid)
            {
                model.Classes = await classService.AllClassesAsync();
                return View(model);
            }

            var user = new User()
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                Address = model.Address,
                BirthDate = model.BirthDate,
                Gender = model.Gender,
                Country = model.Country,
                City = model.City,
                RegisteredOn = DateTime.Now,
                PhoneNumber = model.PhoneNumber


            };


            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Student");
                await studentService.Create(user.Id, model.ClassId);

                if (model.ProfilePicture != null)
                {
                    user.ProfilePictureUrl = await imageService.UploadImage(model.ProfilePicture, "projectImages", user);
                    await userManager.UpdateAsync(user);
                }
                
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            model.Classes = await classService.AllClassesAsync();
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

         

            return RedirectToAction("Index", "Home");
        }
    }
}
