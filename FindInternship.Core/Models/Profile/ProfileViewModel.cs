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

        public string? ProfilePictureUrl { get; set; } 

        public string Role {  get; set; } = null!;

        public List<string> Abilities { get; set; } = new List<string>();

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string? Description { get; set; } 

        public string? Services { get; set; } 

       
    }
}
