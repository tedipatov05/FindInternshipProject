using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Meeting;
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

        public async Task SendMeeting(string meetingId, List<string> studentIds)
        {
            var meetingData = await meetingService.GetMeetingByIdAsync(meetingId);
            
            await Clients.Users(studentIds).SendAsync("ReceiveMeeting", meetingData, meetingId);
            
        }

        public async Task EditMeeting(string meetingId, FormMeetingViewModel model, List<string> receiversIds)
        {
            await Clients.Users(receiversIds).SendAsync("ReceiveEditedMeeting", meetingId, receiversIds);
        }

        public async Task DeleteMeeting(string meetingId, List<string> receiversIds)
        {
            await Clients.Users(receiversIds).SendAsync("ReceiveDelete", meetingId);
        }
    }
}
