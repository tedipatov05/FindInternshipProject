﻿using FindInternship.Core.Contracts;
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

        public async Task<string> GetClassIdByStudentUserIdAsync(string userId)
        {
            var user = await repo.All<Student>()
                .FirstOrDefaultAsync(t => t.UserId == userId);

            return user!.ClassId!;
        }

        public async Task<string> GetClassIdByTeacherUserIdAsync(string userId)
        {
            var user = await repo.All<Teacher>()
                .FirstOrDefaultAsync(t => t.UserId == userId);

            return user!.ClassId!;
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

        public async Task<List<ClassViewModel>> GetAllClassesAsync()
        {
            var classes = await repo.All<Class>()
                .Include(c => c.Teacher)
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

            await repo.DeleteAsync<Class>(classId);

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

            var company = await repo.All<Company>()
                .Include(s => s.Classes)
                .FirstOrDefaultAsync(c => c.Classes.Any(c => c.Id == classId));

            if(company  != null)
            {
                company.Classes.Remove(classModel!);
            }


            await repo.SaveChangesAsync();

            

        }
    }
}
