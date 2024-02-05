using FindInternship.Core.Contracts;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Areas.Admin.Controllers
{
    public class AbilityController : BaseController
    {
        private readonly IAbilityService abilityService;

        public AbilityController(IAbilityService abilityService)
        {
            this.abilityService = abilityService;
        }

        public async Task<IActionResult> All()
        {
            if (!User.IsInRole("Admin"))
            {
                TempData[ErrorMessage] = "Трябва да си администратор, за да имаш достъп.";
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }

            var model = await abilityService.AllAbilitiesAsync();
            return View(model);
        }

        [HttpPost]
        [Route("/Ability/Add")]
        public async Task<IActionResult> AddAbility(string ability)
        {
            if (!User.IsInRole("Admin"))
            {
                TempData[ErrorMessage] = "Трябва да си администратор, за да имаш достъп.";
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }

            try
            {
                await abilityService.AddNewAbilityAsync(ability);

                return new JsonResult(new { ability });
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("All", new { Area = "Admin" });
            }



        }

    }
}
