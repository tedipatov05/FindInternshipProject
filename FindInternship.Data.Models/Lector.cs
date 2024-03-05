using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.LectorConstants;

namespace FindInternship.Data.Models
{
    public class Lector
    {
        public Lector()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsActive = true;
            this.Meetings = new HashSet<Meeting>();
        }

        [Key]
        public string Id { get; set; } = null!;

        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; } = null!;

        public Company Company { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string ProfilePictureUrl { get; set; } = null!;

        public bool IsActive { get; set; }

        public ICollection<Meeting> Meetings { get; set; }
    }
}
