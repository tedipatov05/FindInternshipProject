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
        

        Task<List<UsersToChatViewModel>> GetUsersToChatAsync(string classId, string currentUserId);

        Task<UsersToChatViewModel> GetTeacherToChatAsync(string classId, string currentUserId);

        Task<UsersToChatViewModel> GetCompanyToChatAsync(string classId, string currentUserId);

        Task<ICollection<ChatMessage>> ExtractAllMessagesAsync(string group);

        Task<ICollection<LoadMoreMessagesViewModel>> LoadMoreMessagesAsync(string group, int messagesSkipCount,
            User user);

        Task SendMessageToUser(string fromUsername, string toUsername, string message, string group);

        Task ReceiveNewMessage(string fromUsername, string message, string group);

       

    }
}
