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
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasData(GetSchools());
        }

        public List<School> GetSchools()
        {
            return new List<School>()
            {
                new School()
                {
                    Id = 1, 
                    Name = "ППМГ Никола Обрешков"
                }
            };
        }
    }
}
