﻿using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Account;
using FindInternship.Core.Models.CompanyInterns;
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
            string classId = classService.GetClassIdIfExistsAsync(model.Class.Trim(), model.School)!;
            int? schoolId =  schoolService.GetSchoolIdIfExistsAsync(model.School);

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

        public async Task<string?> GetTeacherClassIdAsync(string userId)
        {
            var teacher = await repo.All<Teacher>()
                .FirstOrDefaultAsync(t => t.UserId == userId);

            return teacher == null || teacher.ClassId == null ? null : teacher.ClassId;
        }

        public async Task<string?> GetTeacherIdAsync(string userId)
        {
            var teacher= await repo.All<Teacher>().FirstOrDefaultAsync(t => t.UserId == userId && t.User.IsActive == true);

            return teacher == null ? null : teacher.Id;
        }

		public async Task<string?> GetTeacherUserIdByClassAsync(string classId)
		{
			var teacher = await repo.All<Teacher>()
                .FirstOrDefaultAsync(t => t.ClassId == classId);

            

            return teacher == null ? null : teacher.UserId;
                
		}

        public async Task<string?> GetTeacherUserIdByMeetingIdAsync(string meetingId)
        {
            var meeting = await repo.All<Meeting>()
                .Where(t => t.Id == meetingId)
                .Include(t => t.CompanyInterns)
                .Include(m => m.CompanyInterns.Teacher)
                .FirstOrDefaultAsync();

            return meeting == null ? null : meeting.CompanyInterns.Teacher.UserId;    
        }

        public async Task<TeacherStudentsViewModel> GetTeacherStudentsAsync(string teacherId)
        {
            var teacher = await repo.All<Teacher>()
                .Include(s => s.Class)
                .Include(s => s.Class!.School)
                .FirstOrDefaultAsync(s => s.Id == teacherId && s.User.IsActive == true);
                
            var model = new TeacherStudentsViewModel();
            model.Id = teacher!.Id;
            model.Class = teacher.Class!.Grade;
            model.ClassSpeciality = teacher.Class.Speciality;
            model.School = teacher.Class.School.Name;

            model.Students = await studentService.GetTeacherStudentsAsync(teacher.Class.Id);

            return model;
                
        }

        public async Task<string?> GetTeacherUserIdAsync(string teacherId)
        {
            var teacher = await repo.All<Teacher>()
                .FirstOrDefaultAsync(t => t.Id == teacherId || t.UserId == teacherId);


            return teacher == null ? null : teacher.UserId;
        }

        public async Task<bool> IsTeacherAsync(string userId)
        {
            var isTeacher = await repo.All<Teacher>()
                .AnyAsync(t => t.UserId == userId && t.User.IsActive == true);

            return isTeacher;
        }

        public async Task<string?> GetTeacherUserIdByCompanyInternIdAsync(string companyInternId)
        {
            var companyIntern = await repo.All<CompanyInterns>()
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(c => c.Id == companyInternId);

            return companyIntern != null ? companyIntern.Teacher.UserId : null;
        }

        public async Task<bool> IsAllStudentsHaveGroupInCompanyAsync(string teacherUserId)
        {
            var company = await repo.All<Teacher>()
                .Include(t => t.Class!.Students)
                .FirstOrDefaultAsync(s => s.UserId == teacherUserId);

            if(company == null) return false;


            return company!.Class!.Students.All(s => s.CompanyInternsId != null);
        }

        public async Task<List<CompanyInternsViewModel>> GetTeacherCompanyInternsAsync(string userId)
        {
            var teacher = await repo.All<Teacher>()
                .Where(t => t.UserId == userId)
                .Include(t => t.Groups)
                .FirstOrDefaultAsync();

            if(teacher == null)
            {
                return new List<CompanyInternsViewModel>();
            }

            var companyInterns = teacher.Groups
                .Select(g => new CompanyInternsViewModel()
                {
                    Id = g.Id, 
                    Name = g.Name,
                })
                .ToList();

            return companyInterns;

        }

       
    }
}
