
using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Users;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService userService;
        private readonly IPrivateChatService privateChatService;
        private readonly IRequestService requestService;
        private readonly IMeetingService meetingService;
        public HomeController(IUserService userService, IPrivateChatService privateChatService, IRequestService requestService,
             IMeetingService meetingService)
        { 
            this.userService = userService;
            this.privateChatService = privateChatService;
            this.requestService = requestService;
            this.meetingService = meetingService;
            
        }

        public async Task<IActionResult> Index([FromQuery] UsersQueryModel model)
        {
            if (!User.IsInRole("Admin"))
            {
                TempData[ErrorMessage] = "Непрвилен потребител";
                return RedirectToAction("Index", "Home");
            }

            model.Users = await userService.GetFilteredUsersAsync(model, User.GetId());
            model.UsersCount = await userService.GetUsersCountAsync();
            model.AcceptedRequestsCount = await requestService.GetAcceptedRequestCountAsync();
            model.MessagesCount = await privateChatService.GetMessagesCountAsync();
            model.MeetingsCount = await meetingService.GetMeetingsCountAsync();


            return View(model);
        }
    }
}
