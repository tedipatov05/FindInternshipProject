using FindInternship.Core.Contracts;
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
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> IsExistsByIdAsync(string id)
        {
            var isExists = await repo.All<User>().AnyAsync(u => u.Id == id);

            return isExists;
        }

        public async Task<string> GetUserIdByUsernameAsync(string username)
        {
            var user = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName == username);

            return user!.Id;
        }

        public async Task<bool> IsExistsByUsernameAsync(string username)
        {
            bool isExists = await repo.All<User>()
                .AnyAsync(u => u.UserName.ToUpper() == username.ToUpper());

            return isExists;
        }

        public async Task<bool> IsUserExistsByEmailAsync(string email)
        {
            var IsExist = await repo.All<User>().AnyAsync(u => u.Email==email);
            return IsExist;
            
        }

        public async Task<bool> IsUserExistsByPhoneAsync(string phoneNumber)
        {
            var IsExist = await repo.All<User>().AnyAsync(u => u.PhoneNumber == phoneNumber);
            return IsExist;

        }

        public async Task<int> GetUsersCountAsync()
        {
            var usersCount = await repo.All<User>().CountAsync();

            return usersCount;
        }

        public async Task<List<UserViewModel>> GetFilteredUsersAsync(UsersQueryModel model)
        {
            IQueryable<User> usersQuery = repo.All<User>()
                .Where(u => u.IsActive && !u.IsApproved);


            if (!string.IsNullOrEmpty(model.SearchString))
            {
                string wildCard = $"%{model.SearchString.ToLower()}%";

                usersQuery = usersQuery
                    .Where(u => EF.Functions.Like(u.Name.ToLower(), wildCard) ||
                                EF.Functions.Like(u.Email.ToLower(), wildCard) ||
                                EF.Functions.Like(u.City.ToLower(), wildCard));

            }

            var users = await usersQuery
                .Select(u => new UserViewModel()
                {
                    Id = u.Id, 
                    Name = u.Name,
                    Email = u.Email,
                    RegisteredOn = u.RegisteredOn.ToString("dddd, dd MMMM yyyy"),
                    ProfilePictureUrl = u.ProfilePictureUrl,
                })
                .ToListAsync();

            return users;



        }

        public async Task ChangeUserIsApprovedAsync(string userId)
        {
            var user = await repo.GetByIdAsync<User>(userId);

            user!.IsApproved = true;

            await repo.SaveChangesAsync();
                
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await repo.GetByIdAsync<User>(userId);

            user!.IsApproved = false;
            user!.IsActive = false;
            

            await repo.SaveChangesAsync();

        }
    }
}
