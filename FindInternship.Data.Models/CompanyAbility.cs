using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models
{
    public class CompanyAbility
    {
        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; } = null!;

        public Company Company { get; set; } = null!;

        [ForeignKey(nameof(Ability))]
        public int AbilityId { get; set; }

        public Ability Ability { get; set; } = null!;
    }
}
