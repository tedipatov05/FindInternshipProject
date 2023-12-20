using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Contracts;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace FindInternship.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly IRepository repo;

        public GroupService(IRepository repo)
        {
            this.repo = repo;
            
        }

        public async Task AddToGroup(string groupName, string userId)
        {
            var group = await repo.All<Group>()
                .FirstOrDefaultAsync(g => g.Name == groupName);

            if (group == null)
            {
                group = new Group()
                {
                    Name = groupName
                };

                var userGroup = new UserGroup()
                {
                    UserId = userId,
                    Group = group
                };


                group.UsersGroups.Add(userGroup);
                await repo.AddAsync(group);
                
                
            }
            else
            {
                var isInGroupToUser = group.UsersGroups.Any(g => g.UserId == userId);
                if (!isInGroupToUser)
                {
                    var userGroup = new UserGroup()
                    {
                        UserId = userId,
                        Group = group
                    };

                    group.UsersGroups.Add(userGroup);
                }

            }

            await repo.SaveChangesAsync();
        }
    }
}
