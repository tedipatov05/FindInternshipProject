using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Student;
using FindInternship.Core.Models.Users;
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

        public async Task<string?> GetStudentId(string userId)
        {
            var student = await repo.All<Student>()
                .Include(s => s.User)
                .FirstOrDefaultAsync(student => student.UserId == userId && student.User.IsActive);

            return student == null ? null : student.Id;
        }

        public async Task<string?> GetStudentTeacherIdAsync(string studentId)
        {
            var student = await repo.All<Student>()
                .Include(s => s.Class)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            return student == null ? null : student.Class!.TeacherId!;
                
        }

        public async Task<List<string>> GetStudentCompanyIdsAsync(string companyId, string companyInterns)
        {

            var companyInternStudents = await repo.All<CompanyInterns>()
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == companyInterns);

            if(companyInternStudents == null)
            {
                return new List<string>();
            }

            var studentIds = companyInternStudents!.Students.Select(s => s.UserId).ToList();


            return studentIds;

        }

        public async Task<List<string>> GetCompanyStudentIdsAsync(string companyId, string meetingId)
        {
            var cl = await repo.All<CompanyInterns>()
                .Include(c => c.Students)
                .Include(c => c.Meetings)
                .Where(c => c.CompanyId == companyId && c.Meetings.Any(m => m.Id == meetingId))
                .FirstOrDefaultAsync();

            return cl == null ? new List<string>() : cl!.Students.Select(s => s.UserId).ToList();
        }

        public async Task<string?> GetStudentClassIdAsync(string studentId)
        {
            var student = await repo.All<Student>()
                .FirstOrDefaultAsync(s => s.Id == studentId);

            return student == null ? null : student.ClassId;

        }

        public async Task<List<StudentViewModel>> GetTeacherStudentsAsync(string id)
        {
            var students = await repo.All<Student>()
                .Where(s => s.Class!.Id == id && s.User.IsActive == true)
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

        public async Task<List<UserViewModel>> GetFilteredStudentsAsync(string classId)
        {
            var students = await repo.All<Student>()
                .Where(s => s.ClassId == classId)
                .Include(s => s.User)
                .Select(s => new UserViewModel()
                {
                    Id = s.Id, 
                    Name = s.User.Name, 
                    Email = s.User.Email,
                    RegisteredOn = s.User.RegisteredOn.ToString("dddd, dd MMMM yyyy"),
                    ProfilePictureUrl = s.User.ProfilePictureUrl,
                    IsApproved = s.CompanyInternsId != null ? true : false 

                })
                .ToListAsync();

            return students;
        }

        public async Task<List<UserViewModel>> GetStudentsForChooseAsync(string requestId)
        {
            var classId = await repo.All<Request>()
                .Where(r => r.Id == requestId)
                .Select(r => r.ClassId)
                .FirstOrDefaultAsync();

            var students = await repo.All<Student>()
                .Where(s => s.ClassId == classId && s.CompanyInternsId == null)
                .Include(s => s.User)
                .Select(s => new UserViewModel()
                {
                    Id = s.Id,
                    Name = s.User.Name,
                    Email = s.User.Email,
                    RegisteredOn = s.User.RegisteredOn.ToString("dddd, dd MMMM yyyy"),
                    ProfilePictureUrl = s.User.ProfilePictureUrl,
                    IsApproved = s.CompanyInternsId != null ? true : false

                })
                .ToListAsync();

            return students;
        }

        public async Task<bool> AddStudentToCompanyIternsAsync(List<string> studentIds, string companyUserId)
        {
            var company = await repo.All<Company>()
                .Include(c => c.User)
                .Where(c => c.UserId == companyUserId)
                .FirstOrDefaultAsync();

            var cl = await repo.All<Student>()
                .Include(s => s.Class)
                .Where(s => s.Id == studentIds.First())
                .Select(s => s.Class)
                .FirstOrDefaultAsync();
          
            List<Student> students = new List<Student>();

            foreach (var studentId in studentIds)
            {
                var student = await repo.All<Student>()
                    .FirstOrDefaultAsync(s => s.Id == studentId);

                students.Add(student!);

            }
            string name = $"{cl!.Grade} - {company!.User.Name}";

            CompanyInterns? companyIntern;

            companyIntern = await repo.All<CompanyInterns>()
                .FirstOrDefaultAsync(c => c.CompanyId == company.Id && c.Name == name);

            if(companyIntern == null) 
            {
                companyIntern = new CompanyInterns()
                {
                    Name = $"{cl!.Grade} - {company!.User.Name}",
                    CompanyId = company!.Id,
                    TeacherId = cl!.TeacherId!,
                    Students = students
                };

                await repo.AddAsync(companyIntern);
                await repo.SaveChangesAsync();

            }
            else
            {
                foreach(var student in students)
                {
                    companyIntern.Students.Add(student);

                }
            }

          

            return true;
        }

        public async Task<bool> IsAllStudentsExistsAsync(List<string> studentIds)
        {
            var students = await repo.All<Student>()
                .Select(s => s.Id)
                .ToListAsync();

            foreach(var student in studentIds)
            {
                if(!students.Any(s => s == student))
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<string?> GetStudentGroupIdAsync(string studentId)
        {
            var student = await repo.All<Student>()
                .Where(s => s.Id == studentId)
                .FirstOrDefaultAsync();

            return student!.CompanyInternsId == null ? null : student!.CompanyInternsId;
        }
    }
}
