using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.PrivateChat
{
    public class LoadMoreMessagesViewModel
    {
        public string Id { get; set; } = null!;

        public string Content { get; set; } = null!;

        public string SendedOn { get; set; } = null!;

        public string CurrentUsername { get; set; } = null!;

        public string FromUsername { get; set; } = null!;

        public string FromImageUrl { get; set; } = null!;
    }
}
