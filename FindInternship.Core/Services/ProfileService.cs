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

            user.Name = model.Name;
            user.Email = model.Email;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;
            user.City = model.City;
            user.Country = model.Country;

            if (model.ProfilePicture != null)
                user.ProfilePictureUrl = await imageService.UploadImage(model.ProfilePicture, "projectImages", user);

            await repo.SaveChangesAsync();
                
        }

        public async Task<CompanyProfileViewModel> GetCompanyProfileAsync(string companyId)
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

                })
                .FirstOrDefaultAsync();

            company!.Technologies = await abilityService.GetCompanyAbilityNamesAsync(companyId);

            return company;
        }

        public async Task<StudentProfileViewModel> GetStudentProfileAsync(string studentId)
        {
            var student = await repo.All<Student>()
                .Where(s => s.Id == studentId && s.User.IsActive == true)
                .Include(s => s.User)
                .Include(s => s.Class)
                .FirstOrDefaultAsync();

            var model = new StudentProfileViewModel()
            {
                Id = student.User.Id,
                Name = student.User.Name,
                Abilities = await studentService.GetStudentAbilitiesAsync(studentId),
                ProfilePictureUrl = student.User.ProfilePictureUrl,
                Class = student.Class.Grade,
                Email = student.User.Email,
                PhoneNumber = student.User.PhoneNumber,
                City = student.User.City,
                Country = student.User.Country,
                Address = student.User.Address,
                School = student.Class.School

            };

            return model;

            
        }

        public async Task<TeacherProfileViewModel> GetTeacherProfileAsync(string teacherId)
        {
            var teacher = await repo.All<Teacher>()
                .Include(t => t.User)
                .Include(t => t.Class.Students)
				.Where(t => t.Id == teacherId && t.User.IsActive == true)
				.FirstOrDefaultAsync();

            var students = await repo.All<Student>()
                .Include(s => s.User)
                .Include(s => s.Class)
                .Where(s => s.Class.TeacherId ==  teacherId && s.User.IsActive == true)
                .Select(s => s.User.Name)
                .ToListAsync();


            var model = new TeacherProfileViewModel()
            {
                Id = teacher.User.Id,
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

        public async Task<EditProfileModel> GetUserForEditAsync(string userId)
        {
            var u = await repo.All<User>()
                .FirstOrDefaultAsync(s => s.Id == userId && s.IsActive == true);

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
