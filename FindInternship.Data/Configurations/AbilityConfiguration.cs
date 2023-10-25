using FindInternship.Common.Extensions;
using FindInternship.Data.Models;
using FindInternship.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FindInternship.Data.Configurations
{
    public class AbilityConfiguration : IEntityTypeConfiguration<Ability>
    {
        public void Configure(EntityTypeBuilder<Ability> builder)
        {
            builder.HasData(GetAbilities());
        }

        private List<Ability> GetAbilities()
        {
            List<Ability> list = new List<Ability>();
            int id = 1;
            foreach(AbilityEnum abilityEnum in Enum.GetValues(typeof(AbilityEnum))) 
            {
                list.Add(new Ability()
                {
                    Id = id,
                    AbilityText = abilityEnum.GetAbilityName()
                });

                id++;
            }

            return list;

            
        }
    }
}
