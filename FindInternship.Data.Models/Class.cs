using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.ClassConstants;

namespace FindInternship.Data.Models
{
    public class Class
    {
        public Class()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Students = new HashSet<Student>();
            this.Requests = new HashSet<Request>();
            this.Meetings = new HashSet<Meeting>();
            this.Documents = new HashSet<Document>();
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(SpecialtityMaxLength)]
        public string Speciality { get; set; } = null!;

        [ForeignKey(nameof(School))]
        public int SchoolId { get; set; }

        public School School { get; set; } = null!;

        public string Grade { get; set; } = null!;

        [ForeignKey(nameof(Teacher))]
        public string TeacherId { get; set; } = null!;

        public Teacher Teacher { get; set; } = null!;

        [AllowNull]
        [ForeignKey(nameof(Company))]
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Request> Requests { get; set; }

        public ICollection<Meeting> Meetings { get; set; }

        public ICollection<Document> Documents { get; set; }


    }
}
