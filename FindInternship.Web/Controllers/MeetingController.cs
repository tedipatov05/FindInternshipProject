using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Meeting;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingService meetingService;
        private readonly IUserService userService;
        private readonly ICompanyService companyService;
        private readonly ITeacherService teacherService;

        public MeetingController(IMeetingService meetingService, IUserService userService, ICompanyService companyService, ITeacherService teacherService)
        {
            this.meetingService = meetingService;
            this.userService = userService;
            this.companyService = companyService;
            this.teacherService = teacherService;
        }


        public async Task<IActionResult> All()
        {

            AllMeetingsViewModel model = new AllMeetingsViewModel();
            string userId = User.GetId();
            try
            {
                bool isTeacher = await teacherService.IsTeacherAsync(userId);
                bool isCompany = await companyService.IsCompanyAsync(userId);

                if (isTeacher)
                {
                    string teacherId = await teacherService.GetTeacherIdAsync(userId);
                    model.DayNow = await meetingService.GetClassMeetingsForDay(0, teacherId);
                    model.DayTomorrow = await meetingService.GetClassMeetingsForDay(1, teacherId);
                    model.Day2 = await meetingService.GetClassMeetingsForDay(2, teacherId);
                    model.Day3 = await meetingService.GetClassMeetingsForDay(3, teacherId);
                    model.Day4 = await meetingService.GetClassMeetingsForDay(4, teacherId);

                }
                else if (isCompany)
                {
                    string companyId = await companyService.GetCompanyIdAsync(userId);
                    model.DayNow = await meetingService.GetAllCompanyMeetingsForDay(0, companyId);
                    model.DayTomorrow = await meetingService.GetAllCompanyMeetingsForDay(1, companyId);
                    model.Day2 = await meetingService.GetAllCompanyMeetingsForDay(2, companyId);
                    model.Day3 = await meetingService.GetAllCompanyMeetingsForDay(3, companyId);
                    model.Day4 = await meetingService.GetAllCompanyMeetingsForDay(4, companyId);
                    model.CompanyClasses = await companyService.GetAllCompanyClassesAsync(companyId);

                }
                else
                {
                    TempData[ErrorMessage] = "Invalid user";
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("Index", "Home");
            }





            return View(model);
        }
    }
}
