using FindInternship.Core.Contracts;
using FindInternship.Data.Models;
using FindInternship.Data.Models.Enums;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repo;

        public StatisticService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> GetHappyUsersCountAsync()
        {
            var users = await repo.All<User>()
                .ToListAsync();

            return users.Count;
        }

        public async Task<int> GetInternshipsCountAsync()
        {
            var internships = await repo.All<Request>()
                .Where(i => i.Status.Equals(RequestStatusEnum.Accepted.ToString()) )
                .ToListAsync();

            return internships.Count;
               
        }

        public async Task<int> GetMeetingsArrangedCountAsync()
        {
            var meetings = await repo.All<Meeting>()
                .ToListAsync();

            return meetings.Count;
        }
    }
}
