using FindInternship.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models
{
    public class Ability
    {
        public Ability()
        {
            this.Students = new HashSet<StudentAbility>();
            this.Companies = new HashSet<CompanyAbility>();
        }

        [Key]
        public int Id { get; set; }

        [EnumDataType(typeof(AbilityEnum))]
        public string AbilityText { get; set; } = null!;

        public ICollection<StudentAbility> Students { get; set; }

        public ICollection<CompanyAbility> Companies { get; set; }
    }
}
