using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FindInternship.Common.ModelValidationConstants.MeetingConstants;

namespace FindInternship.Data.Models
{
    public class Meeting
    {
        public Meeting()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsActive = true;
            this.Materials = new HashSet<MeetingMaterial>();
        }
        [Key]
        public string Id { get; set; } = null!;

        [MaxLength(MeetingAddressMaxLength)]
        public string? Address { get; set; } 

        [MaxLength(MeetingTitleMaxLength)]
        public string Title { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [MaxLength(MeetingDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; } = null!;

        public Company Company { get; set; } = null!;

        [ForeignKey(nameof(CompanyInterns))]
        public string CompanyInternsId { get; set; } = null!;

        public CompanyInterns CompanyInterns { get; set; } = null!;

        [ForeignKey(nameof(Lector))]
        public string LectorId { get; set; } = null!;

        public Lector Lector { get; set; } = null!;

        [ForeignKey(nameof(Room))]
        public string? RoomId { get; set; }

        public Room? Room { get; set; }

        public bool IsOnline { get; set; }

        public bool IsActive { get; set; }

        public ICollection<MeetingMaterial> Materials { get; set; }
    }
}
