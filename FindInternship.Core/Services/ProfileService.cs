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
using FindInternship.Core.Models.Lector;

namespace FindInternship.Core.Services
{
    public class ProfileService : IProfileService
    {
        private IRepository repo;
        private IStudentService studentService;
        private IImageService imageService;
        private IAbilityService abilityService;

        public ProfileService(IRepository repo, IStudentService studentService, IImageService imageService, IAbilityService abilityService)
        {
            this.repo = repo;
            this.studentService = studentService;
            this.imageService = imageService;
            this.abilityService = abilityService;
        }

        public async Task EditProfileAsync(string userId, EditProfileModel model)
        {
            var user = await repo.GetByIdAsync<User>(userId);

            if (user == null)
            {
                return;
            }

            user!.Name = model.Name;
            user.Email = model.Email;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;
            user.City = model.City;
            user.Country = model.Country;

            if (model.ProfilePicture != null)
                user.ProfilePictureUrl = await imageService.UploadImage(model.ProfilePicture, "projectImages", user);

            await repo.SaveChangesAsync();

        }

        public async Task<CompanyProfileViewModel?> GetCompanyProfileAsync(string companyId)
        {
            var company = await repo.All<Company>()
                .Where(c => c.Id == companyId)
                .Select(c => new CompanyProfileViewModel()
                {
                    Id = c.User.Id,
                    Name = c.User.Name,
                    Address = c.User.Address,
                    City = c.User.City,
                    Country = c.User.Country,
                    Description = c.Description,
                    Email = c.User.Email,
                    PhoneNumber = c.User.PhoneNumber,
                    ProfilePictureUrl = c.User.ProfilePictureUrl,
                    Services = c.Services,
                    Lectors = c.Lectors.Where(l => l.IsActive).Select(l => new LectorViewModel()
                    {
                        Id = l.Id,
                        Description = l.Description,
                        Name = l.Name,
                        ProfilePicturUrl = l.ProfilePictureUrl
                    }).ToList()

                })
                .FirstOrDefaultAsync();

            if (company != null)
            {
                company!.Technologies = await abilityService.GetCompanyAbilityNamesAsync(companyId);

            }


            return company;
        }

        public async Task<StudentProfileViewModel?> GetStudentProfileAsync(string studentId)
        {
            var student = await repo.All<Student>()
                .Where(s => s.Id == studentId && s.User.IsActive == true)
                .Include(s => s.User)
                .Include(s => s.Class)
                .Include(s => s.Class!.School)
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return null;
            }

            var model = new StudentProfileViewModel()
            {
                Id = student!.User.Id,
                Name = student.User.Name,
                Abilities = await studentService.GetStudentAbilitiesAsync(studentId),
                ProfilePictureUrl = student.User.ProfilePictureUrl,
                Class = student.Class!.Grade,
                Email = student.User.Email,
                PhoneNumber = student.User.PhoneNumber,
                City = student.User.City,
                Country = student.User.Country,
                Address = student.User.Address,
                School = student.Class.School.Name

            };

            return model;


        }

        public async Task<TeacherProfileViewModel?> GetTeacherProfileAsync(string teacherId)
        {
            var teacher = await repo.All<Teacher>()
                .Include(t => t.User)
                .Include(t => t.Class!.Students)
                .Include(t => t.User.ChatMessages)
                .Where(t => t.Id == teacherId && t.User.IsActive == true)
                .FirstOrDefaultAsync();

            var students = await repo.All<Student>()
                .Include(s => s.User)
                .Include(s => s.Class)
                .Where(s => s.Class!.TeacherId == teacherId && s.User.IsActive == true)
                .Select(s => s.User.Name)
                .ToListAsync();

            if (teacher == null)
            {
                return null;
            }


            var model = new TeacherProfileViewModel()
            {

                Id = teacher!.User.Id,
                Name = teacher.User.Name,
                Username = teacher.User.UserName,
                Email = teacher.User.Email,
                PhoneNumber = teacher.User.PhoneNumber,
                City = teacher.User.City,
                Country = teacher.User.Country,
                Address = teacher.User.Address,
                ProfilePictureUrl = teacher.User.ProfilePictureUrl,
                Class = teacher.Class!.Grade,
                StudentsNames = students,
                StudentsCount = teacher.Class.Students.Count(),
                MessagesCount = teacher.User.ChatMessages.Count(),
                Years = (int)DateTime.Now.Subtract(teacher.User.BirthDate).TotalDays / 365


            };

            return model;
        }

        public async Task<EditProfileModel?> GetUserForEditAsync(string userId)
        {
            var u = await repo.All<User>()
                .FirstOrDefaultAsync(s => s.Id == userId && s.IsActive == true);

            if (u == null)
            {
                return null;
            }

            var user = new EditProfileModel()
            {
                Name = u.Name,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                City = u.City,
                Country = u.Country,
                Address = u.Address,
            };


            return user;
        }
    }
}
