using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Room
{
    public class CreateRoomViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Url { get; set; } = null!;

        public string Privacy { get; set; } = null!;
    }
}
