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
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

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
                .Where(s => s.ClassId == classId)
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
    }
}
