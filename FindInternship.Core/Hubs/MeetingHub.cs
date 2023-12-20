using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Contracts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Org.BouncyCastle.Operators;

namespace FindInternship.Core.Hubs
{
    public class MeetingHub : Hub
    {

        private readonly IGroupService groupService;
        private readonly IMeetingService meetingService;

        public MeetingHub(IGroupService groupService, IMeetingService meetingService)
        {
            this.groupService = groupService;
            this.meetingService = meetingService;
        }

        //public async Task JoinGroup(string groupName, string userId)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        //    await groupService.AddToGroup(groupName, userId);

        //}

        public async Task SendMeeting(string meetingId, List<string> studentIds)
        {
            var meetingData = await meetingService.GetMeetingByIdAsync(meetingId);
            await Clients.Users(studentIds).SendAsync("ReceiveMeeting", meetingData);
        }
    }
}
