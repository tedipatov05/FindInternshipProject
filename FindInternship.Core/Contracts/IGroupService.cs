using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IGroupService
    {
        Task AddUserToGroup(string groupName, string toUserName, string fromUserName);

        Task<string?> GetGroupBetweenUsersAsync(string userId, string receiverId);

        Task<string?> GetGroupNameByIdAsync(string groupId);
    }
}
