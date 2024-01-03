using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.PrivateChat
{
    public class UsersToChatViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; } = null!;
        public string? ProfilePicture { get; set; }

        public string? LastMessageToUser { get; set; }

        public string? LastSendOn { get; set; }


    }
}
