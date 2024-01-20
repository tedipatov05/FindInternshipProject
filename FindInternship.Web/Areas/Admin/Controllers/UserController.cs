using FindInternship.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

using static FindInternship.Common.NotificationConstants;



namespace FindInternship.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> AcceptRequest(string id)
        {
            bool isExists = await userService.IsExistsByIdAsync(id);
            if (!isExists)
            {
                TempData[ErrorMessage] = "Този потребител не съществува.";
                return RedirectToAction("Index", "Home", new {Area="Admin"});
            }

            if (!User.IsInRole("Admin"))
            {
                TempData[ErrorMessage] = "Трябва да си администратор, за да имаш достъп.";
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }

            await userService.ChangeUserIsApprovedAsync(id);


            return RedirectToAction("Index", "Home", new { Area = "Admin" });
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            bool isExists = await userService.IsExistsByIdAsync(id);
            if (!isExists)
            {
                TempData[ErrorMessage] = "Този потребител не съществува.";
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }

            if (!User.IsInRole("Admin"))
            {
                TempData[ErrorMessage] = "Трябва да си администратор, за да имаш достъп.";
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }

            await userService.DeleteUserAsync(id);

            return RedirectToAction("Index", "Home", new { Area = "Admin" });
        }
    }
}
