using FindInternship.Core.Models.Lector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface ILectorService
    {
        Task DeleteAsync(string id);

        Task<bool> IsLectorExistsAsync(string id);

        Task<List<LectorMeetingViewModel>> GetAllCompanyLectorsAsync(string companyId);
    }
}
