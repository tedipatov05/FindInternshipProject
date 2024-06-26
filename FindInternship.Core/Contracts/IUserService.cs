﻿using FindInternship.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IUserService
    {
        Task<bool> IsUserExistsByEmailAsync(string email);
        Task<bool> IsUserExistsByPhoneAsync(string phoneNumber);

        Task<bool> IsExistsByIdAsync(string id);

        Task<string?> GetUserIdByUsernameAsync(string username);

        Task<bool> IsExistsByUsernameAsync(string username);

        Task<string> GetUserProfilePictureByUsernameAsync(string username);

        Task<int> GetUsersCountAsync();

        Task<List<string>> GetParticipantsProfilePictureAsync(List<string> usernames);

        Task<List<UserViewModel>> GetFilteredUsersAsync(UsersQueryModel model, string adminId);

        Task ChangeUserIsApprovedAsync(string userId);

        Task DeleteUserAsync(string userId);
    }
}
