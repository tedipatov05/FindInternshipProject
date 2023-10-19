using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.GroupConstants;

namespace FindInternship.Data.Models
{
    public class Group
    {
        public Group()
        {
            this.Id = Guid.NewGuid().ToString();

            this.UsersGroups = new HashSet<UserGroup>();
            this.ChatMessages = new HashSet<ChatMessage>();
            this.ChatImages = new HashSet<ChatImage>();
        }
        [Key]
        public string Id { get; set; }

        [MaxLength(GroupNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<UserGroup> UsersGroups { get; set; } 

        public ICollection<ChatMessage> ChatMessages { get; set; } 

        public ICollection<ChatImage> ChatImages { get; set; } 

    }
}
