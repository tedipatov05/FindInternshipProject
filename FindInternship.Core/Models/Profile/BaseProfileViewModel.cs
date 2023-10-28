using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Profile
{
    public class BaseProfileViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? ProfilePictureUrl { get; set; }

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Address { get; set; } = null!;

    }
}
