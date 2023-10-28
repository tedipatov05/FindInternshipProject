using FindInternship.Core.Contracts;
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
    }
}
