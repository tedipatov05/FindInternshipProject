using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IStatisticService
    {
        Task<int> GetInternshipsCountAsync();

        Task<int> GetMeetingsArrangedCountAsync();

        Task<int> GetHappyUsersCountAsync();
    }
}
