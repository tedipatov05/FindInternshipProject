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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(GetCompanies());
        }

        private List<Company> GetCompanies()
        {
            var companies = new List<Company>();

            companies.Add(new Company()
            {
                Id = "e309dc7e-dad7-42cc-b83b-febb316cc49e",
                Description = "Това е нова компания, която се занимава с изработката и поддържането на уеб приложения разработени за клиенти.",
                Services = "Изработка на уеб приложение, поддържане на сървъри", 
                UserId = "cb5ee792-90f6-4e50-8af1-da2f99d9f892", 

            }) ;

            return companies;
        }
    }
}
