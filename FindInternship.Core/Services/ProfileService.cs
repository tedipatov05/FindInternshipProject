using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Account;
using FindInternship.Core.Models.Profile;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
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
        private ITeacherService teacherService;
        private IStudentService studentService;
        public ProfileService(IRepository repo, ITeacherService teacherService, IStudentService studentService)
        {
            this.repo = repo;
            this.teacherService = teacherService;
            this.studentService = studentService;
        }

        public async Task<ProfileViewModel> GetProfileAsync(string userId, string role)
        {
            var user = await repo.GetByIdAsync<User>(userId);
            if(user == null)
            {
                throw new ArgumentNullException("Този потребител не съществува");
            }

            var model = new ProfileViewModel()
            {
                Id = userId,
                Name = user.Name,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Role = role,
                Email = user.Email,
                Phone = user.PhoneNumber,
                City = user.City,
                Country = user.Country,



            };

            if(role.ToLower() == "student")
            {
                var studentId = await studentService.GetStudentId(userId);
                if(studentId == null)
                {
                    throw new ArgumentNullException("Този ученик не съществува");
                }
                model.Abilities = await studentService.GetStudentAbilitiesAsync(studentId);

            }

            return model;
        }
    }
}
