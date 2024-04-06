using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models
{
    public class Teacher
    {
        public Teacher()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Groups = new HashSet<CompanyInterns>();
        }

        [Key]
        public string Id { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        [ForeignKey(nameof(Class))]
        public string? ClassId { get; set; } 
        public Class? Class { get; set; }

        public ICollection<CompanyInterns> Groups { get; set; }
             

    }
}
