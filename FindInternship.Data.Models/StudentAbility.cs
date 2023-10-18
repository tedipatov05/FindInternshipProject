using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models
{
    public class StudentAbility
    {
        [ForeignKey(nameof(Ability))]
        public int AbilityId { get; set; }

        public Ability Ability { get; set; } = null!;

        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; } = null!;

        public Student Student { get; set; } = null!;
    }
}
