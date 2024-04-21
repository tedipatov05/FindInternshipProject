using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Room
{
    public class JoinRoomViewModel
    {
        public JoinRoomViewModel()
        {
            this.RoomMessages = new HashSet<RoomMessageViewModel>();
        }
        public string RoomName { get; set; } = null!;

        public string ParticipantName { get; set; } = null!;

        public ICollection<RoomMessageViewModel> RoomMessages { get; set; }
    }
}
