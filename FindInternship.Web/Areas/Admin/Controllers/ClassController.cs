using FindInternship.Core.Contracts;
using FindInternship.Data.Models;
using Microsoft.AspNetCore.Mvc;


using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Areas.Admin.Controllers
{
    public class ClassController : BaseController
    {
        private readonly IClassService classService;

        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.IsInRole("Admin"))
            {
                TempData[ErrorMessage] = "Неправилен потребител";
                return RedirectToAction("Index", "Home");
            }

            var classes = await classService.GetAllClassesAsync();
            return View(classes);
        }

        public async Task<IActionResult> ClassStudents(string classId)
        {
            if (!User.IsInRole("Admin"))
            {
                TempData[ErrorMessage] = "Неправилен потребител";
                return RedirectToAction("Index", "Home");
            }
            bool isClassExists = await classService.IsClassExistsByIdAsync(classId);
            if(!isClassExists)
            {
                TempData[ErrorMessage] = "Този клас не съществува";
                return RedirectToAction("Index");
            }

            var students = await classService.GetClassStudentsAsync(classId);

            return View(students);
        }

    }
}
