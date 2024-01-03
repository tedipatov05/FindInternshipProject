using FindInternship.Common;
using FindInternship.Core.Contracts;
using FindInternship.Core.Models.PrivateChat;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{

    public class PrivateChatController : Controller
    {
        private readonly IPrivateChatService privateChatService;
        private readonly ITeacherService teacherService;
        private readonly ICompanyService companyService;
        private readonly IStudentService studentService;
        private readonly IClassService classService;

        public PrivateChatController(IPrivateChatService privateChatService, ITeacherService teacherService, ICompanyService companyService, IStudentService studentService, IClassService classService)
        {
            this.privateChatService = privateChatService;
            this.teacherService = teacherService;
            this.companyService = companyService;
            this.studentService = studentService;
            this.classService = classService;
        }

        public async Task<IActionResult> UsersToChat()
        {
            string userId = User.GetId();
            bool isCompany = await companyService.IsCompanyAsync(userId);
            bool isTeacher = await teacherService.IsTeacherAsync(userId);
            bool isStudent = await studentService.IsStudent(userId);
            if (isCompany)
            {
                var users = new List<UsersToChatViewModel>();
                return View(users);

            }
            else if (isTeacher)
            {
                var users = new List<UsersToChatViewModel>();
                return View(users);
            }
            else if (isStudent)
            {
                string classId = await classService.GetClassIdAsync(userId);
                var users = await privateChatService.GetUsersToChatAsync(classId, userId);

                return View(users);

            }
            else
            {
                TempData[ErrorMessage] = "Неправилен потребител";
                return RedirectToAction("Index", "Home");
            }

        }



    }
}
