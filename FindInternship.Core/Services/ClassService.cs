using FindInternship.Core.Contracts;
using FindInternship.Core.Models;
using FindInternship.Core.Models.Class;
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

        public async Task<string> GetClassIdByStudentUserIdAsync(string userId)
        {
            var user = await repo.All<Student>()
                .FirstOrDefaultAsync(t => t.UserId == userId);

            return user!.ClassId;
        }

        public async Task<string> GetClassIdByTeacherUserIdAsync(string userId)
        {
            var user = await repo.All<Teacher>()
                .FirstOrDefaultAsync(t => t.UserId == userId);

            return user!.ClassId;
        }

        public async Task<List<string>> GetClassIdsByCompanyUserIdAsync(string userId)
        {
            var user = await repo.All<Company>()
                .Include(c => c.Classes)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return user!.Classes.Select(c => c.Id).ToList();
        }

        public async Task<List<ClassViewModel>> GetAllCompanyClassesAsync(string companyId)
		{
            var classes = await repo.All<Class>()
                .Include(c => c.Teacher)
                .Where(c => c.CompanyId == companyId)
                .Select(c => new ClassViewModel()
                {
                    Id = c.Id,
                    Name = c.Grade,
                    School = c.School.Name,
                    Teacher = c.Teacher!.User.Name,
                    Students = c.Students.Count,
                    TeacherId = c.Teacher.UserId
                    
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

            return requestModel!.ClassId;
        }

        public string? GetClassIdIfExistsAsync(string className, string school)
        {
            Func<string, string> concatedName = (str) => string.Join("", str).ToLower();

            var c = repo.All<Class>()
                .Include(c => c.School)
                .AsEnumerable()
                .FirstOrDefault(c => concatedName(c.Grade) == concatedName(className) && concatedName( c.School.Name) == concatedName(school));

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

            cl!.TeacherId = teacherId;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsClassByNameAndSchoolAsync(string className, string schoolName)
        {
            var isExists = await repo.All<Class>()
                .Include(c => c.School)
                .AnyAsync(c => c.Grade.ToUpper() == className.ToUpper() && c.School.Name.ToUpper() == schoolName.ToUpper());

            return isExists;
            
        }

        public async Task<string> GetClassIdByClassNameAsync(string className, string schoolName)
        {
            var class1 = await repo.All<Class>()
                 .Include(c => c.School)
                 .FirstOrDefaultAsync(c => c.Grade == className && c.School.Name == schoolName);

            return class1!.Id;
        }

        public async Task<List<ClassMeetingViewModel>> GetClassMeetingAsync(string companyId)
        {
            var classes = await repo.All<Class>()
                .Include(c => c.School)
                .Where(c => c.CompanyId == companyId)
                .Select(c => new ClassMeetingViewModel()
                {
                    Grade = c.Grade, 
                    Id = c.Id, 
                    School = c.School.Name

                })
                .ToListAsync();

            return classes;

        }
    }
}
