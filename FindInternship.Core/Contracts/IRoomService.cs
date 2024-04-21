using FindInternship.Core.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IRoomService
    {
        public Task CreateRoomAsync(string meetingId, CreateRoomViewModel model);

        public Task<string?> GetMeetingRoomNameByIdAsync(string meetingId);

        public Task CreateMessageToRoomAsync(string message, string roomId, string senderUsername, string senderProfilePicture);

        public Task<string> GetRoomIdByMeetingIdAsync(string meetingId);

        public Task<List<RoomMessageViewModel>> GetRoomMessagesByRoomNameAsync(string roomName);

    }
}
