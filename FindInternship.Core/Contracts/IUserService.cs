using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IUserService
    {
        Task<bool> IsUserExistsByEmailAsync(string email);
        Task<bool> IsUserExistsByPhoneAsync(string phoneNumber);
    }
}
