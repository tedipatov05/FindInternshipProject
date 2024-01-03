using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Models.PrivateChat;

namespace FindInternship.Core.Contracts
{
    public interface IPrivateChatService
    {
        Task AddUserToGroup(string groupName, string toUserName, string fromUserName);

        Task<List<UsersToChatViewModel>> GetUsersToChatAsync(string classId, string currentUserId);

    }
}
