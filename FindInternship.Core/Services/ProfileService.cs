using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Account;
using FindInternship.Core.Models.Profile;
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
    public class ProfileService : IProfileService
    {
        private IRepository repo;
        private IStudentService studentService;
       
        public ProfileService(IRepository repo, IStudentService studentService)
        {
            this.repo = repo;
            this.studentService = studentService;
        }

        public async Task<StudentProfileViewModel> GetStudentProfileAsync(string studentId)
        {
            var student = await repo.All<Student>()
                .Where(s => s.Id == studentId)
                .Include(s => s.User)
                .Include(s => s.Class)
                .FirstOrDefaultAsync();

            var model = new StudentProfileViewModel()
            {
                Id = studentId,
                Name = student.User.Name,
                Abilities = await studentService.GetStudentAbilitiesAsync(studentId),
                ProfilePictureUrl = student.User.ProfilePictureUrl,
                Class = student.Class.Grade,
                Email = student.User.Email,
                PhoneNumber = student.User.PhoneNumber,
                City = student.User.City,
                Country = student.User.Country,
                Address = student.User.Address,

            };

            return model;

            
        }

        public async Task<TeacherProfileViewModel> GetTeacherProfileAsync(string teacherId)
        {
            var teacher = await repo.All<Teacher>()
                .Where(t => t.Id == teacherId)
                .Include(t => t.User)
                .Include(t => t.Class.Students)
                .FirstOrDefaultAsync();

            var students = await repo.All<Student>()
                .Include(s => s.User)
                .Include(s => s.Class)
                .Where(s => s.Class.TeacherId ==  teacherId)
                .Select(s => s.User.Name)
                .ToListAsync();


            var model = new TeacherProfileViewModel()
            {
                Id = teacherId,
                Name = teacher.User.Name,
                Email = teacher.User.Email,
                PhoneNumber = teacher.User.PhoneNumber,
                City = teacher.User.City,
                Country = teacher.User.Country,
                Address = teacher.User.Address,
                ProfilePictureUrl = teacher.User.ProfilePictureUrl,
                Class = teacher.Class.Grade,
                StudentsNames = students

            };

            return model;
        }
    }
}
