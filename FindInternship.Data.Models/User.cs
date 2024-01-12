
using FindInternship.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using static FindInternship.Common.ModelValidationConstants.UserConstants;

namespace FindInternship.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.IsActive = true;
            this.IsApproved = true;
            this.UserGroups = new HashSet<UserGroup>();
            this.ChatMessages = new HashSet<ChatMessage>();
            
        }

        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [MaxLength(CityMaxLength)]
        public string City { get; set; } = null!;

        [MaxLength(CountryMaxLength)]
        public string Country { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public DateTime RegisteredOn { get; set; }

        [EnumDataType(typeof(Gender))]
        public string? Gender { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public bool IsActive { get; set; }

        public bool IsApproved { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }

        public virtual ICollection<ChatMessage> ChatMessages { get; set; }

    }
}