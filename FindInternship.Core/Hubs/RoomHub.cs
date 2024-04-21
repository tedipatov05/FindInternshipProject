using FindInternship.Core.Contracts;
using FindInternship.Data.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Hubs
{
    public class RoomHub : Hub
    {
        private readonly IUserService userService;
        private readonly IRoomService roomService;
        public RoomHub(IUserService userService, IRoomService roomService)
        {
            this.userService = userService;
            this.roomService = roomService;
        }

        public async Task SendMessage(string message, string sender, string meetingId)
        {
            var senderProfilePicture = await userService.GetUserProfilePictureByUsernameAsync(sender);

            string roomId = await roomService.GetRoomIdByMeetingIdAsync(meetingId);

            await roomService.CreateMessageToRoomAsync(message, roomId, sender, senderProfilePicture);

            await Clients.All.SendAsync("ReceiveMessage",  senderProfilePicture, message, sender);
        }

        
    }
}
