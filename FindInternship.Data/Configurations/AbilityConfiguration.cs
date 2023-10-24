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
            return new List<Ability>()
            {
                new Ability()
                {
                    Id = 1,
                    AbilityText = AbilityEnum.C.ToString()
                },
                new Ability()
                {
                    Id = 2,
                    AbilityText = AbilityEnum.CScharp.ToString()
                },
                new Ability()
                {
                    Id = 3,
                    AbilityText = AbilityEnum.ASPNET.ToString()
                },
                new Ability()
                {
                    Id = 4,
                    AbilityText = AbilityEnum.JS.ToString()
                },
                new Ability()
                {
                    Id = 5,
                    AbilityText = AbilityEnum.NodeJs.ToString()
                },
                new Ability()
                {
                    Id = 6,
                    AbilityText = AbilityEnum.Python.ToString()
                },new Ability()
                {
                    Id = 7,
                    AbilityText = AbilityEnum.EntityFramework.ToString()
                },
            };
        }
    }
}
