using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Abilities = new HashSet<StudentAbility>();
            
        }

        [Key]
        public string Id { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        [ForeignKey(nameof(Class))]
        public string? ClassId { get; set; } 

        public Class? Class { get; set; }

        [ForeignKey(nameof(CompanyInterns))]
        public string? CompanyInternsId { get; set; } 

        public CompanyInterns? CompanyInterns { get; set; } 

        public ICollection<StudentAbility> Abilities { get; set; }

       

        
    }
}
