using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Student;
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
    public class StudentService : IStudentService
    {
        private IRepository repo;

        public StudentService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Create(string userId, string classId)
        {
            var student = new Student()
            {
                UserId = userId,
                ClassId = classId, 
            };
            await repo.AddAsync(student);
            await repo.SaveChangesAsync();
        }

     

        public async Task<List<string>> GetStudentAbilitiesAsync(string studentId)
        {
             var abilitites = await repo.All<StudentAbility>()
                .Where(a => a.StudentId == studentId)
                .Select(s => s.Ability.AbilityText)
                .ToListAsync();

            return abilitites;
        }

        public async Task<string> GetStudentId(string userId)
        {
            var student = await repo.All<Student>()
                .FirstOrDefaultAsync(student => student.UserId == userId);

            return student!.Id;
        }

        public async Task<string> GetStudentTeacherIdAsync(string studentId)
        {
            var student = await repo.All<Student>()
                .Include(s => s.Class)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            return student.Class.TeacherId;
                
        }

        public async Task<List<string>> GetStudentCompanyIdsAsync(string companyId, string classId)
        {
            var classModel = await repo.All<Class>()
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.CompanyId == companyId && c.Id == classId);

            var studentIds = classModel.Students.Select(s => s.UserId).ToList();


            return studentIds;

        }

        public async Task<string> GetStudentClassIdAsync(string studentId)
        {
            var student = await repo.All<Student>()
                .FirstOrDefaultAsync(s => s.Id == studentId);

            return student.ClassId;

        }

        public async Task<List<StudentViewModel>> GetTeacherStudentsAsync(string className)
        {
            var students = await repo.All<Student>()
                .Where(s => s.Class.Grade == className && s.User.IsActive == true)
                .Include(s => s.Abilities)
                .Select(s => new StudentViewModel()
                {
                    Id = s.User.Id, 
                    Name = s.User.Name, 
                    ProfilePictureUrl = s.User.ProfilePictureUrl, 
                    Abilities = s.Abilities.Select(a => a.Ability.AbilityText).ToList()
                })
                .ToListAsync();

            return students;
                
        }

        public async Task<bool> IsStudent(string userId)
        {
            var isStudent = await repo.All<Student>()
                .AnyAsync(s => s.UserId == userId && s.User.IsActive == true);

            return isStudent;
        }
    }
}
