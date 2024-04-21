using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Room
{
    public class RoomMessageViewModel
    {
        public string Content { get; set; } = null!;

        public string SenderProfilePicture { get; set; } = null!;

        public string SenderName { get; set; } = null!;
    }
}
