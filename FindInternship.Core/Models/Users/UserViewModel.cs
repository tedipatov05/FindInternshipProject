using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Users
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string RegisteredOn { get; set; } = null!;

        public string? ProfilePictureUrl { get; set; }

        public bool IsApproved { get; set; }
    }
}
