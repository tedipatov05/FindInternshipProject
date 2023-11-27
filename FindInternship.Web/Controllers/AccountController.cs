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
        private IAbilityService abilityService;

        public AccountController(IUserService userService, UserManager<User> userManager, SignInManager<User> singInManager, IImageService imageService, IStudentService studentService, IClassService classService, IAbilityService abilityService)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = singInManager;
            this.imageService = imageService;
            this.studentService = studentService;
            this.classService = classService;
            this.abilityService = abilityService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            model.Classes = await classService.AllClassesAsync();
            model.Abilities = await abilityService.AllAbilitiesAsync();
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
            if(DateTime.Compare(model.BirthDate, new DateTime(DateTime.Now.Year - 14, 1, 1)) > 0)
            {
                ModelState.AddModelError(nameof(model.BirthDate), "Грешна дата на раждане!");
            }
            if (!ModelState.IsValid)
            {
                model.Classes = await classService.AllClassesAsync();
                model.Abilities = await abilityService.AllAbilitiesAsync();
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

                await abilityService.AddAbilitiesToStudentAsync(model.AbilitiesIds, user.Id);

                if (model.ProfilePicture != null)
                {
                    user.ProfilePictureUrl = await imageService.UploadImage(model.ProfilePicture, "projectImages", user);
                    await userManager.UpdateAsync(user);
                }
                
                await signInManager.SignInAsync(user, isPersistent: false);

                TempData[SuccessMessage] = "Успешна регистрация";

                return RedirectToAction("Index", "Home");
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            model.Abilities = await abilityService.AllAbilitiesAsync();
            model.Classes = await classService.AllClassesAsync();
            return View(model);
        }


		[HttpGet]
		public async Task<IActionResult> RegisterTeacher()
		{
			RegisterTeacherViewModel model = new RegisterTeacherViewModel();
			//model.Classes = await classService.AllClassesAsync();
			//model.Abilities = await abilityService.AllAbilitiesAsync();
			return View(model);
		}

		//Add http post register

		[HttpGet]
		public async Task<IActionResult> RegisterCompany()
		{
			RegisterCompanyViewModel model = new RegisterCompanyViewModel();
			//model.Classes = await classService.AllClassesAsync();
			model.Technologies = await abilityService.AllAbilitiesAsync();
			return View(model);
		}

		[HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                if (user.IsActive)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        TempData[SuccessMessage] = "Успешно влизане";
                        return RedirectToAction("Index", "Home");
                       
                    }

                }
            }

            ModelState.AddModelError(nameof(model.Email), "Invalid login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
