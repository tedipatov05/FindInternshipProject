using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Models.PrivateChat;
using FindInternship.Data.Models;

namespace FindInternship.Core.Contracts
{
    public interface IPrivateChatService
    {
        Task AddUserToGroup(string groupName, string toUserName, string fromUserName);

        Task<List<UsersToChatViewModel>> GetUsersToChatAsync(string classId, string currentUserId);

        Task<UsersToChatViewModel> GetTeacherToChatAsync(string classId, string currentUserId);

        Task<UsersToChatViewModel> GetCompanyToChatAsync(string classId, string currentUserId);

        Task<ICollection<ChatMessage>> ExtractAllMessagesAsync(string group);

    }
}
