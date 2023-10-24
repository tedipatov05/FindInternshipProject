using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Profile
{
    public class ProfileViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int MeetingsCount { get; set; }

        public string Country { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string BirthDate { get; set; } = null!;

        public string? Services { get; set; }

        public bool IsCompany { get; set; }

        
    }
}
