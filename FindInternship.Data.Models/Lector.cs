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
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; }

        public Company Company { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public string ProfilePictureUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
