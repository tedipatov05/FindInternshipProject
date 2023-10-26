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
            this.Documents = new HashSet<Document>();
        }

        [Key]
        public string Id { get; set; }


        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; } = null!;

        [ForeignKey(nameof(Class))]
        public string ClassId { get; set; } = null!;

        public Class Class { get; set; } = null!;

        public ICollection<StudentAbility> Abilities { get; set; }

        public ICollection<Document> Documents { get; set; }

        
    }
}
