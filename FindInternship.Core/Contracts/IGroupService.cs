using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IGroupService
    {
        Task AddToGroup(string groupName, string userId);
    }
}
