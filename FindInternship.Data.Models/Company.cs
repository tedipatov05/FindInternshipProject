using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.CompanyConstants;

namespace FindInternship.Data.Models
{
    public class Company
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Classes = new HashSet<Class>();
            this.Requests = new List<Request>();
            this.Meetings = new HashSet<Meeting>();
        }
        [Key]
        public string Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        [MaxLength(CompanyDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(CompanyServicesMaxLength)]
        public string Services { get; set; } = null!;

        public ICollection<Class> Classes { get; set; }

        public ICollection<Request> Requests { get; set; } = null!;

        public ICollection<Meeting> Meetings { get; set; }


    }
}
