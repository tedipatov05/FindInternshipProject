using FindInternship.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileService profileService;
        private IUserService userService;
        private IStudentService studentService;
        private ITeacherService teacherService;
        public ProfileController(IProfileService profileService, IUserService userService, IStudentService studentService, ITeacherService teacherService)
        { 
            this.profileService = profileService;
            this.userService = userService;
            this.studentService = studentService;
            this.teacherService = teacherService;
        }

        public async Task<IActionResult> MyProfile(string userId, string role)
        {
            bool isExists = await userService.IsExistsByIdAsync(userId);
            if(!isExists)
            {
                TempData[ErrorMessage] = "Този потребител не съществува";
                return RedirectToAction("Index", "Home");
            }

            bool isStudent = await studentService.IsStudent(userId);
            if(isStudent)
            {
                string studentId = await studentService.GetStudentId(userId);
                var studentModel = await profileService.GetStudentProfileAsync(studentId);

                return View("Student", studentModel);

            }

            bool isTeacher = await teacherService.IsTeacherAsync(userId);
            if(isTeacher)
            {
                var teacherId = await teacherService.GetTeacherIdAsync(userId);
                var teacherModel = await profileService.GetTeacherProfileAsync(teacherId);

                return View("Teacher", teacherModel);
            }


            return RedirectToAction("Index", "Home");
        }

       
    }
}
