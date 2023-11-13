using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Profile;
using FindInternship.Web.Extensions;
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
        private ICompanyService companyService;
        public ProfileController(IProfileService profileService, IUserService userService, IStudentService studentService, ITeacherService teacherService, ICompanyService companyService)
        { 
            this.profileService = profileService;
            this.userService = userService;
            this.studentService = studentService;
            this.teacherService = teacherService;
            this.companyService = companyService;
        }

        public async Task<IActionResult> MyProfile(string userId)
        {
            bool isExists = await userService.IsExistsByIdAsync(userId);
            if(!isExists)
            {
                TempData[ErrorMessage] = "This user does not exists";
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
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (isCompany)
            {
                string companyId = await companyService.GetCompanyIdAsync(userId);
                var companyModel = await profileService.GetCompanyProfileAsync(companyId);

                return View("Company",  companyModel);
            }
             

            TempData[InformationMessage] = "This user is neither Teacher nor Student";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            bool isExists = await userService.IsExistsByIdAsync(userId);
            if (!isExists)
            {
                TempData[ErrorMessage] = "This user does not exists";
                return RedirectToAction("Index", "Home");
            }
            if (userId != User.GetId())
            {
                TempData[ErrorMessage] = "Invalid User";
                return RedirectToAction("Index", "Home");
            }

            var user = await profileService.GetUserForEditAsync(userId);

            return View(user);

            
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, EditProfileModel model)
        {

            bool isExists = await userService.IsExistsByIdAsync(userId);
            if (!isExists)
            {
                TempData[ErrorMessage] = "This user does not exists";
                return RedirectToAction("Index", "Home");
            }
            if(userId != User.GetId())
            {
                TempData[ErrorMessage] = "Invalid User";
                return RedirectToAction("Index", "Home");
            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await profileService.EditProfileAsync(userId, model);
                TempData[SuccessMessage] = "Successfully edited profile";

                return RedirectToAction("MyProfile", "Profile", new { userId });
            }
            catch(Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

        }

    }
}
