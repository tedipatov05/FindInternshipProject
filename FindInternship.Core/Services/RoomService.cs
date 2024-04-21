using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Room;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository repo;
        public RoomService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task CreateMessageToRoomAsync(string message, string roomId, string senderUsername, string senderProfilePicture)
        {
            var messageModel = new RoomMessage()
            {
                Content = message,
                RoomId = roomId,
                SenderName = senderUsername,
                SenderProfilePicture = senderProfilePicture,
            };

            await repo.AddAsync(messageModel);
            await repo.SaveChangesAsync();
        }

        public async Task CreateRoomAsync(string meetingId, CreateRoomViewModel model)
        {
            Room room = new Room()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url,
                Privacy = model.Privacy,
                MeetingId = meetingId,
            };

            var meeting = await repo.All<Meeting>()
                .FirstOrDefaultAsync(x => x.Id == meetingId);

            meeting!.RoomId = room.Id;

            await repo.AddAsync(room);
            await repo.SaveChangesAsync();
        }

        public async Task<string?> GetMeetingRoomNameByIdAsync(string meetingId)
        {
            var meeting = await repo.All<Meeting>()
                .Where(m => m.Id == meetingId)
                .Include(m => m.Room)
                .FirstOrDefaultAsync();

            if(meeting == null)
            {
                return null;
            }

            return meeting!.Room!.Name;

        }

        public async Task<string> GetRoomIdByMeetingIdAsync(string meetingId)
        {
            var room = await repo.All<Room>()
                .Where(r => r.MeetingId == meetingId)
                .FirstOrDefaultAsync();

            if(room == null)
            {
                return null;
            }

            return room.Id;
        }

        public async Task<List<RoomMessageViewModel>> GetRoomMessagesByRoomNameAsync(string roomName)
        {
            var roomMessages = await repo.All<RoomMessage>()
                .Include(rm => rm.Room)
                .Where(r => r.Room.Name == roomName)
                .OrderBy(r => r.SendedOn)
                .Select(r => new RoomMessageViewModel()
                {
                    Content = r.Content, 
                    SenderName = r.SenderName, 
                    SenderProfilePicture = r.SenderProfilePicture,
                })
                .ToListAsync();

            return roomMessages;
        }
    }
}
