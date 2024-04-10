using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.RoomConstants;

namespace FindInternship.Data.Models
{
    public class Room
    {
        public Room()
        {
            this.Participants = new HashSet<RoomParticipant>();
            this.IsActive = true;
        }

        [Key]
        public string Id { get; set; } = null!;

        [MaxLength(RoomNameMaxLength)]
        public string Name { get; set; } = null!;

        public string Url { get; set; } = null!;

        public string Privacy { get; set; } = null!;

        [ForeignKey(nameof(Meeting))]
        public string MeetingId { get; set; } = null!;

        public Meeting Meeting { get; set; } = null!;

        public bool IsActive { get; set; }

        public ICollection<RoomParticipant> Participants { get; set; }
    }
}
