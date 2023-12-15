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
        }
        [Key]
        public string Id { get; set; } = null!;

        [MaxLength(MeetingAddressMaxLength)]
        public string Address { get; set; } = null!;

        [MaxLength(MeetingTitleMaxLength)]
        public string Title { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; } = null!;

        public Company Company { get; set; } = null!;

        [ForeignKey(nameof(Class))]
        public string ClassId { get; set; } = null!;

        public Class Class { get; set; } = null!;
    }
}
