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
        public RoomController(IRoomService roomService, ICompanyService companyService, IMeetingService meetingService)
        {
            this.roomService = roomService;
            this.companyService = companyService;
            this.meetingService = meetingService;
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
       
    }
}
