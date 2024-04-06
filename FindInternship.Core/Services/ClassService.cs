using FindInternship.Core.Contracts;
using FindInternship.Core.Models;
using FindInternship.Core.Models.Class;
using FindInternship.Core.Models.Student;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class ClassService : IClassService
    {
        private readonly IRepository repo;

        public ClassService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<AllClassesViewModel>> AllClassesAsync()
        {
            var classes = await repo.All<Class>()
                .Select(c => new AllClassesViewModel()
                {
                    Id = c.Id,
                    Name = c.Grade,
                    School = c.School.Name,
                })
                .ToListAsync();

            return classes;
        }

        public async Task<string?> GetClassIdByStudentUserIdAsync(string userId)
        {
            var user = await repo.All<Student>()
                .FirstOrDefaultAsync(t => t.UserId == userId);

            if (user == null)
            {
                return null;
            }

            return user!.CompanyInternsId!;
        }

        public async Task<string?> GetClassIdByTeacherUserIdAsync(string userId)
        {
            var user = await repo.All<Teacher>()
                .FirstOrDefaultAsync(t => t.UserId == userId);

            if(user == null)
            {
                return null;
            }

            return user!.ClassId!;
        }

        public async Task<List<string>> GetClassIdsByCompanyUserIdAsync(string userId)
        {
            var user = await repo.All<Company>()
                .Include(c => c.CompanyInterns)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if(user == null)
            {
                return new List<string>();
            }

            return user!.CompanyInterns.Select(c => c.Id).ToList();
        }

        public async Task<List<ClassViewModel>> GetAllCompanyClassesAsync(string companyId)
        {
            var classes = await repo.All<CompanyInterns>()
                .Include(c => c.Teacher)
                .Include(c => c.Teacher.Class)
                .Include(c => c.Students)
                .Where(c => c.CompanyId == companyId && c.IsActive)
                .Select(c => new ClassViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    School = c.Teacher.Class!.School.Name,
                    Teacher = c.Teacher!.User.Name,
                    Students = c.Students.Where(s => s.User.IsActive).Count(),
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

        public async Task<string?> GetClassIdAsync(string requestId)
        {
            var requestModel = await repo.All<Request>()
                .FirstOrDefaultAsync(r => r.Id == requestId);

            if(requestModel == null)
            {
                return null;
            }

            return requestModel!.ClassId;
        }

        public string? GetClassIdIfExistsAsync(string className, string school)
        {
            Func<string, string> concatedName = (str) => string.Join("", str.Split(' ')).ToLower();

            var c = repo.All<Class>()
                .Include(c => c.School)
                .AsEnumerable()
                .FirstOrDefault(c => concatedName(c.Grade) == concatedName(className) && concatedName(c.School.Name) == concatedName(school));

            if (c == null)
            {
                return null;
            }

            return c.Id;


        }

        public async Task UpdateAsync(string classId, string teacherId)
        {
            var cl = await repo.All<Class>()
                .FirstOrDefaultAsync(cl => cl.Id == classId);

            if(cl == null)
            {
                return;
            }

            cl!.TeacherId = teacherId;

            await repo.SaveChangesAsync();
        }

        public bool ExistsClassByNameAndSchoolAsync(string className, string schoolName)
        {
            Func<string, string> concatedName = (str) => string.Join("", str.Split(' ')).ToLower();

            string concatedClass = concatedName(className);
            string concatedSchool = concatedName(schoolName);

            var isExists = repo.All<Class>()
                .Include(c => c.School)
                .AsEnumerable()
                .Any(c => concatedName(c.Grade) == concatedClass && concatedName( c.School.Name) == concatedSchool);

            return isExists;

        }

        public async Task<string?> GetClassIdByClassNameAsync(string className, string schoolName)
        {
            var class1 = await repo.All<Class>()
                 .Include(c => c.School)
                 .FirstOrDefaultAsync(c => c.Grade == className && c.School.Name == schoolName);

            if(class1 == null)
            {
                return null;
            }

            return class1!.Id;
        }

        //public async Task<List<ClassMeetingViewModel>> GetClassMeetingAsync(string companyId)
        //{
        //    var classes = await repo.All<CompanyInterns>()
        //        .Include(c => c.School)
        //        .Where(c => c.CompanyId == companyId)
        //        .Select(c => new ClassMeetingViewModel()
        //        {
        //            Grade = c.Grade,
        //            Id = c.Id,
        //            School = c.School.Name

        //        })
        //        .ToListAsync();

        //    return classes;

        //}

        public async Task<List<ClassViewModel>> GetAllClassesAsync()
        {
            var classes = await repo.All<Class>()
                .Include(c => c.Teacher)
                .Include(c => c.Students)
                .Select(c => new ClassViewModel()
                {
                    Id = c.Id,
                    Name = c.Grade,
                    School = c.School.Name,
                    Teacher = c.Teacher!.User.Name,
                    Students = c.Students.Where(s => s.User.IsActive).Count(),
                    TeacherId = c.Teacher.UserId
                
                })
                .ToListAsync();

            return classes;
        }

        public async Task<List<StudentViewModel>> GetClassStudentsAsync(string classId)
        {
            var students = await repo.All<Student>()
                .Where(s => s.ClassId == classId)
                .Include(c => c.User)
                .Include(c => c.Abilities)
                .Where(s => s.User.IsActive)
                .Select(s => new StudentViewModel()
                {
                    Id = s.User.Id,
                    ProfilePictureUrl = s.User.ProfilePictureUrl,
                    Name = s.User.Name,
                    Abilities = s.Abilities.Select(a => a.Ability.AbilityText).ToList(),
                })
                .ToListAsync();

            return students;
        }

        public async Task<bool> IsClassExistsByIdAsync(string classId)
        {
            return await repo.All<Class>()
                .AnyAsync(c => c.Id == classId);
        }

        public async Task DeleteAsync(string classId)
        {
            var classModel = await repo.All<Class>()
                .FirstOrDefaultAsync();


            var classStudents = await repo.All<Student>()
                .Include(s => s.User)
                .Where(s => s.ClassId == classId)
                .ToListAsync();

            if (classStudents.Any())
            {
                foreach(var student in classStudents)
                {
                    student.User.IsActive = false;
                }
            }


            var classTeacher = await repo.All<Teacher>()
                .Include(s => s.User)
                .FirstOrDefaultAsync(c => c.ClassId == classId);

            classTeacher!.User.IsActive = false;

            //var documents = await repo.All<Document>()
            //    .Where(d => d.ClassId == classId)
            //    .ToListAsync();

            //repo.DeleteRange(documents);

            var requests = await repo.All<Request>()
                .Where(d => d.ClassId == classId)
                .ToListAsync();

            repo.DeleteRange(requests);

            await repo.DeleteAsync<Class>(classId);

            await repo.SaveChangesAsync();

            

        }

        //public async Task<bool> IsClassHaveAlreadyCompanyAsync(string classId)
        //{
        //    var clModel = await repo.All<Class>()
        //        .FirstOrDefaultAsync(c => c.Id == classId);

        //    if (clModel == null)
        //    {
        //        return false;
        //    }

        //    return clModel.CompanyId != null;
        //}

        public async Task<bool> AllClassStudentsAreInGroup(string classId)
        {
            var clModel = await repo.All<Class>()
                .Where(c => c.Id == classId)
                .Include(c => c.Students)
                .FirstOrDefaultAsync();

            if(clModel == null)
            {
                return false;
            }

            return clModel.Students.Any(s => s.CompanyInternsId == null);
        }
    }
}
