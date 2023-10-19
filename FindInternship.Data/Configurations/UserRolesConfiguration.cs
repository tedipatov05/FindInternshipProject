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
    public class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(GetUserRoles());
        }

        private List<IdentityUserRole<string>> GetUserRoles()
        {
            var userRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    RoleId = "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                    UserId = "cb5ee792-90f6-4e50-8af1-da2f99d9f892"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "03f3054b-c9a2-4198-a6c9-a96f3142ff53", 
                    UserId = "080a469a-b5a2-44cc-a660-eea8e6fd05a5"
                }, 
                new IdentityUserRole<string>()
                {
                    RoleId = "36ae84ad-bb53-48ad-9503-bfe33221785d",
                    UserId = "93418f37-da3b-4c78-b0ae-8f0022b09681"
                }, 
                new IdentityUserRole<string>()
                {
                    RoleId = "e2f6cb22-631b-47c7-9ac0-19f89455b2a5", 
                    UserId = "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8"
                }
            };

            return userRoles;

        }
    }
}
