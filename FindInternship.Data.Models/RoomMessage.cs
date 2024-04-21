using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FindInternship.Common.ModelValidationConstants.RoomMessageConstants;

namespace FindInternship.Data.Models
{
    public class RoomMessage
    {
        public RoomMessage()
        {
            this.Id = Guid.NewGuid().ToString();
            this.SendedOn = DateTime.Now;
        }

        [Key]
        public string Id { get; set; }

        [ForeignKey(nameof(Room))]
        public string RoomId { get; set; } = null!;

        public Room Room { get; set; } = null!;

        [MaxLength(RoomMessageMaxLength)]
        public string Content { get; set; } = null!;

        public string SenderName { get; set; } = null!;

        public string SenderProfilePicture { get; set; } = null!;

        public DateTime SendedOn { get; set; }




    }
}
