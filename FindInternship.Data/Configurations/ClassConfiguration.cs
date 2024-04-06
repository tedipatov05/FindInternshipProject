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
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasData(GetAllClasses());
        }

        public List<Class> GetAllClasses()
        {
            var classes = new List<Class>();

            classes.Add(new Class()
            {
                Id = "0edc45cb-b2f1-48a2-8f6b-17910e09a147",
                Speciality = "Приложен програмист",
                SchoolId = 1,
                TeacherId = "2644afb5-f916-4b3f-b451-9ff86c881de3", 
                Grade = "12 Б",

            });

            return classes;
        }
    }
}
