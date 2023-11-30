using FindInternship.Core.Contracts;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class SchoolService : ISchoolService
    {
        private IRepository repo;
        public SchoolService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> Create(string schooName, string city)
        {
            var school = new School()
            {
                Name = schooName,
                City = city
            };

            await repo.AddAsync(school);
            await repo.SaveChangesAsync();

            return school.Id;
        }

        public async Task<int?> GetSchoolIdIfExistsAsync(string schoolName)
        {
            var school = await repo.All<School>()
                .FirstOrDefaultAsync(s => s.Name.ToLower().Trim() == schoolName.ToLower().Trim());

            if(school == null)
            {
                return null;
            }

            return school.Id;
        }
    }
}
