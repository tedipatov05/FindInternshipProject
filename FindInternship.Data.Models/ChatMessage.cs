using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.ChatMessageConstants;

namespace FindInternship.Data.Models
{
    public class ChatMessage
    {
        public ChatMessage()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Images = new HashSet<ChatImage>();
        }
        [Key]
        public string Id { get; set; } = null!;


        [Required]
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(Group))]
        public string GroupId { get; set; } = null!;

        public Group Group { get; set; } = null!;

        [ForeignKey(nameof(User))]
        //Sender Id
        public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        [MaxLength(ReceiverUserNameMaxLength)]
        public string ReceiverUsername { get; set; } = null!;

        public string? ReceiverImageUrl { get; set; }

        public DateTime SendedOn { get; set; }

        public ICollection<ChatImage> Images { get; set; }
    }
}
