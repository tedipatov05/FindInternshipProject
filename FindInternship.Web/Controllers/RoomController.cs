using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Room;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly ICompanyService companyService;
        private readonly IMeetingService meetingService;
        private readonly ITeacherService teacherService;
        private readonly IUserService userService;

        public RoomController(IRoomService roomService, ICompanyService companyService, IMeetingService meetingService, ITeacherService teacherService, IUserService userService)
        {
            this.roomService = roomService;
            this.companyService = companyService;
            this.meetingService = meetingService;
            this.teacherService = teacherService;
            this.userService = userService;
        }

        [HttpPost]
        [Route("/Room/Create/{meetingId?}")]
        public async Task<IActionResult> Create(string meetingId, string roomId, string roomName, string roomUrl, string privacy)
        {
            string userId = User.GetId()!;
            bool isCompany = await companyService.IsCompanyAsync(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си учител за да създаваш срещи";
                return new JsonResult(new { Success = false });
            }

            bool isMeetingExists = await meetingService.IsExistsByIdAsync(meetingId);
            if (!isMeetingExists)
            {
                TempData[ErrorMessage] = "Тази среща не съществува";
                return new JsonResult(new { Success = false });
            }

            string? companyId = await companyService.GetCompanyIdAsync(userId!);
            bool isInCompanySchedule = await companyService.IsInCompanyScheduleAsync(companyId!, meetingId);
            if (!isInCompanySchedule)
            {
                TempData[ErrorMessage] = "Тази среща не е във вашият график";
                return new JsonResult(new { Success = false });
            }

            bool isMeetingHaveRoom = await meetingService.IsMeetingAlreadyHaveRoomAsync(meetingId);
            if (isMeetingHaveRoom)
            {
                TempData[ErrorMessage] = "Тази среща вече си има стая";
                return new JsonResult(new { Success = false });
            }

            CreateRoomViewModel model = new CreateRoomViewModel()
            {
                Id = roomId,
                Name = roomName,
                Url = roomUrl,
                Privacy = privacy
            };

            await roomService.CreateRoomAsync(meetingId, model);


            return new JsonResult(new { Success = true, result = model, meetingId, });
        }

        [HttpGet]
        public async Task<IActionResult> JoinRoom(string meetingId)
        {
            var userId = User.GetId();
            bool isTeacher = await teacherService.IsTeacherAsync(userId!);
            if (isTeacher)
            {
                TempData[ErrorMessage] = "Учителя не може да присъства на практиката";
                return RedirectToAction("All", "Meeting");
            }

            bool isMeetingExists = await meetingService.IsExistsByIdAsync(meetingId);
            if (!isMeetingExists)
            {
                TempData[ErrorMessage] = "Тази среща не съществува";
                return RedirectToAction("All", "Meeting");
            }

            bool isMeetingHaveRoom = await meetingService.IsMeetingAlreadyHaveRoomAsync(meetingId);
            if (!isMeetingHaveRoom)
            {
                TempData[ErrorMessage] = "Тази среща няма стая";
                return RedirectToAction("All", "Meeting");
            }

            var roomName = await roomService.GetMeetingRoomNameByIdAsync(meetingId);
            var userName = User.GetUsername();

            var model = new JoinRoomViewModel()
            {
                RoomName = roomName!,
                ParticipantName = userName!,
            };



            return View(model);
            
        }

        [HttpGet]
        [Route("/Room/Participants/{usernames}")]
        public async Task<IActionResult> Participants([FromRoute]IList<string> usernames)
        {
            //foreach(var username in usernames)
            //{
            //    bool isExists = await userService.IsExistsByUsernameAsync(username);
            //    if (!isExists)
            //    {
            //        return new JsonResult(new { IsExists = false });
            //    }
            //}
            
            var result = await userService.GetParticipantsProfilePictureAsync(usernames[0].Split(',').ToList());

            return new JsonResult(new { result, IsExists = true });
        }


       
    }
}
