using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Configurations
{
    public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(GetRoles());
        }

        private List<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles = new List<IdentityRole>();

            roles.Add(new IdentityRole()
            {
                Id = "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                Name = "Company",
                NormalizedName = "COMPANY"
            });
            roles.Add(new IdentityRole()
            {
                Id = "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                Name = "Student",
                NormalizedName = "STUDENT"
            });

            roles.Add(new IdentityRole()
            {
                Id = "36ae84ad-bb53-48ad-9503-bfe33221785d",
                Name = "Teacher",
                NormalizedName = "TEACHER"
            });

            return roles;
        }
    }
}
