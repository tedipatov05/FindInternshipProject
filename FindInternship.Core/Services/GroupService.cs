using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Contracts;
using FindInternship.Core.Hubs;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace FindInternship.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly IRepository repo;
        private readonly IHubContext<PrivateChatHub> hubContext;

        public GroupService(IRepository repo, IHubContext<PrivateChatHub> hubContext)
        {
            this.repo = repo;
            this.hubContext = hubContext;
            
        }

        public async Task AddUserToGroup(string groupName, string toUserName, string fromUserName)
        {
            var toUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName == toUserName);
            string toId = toUser!.Id;
            string toImage = toUser.ProfilePictureUrl!;

            var fromUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName == fromUserName);
            string fromId = fromUser!.Id;
            string fromImage = fromUser.ProfilePictureUrl!;


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

            //await hubContext.Clients.Group(groupName).SendAsync("SendMessage", fromId,fromUserName, fromImage,
            //    $"{fromUserName} се присъедини към {groupName}");
        }

        public async Task<string> GetGroupBetweenUsersAsync(string userId, string receiverId)
        {
            var user = await repo.All<User>()
                .Include(u => u.UserGroups)
                .FirstOrDefaultAsync(u => u.Id == userId && u.IsActive);

            var receiver = await repo.All<User>()
                .Include(u => u.UserGroups)
                .FirstOrDefaultAsync(u => u.Id == receiverId && u.IsActive);

            var userGroups = user!.UserGroups.Select(g => g.GroupId).ToHashSet();
            var receiverGroups = receiver!.UserGroups.Select(g => g.GroupId).ToHashSet();

            userGroups.IntersectWith(receiverGroups);


            return userGroups.FirstOrDefault()!;
        }

        public async Task<string?> GetGroupNameByIdAsync(string groupId)
        {
            var group = await repo.All<Group>()
                .FirstOrDefaultAsync(g => g.Id == groupId);

            return group == null ? null : group!.Name!;
        }
    }
}
