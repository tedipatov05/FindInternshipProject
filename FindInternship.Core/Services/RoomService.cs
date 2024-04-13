using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Room;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
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

            await repo.AddAsync(room);
            await repo.SaveChangesAsync();
        }
    }
}
