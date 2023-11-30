using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Account;
using FindInternship.Core.Models.Teacher;
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
    public class TeacherService : ITeacherService
    {
        private IRepository repo;
        private IStudentService studentService;
        private IClassService classService;
        private ISchoolService schoolService;

        public TeacherService(IRepository repo, IStudentService studentService, IClassService classService, ISchoolService schoolService)
        {
            this.repo = repo;
            this.studentService = studentService;
            this.classService = classService;
            this.schoolService = schoolService;
        }

        public async Task Create(RegisterTeacherViewModel model, string userId)
        {
            string classId = await classService.GetClassIdIfExistsAsync(model.Class);
            int? schoolId = await schoolService.GetSchoolIdIfExistsAsync(model.School);

            if(schoolId == null) 
            {
                schoolId = await schoolService.Create(model.School, model.City); 
            }
            if(classId == null)
            {
                classId = await classService.CreateAsync(model.Class, model.Speciality, (int)schoolId);
            }

            var teacher = new Teacher()
            {
                UserId = userId,
                ClassId = classId,
            };

            await repo.AddAsync(teacher);
            await repo.SaveChangesAsync();

            await classService.UpdateAsync(classId, teacher.Id);

        }

        public async Task<string> GetTeacherClassIdAsync(string userId)
        {
            var teacher = await repo.All<Teacher>()
                .FirstOrDefaultAsync(t => t.UserId == userId);

            return teacher!.ClassId;
        }

        public async Task<string> GetTeacherIdAsync(string userId)
        {
            var teacher= await repo.All<Teacher>().FirstOrDefaultAsync(t => t.UserId == userId && t.User.IsActive == true);

            return teacher!.Id;
        }

        public async Task<TeacherStudentsViewModel> GetTeacherStudentsAsync(string teacherId)
        {
            var teacher = await repo.All<Teacher>()
                .Include(s => s.Class)
                .Include(s => s.Class.School)
                .FirstOrDefaultAsync(s => s.Id == teacherId && s.User.IsActive == true);
                
            var model = new TeacherStudentsViewModel();
            model.Id = teacher!.Id;
            model.Class = teacher.Class.Grade;
            model.ClassSpeciality = teacher.Class.Speciality;
            model.School = teacher.Class.School.Name;

            model.Students = await studentService.GetTeacherStudentsAsync(teacher.Class.Grade);

            return model;
                
        }

        public async Task<bool> IsTeacherAsync(string userId)
        {
            var isTeacher = await repo.All<Teacher>()
                .AnyAsync(t => t.UserId == userId && t.User.IsActive == true);

            return isTeacher;
        }
    }
}
