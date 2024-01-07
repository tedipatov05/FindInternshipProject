using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Data.Models;

namespace FindInternship.Core.Models.PrivateChat
{
    public class PrivateChatViewModel
    {
        public PrivateChatViewModel()
        {
            this.ChatMessages = new HashSet<ChatMessage>();
        }

        public User FromUser { get; set; } = null!;
        public User ToUser { get; set; } = null!;

        public ICollection<ChatMessage> ChatMessages { get; set; }



    }
}
