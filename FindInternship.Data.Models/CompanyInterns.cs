using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.CompanyInternsConstants;

namespace FindInternship.Data.Models
{
    public class CompanyInterns
    {
        public CompanyInterns()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsActive = true;
            this.Students = new HashSet<Student>();
            this.Meetings = new HashSet<Meeting>();
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; } = null!;

        public Company Company { get; set; } = null!;

        [ForeignKey(nameof(Teacher))]
        public string TeacherId { get; set; } = null!;

        public Teacher Teacher { get; set; } = null!;

        public bool IsActive { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Meeting> Meetings { get; set; }


    }
}
