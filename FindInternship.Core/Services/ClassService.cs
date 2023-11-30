using FindInternship.Core.Contracts;
using FindInternship.Core.Models;
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
    public class ClassService : IClassService
    {
        private IRepository repo;

        public ClassService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<ClassViewModel>> AllClassesAsync()
        {
            var classes = await repo.All<Class>()
                .Select(c => new ClassViewModel()
                {
                    Id = c.Id,
                    Name = c.Grade, 
                    School = c.School.Name,
                })
                .ToListAsync();

            return classes;
        }

        public async Task<string> CreateAsync(string className, string specialtiy, int schoolId)
        {
            var c = new Class()
            {
                Grade = className,
                Speciality = specialtiy,
                SchoolId = schoolId
            };


            await repo.AddAsync(c);
            await repo.SaveChangesAsync();

            return c.Id;
        }

        public async Task<string> GetClassIdAsync(string requestId)
        {
            var requestModel = await repo.All<Request>()
                .FirstOrDefaultAsync(r => r.Id == requestId);

            return requestModel.ClassId;
        }

        public async Task<string?> GetClassIdIfExistsAsync(string className)
        {
            var c = await repo.All<Class>()
                .FirstOrDefaultAsync(c => c.Grade.ToLower().Trim() == className.ToLower().Trim());

            if(c == null)
            {
                return null;
            }

            return c.Id;


        }

        public async Task UpdateAsync(string classId, string teacherId)
        {
            var cl = await repo.All<Class>()
                .FirstOrDefaultAsync(cl => cl.Id == classId);

            cl.TeacherId = teacherId;

            await repo.SaveChangesAsync();
        }
    }
}
