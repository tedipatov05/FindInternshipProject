using FindInternship.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Configurations
{
    internal class CompanyTechnologiesConfiguration : IEntityTypeConfiguration<CompanyAbility>
    {
        public void Configure(EntityTypeBuilder<CompanyAbility> builder)
        {
            builder.HasData(GetTechnologies());
        }
        private List<CompanyAbility> GetTechnologies()
        {
            return new List<CompanyAbility>()
            {
                new CompanyAbility()
                {
                    CompanyId = "e309dc7e-dad7-42cc-b83b-febb316cc49e",
                    AbilityId = 2
                },
                new CompanyAbility()
                {
                    CompanyId = "e309dc7e-dad7-42cc-b83b-febb316cc49e",
                    AbilityId = 3
                },
                new CompanyAbility()
                {
                    CompanyId = "e309dc7e-dad7-42cc-b83b-febb316cc49e",
                    AbilityId = 4
                },
            };
        }
    }
}
