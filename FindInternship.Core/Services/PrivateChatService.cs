using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Contracts;
using FindInternship.Core.Hubs;
using FindInternship.Core.Models.PrivateChat;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Ganss.Xss;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static FindInternship.Common.ApplicationConstants;

namespace FindInternship.Core.Services
{
    public class PrivateChatService : IPrivateChatService
    {
        private readonly IRepository repo;
        private readonly IHubContext<PrivateChatHub> hubContext;

        public PrivateChatService(IRepository repo, IHubContext<PrivateChatHub> hubContext)
        { 
            this.repo = repo;
            this.hubContext = hubContext;
                
        }

        public async Task AddUserToGroup(string groupName, string toUserName, string fromUserName)
        {
            var toUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName == toUserName);
            string toId = toUser.Id;
            string toImage = toUser.ProfilePictureUrl;

            var fromUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName == fromUserName);
            string fromId = fromUser.Id;
            string fromImage = fromUser.ProfilePictureUrl;


            var group = await repo.All<Group>()
                .FirstOrDefaultAsync(g => g.Name.ToLower() == groupName.ToLower());

            if (group == null)
            {
                group = new Group()
                {
                    Name = groupName
                };

                var targetToUser = new UserGroup()
                {
                    UserId = toId,
                    Group = group
                };

                var targetFromUser = new UserGroup()
                {
                    UserId = fromId,
                    Group = group
                };


                group.UsersGroups.Add(targetFromUser);
                group.UsersGroups.Add(targetToUser);

                await repo.AddAsync(group);
                await repo.SaveChangesAsync();
            }

            await hubContext.Clients.Groups(groupName).SendAsync("ReceiveMessage", fromUserName, fromImage,
                $"{fromUserName} се присъедини към {groupName}");
        }

        public async Task<List<UsersToChatViewModel>> GetUsersToChatAsync(string classId, string currentUserId)
        {
            var users = await repo.All<Student>()
                .Include(s => s.User)
                .Include(s => s.User.ChatMessages)
                .Where(s => s.ClassId == classId && s.User.IsActive)
                .Select(s => new UsersToChatViewModel()
                {
                    UserId = s.UserId,
                    Name = s.User.Name,
                    ProfilePicture = s.User.ProfilePictureUrl,
                    LastMessageToUser = s.User.ChatMessages.Where(c => c.UserId == currentUserId)
                        .OrderBy(m => m.SendedOn).Last().Content, 
                    LastSendOn = s.User.ChatMessages.Where(c => c.UserId == currentUserId)
                        .OrderBy(m => m.SendedOn).Last().SendedOn.ToString("HH:mm"),

                })
                .ToListAsync();
            return users;


        }

        //TODO: Change logic for messages

        public async Task<UsersToChatViewModel> GetTeacherToChatAsync(string classId, string currentUserId)
        {
            var teacher = await repo.All<Teacher>()
                .Include(t => t.User)
                .Where(t => t.ClassId == classId && t.User.IsActive)
                .Include(t => t.User.ChatMessages)
                .Select(t => new UsersToChatViewModel()
                {
                    UserId = t.UserId,
                    Name = t.User.Name,
                    ProfilePicture = t.User.ProfilePictureUrl,
                    LastMessageToUser = t.User.ChatMessages.Where(c => c.UserId == currentUserId)
                        .OrderBy(m => m.SendedOn).Last().Content,
                    LastSendOn = t.User.ChatMessages.Where(c => c.UserId == currentUserId)
                        .OrderBy(m => m.SendedOn).Last().SendedOn.ToString("HH:mm"),

                })
                .FirstOrDefaultAsync();

            return teacher;

        }

        public async Task<UsersToChatViewModel> GetCompanyToChatAsync(string classId, string currentUserId)
        {
            var company = await repo.All<Company>()
                .Include(t => t.User)
                .Where(t => t.Classes.Any(c => c.Id == classId) && t.User.IsActive)
                .Include(t => t.User.ChatMessages)
                .Select(t => new UsersToChatViewModel()
                {
                    UserId = t.UserId,
                    Name = t.User.Name,
                    ProfilePicture = t.User.ProfilePictureUrl,
                    LastMessageToUser = t.User.ChatMessages.Where(c => c.UserId == currentUserId)
                        .OrderBy(m => m.SendedOn).Last().Content,
                    LastSendOn = t.User.ChatMessages.Where(c => c.UserId == currentUserId)
                        .OrderBy(m => m.SendedOn).Last().SendedOn.ToString("HH:mm"),

                })
                .FirstOrDefaultAsync();

            return company;
        }

        public async Task<ICollection<ChatMessage>> ExtractAllMessagesAsync(string groupName)
        {
            var targetGroup = await repo.All<Group>()
                .FirstOrDefaultAsync(g => g.Name == groupName);

            if (targetGroup != null)
            {
                var messages = await repo.All<ChatMessage>()
                    .Where(ch => ch.GroupId == targetGroup.Id)
                    .Include(m => m.User)
                    .OrderByDescending(ch => ch.SendedOn)
                    .Take(MessageCountPerScroll)
                    .OrderBy(m => m.SendedOn)
                    .ToListAsync();


                return messages;
            }

            return new List<ChatMessage>();
        }

        public async Task<ICollection<LoadMoreMessagesViewModel>> LoadMoreMessagesAsync(string group, int messagesSkipCount, User user)
        {

            var targetGroup = await repo.All<Group>()
                .FirstOrDefaultAsync(g => g.Name.ToLower() == group.ToLower());

            if (targetGroup != null)
            {
                var messages = await repo.All<ChatMessage>()
                    .Where(c => c.GroupId == targetGroup.Id)
                    .OrderByDescending(m => m.SendedOn)
                    .Skip(messagesSkipCount)
                    .Take(MessageCountPerScroll)
                    .Include(m => m.User)
                    .Select(m => new LoadMoreMessagesViewModel()
                    {
                        Id = m.Id, 
                        Content = m.Content,
                        CurrentUsername = user.UserName, 
                        FromImageUrl = m.User.ProfilePictureUrl, 
                        FromUsername = m.User.UserName, 
                        SendedOn = m.SendedOn.ToLocalTime().ToString("dd/mm/yyyy hh:mm:ss tt")
                    })
                    .ToListAsync();

                return messages;
            }

            return new List<LoadMoreMessagesViewModel>();
        }

        public async Task SendMessageToUser(string fromUsername, string toUsername, string message, string group)
        {
            var toUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == u.UserName.ToLower() && u.IsActive);

            var fromUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == fromUsername.ToLower() && u.IsActive);

            var targetGroup = await repo.All<Group>()
                .FirstOrDefaultAsync(g => g.Name.ToLower() == group.ToLower());


            var newMessage = new ChatMessage()
            {
                User = fromUser,
                Group = targetGroup,
                SendedOn = DateTime.Now,
                Content = new HtmlSanitizer().Sanitize(message.Trim()),
                ReceiverImageUrl = toUser.ProfilePictureUrl,
                ReceiverUsername = toUser.UserName,

            };

            await repo.AddAsync(newMessage);
            await repo.SaveChangesAsync();

            await hubContext.Clients.User(toUser.Id).SendAsync("ReceiveMessage", fromUsername,
                fromUser.ProfilePictureUrl, new HtmlSanitizer().Sanitize(message.Trim()));


        }
    }
}
