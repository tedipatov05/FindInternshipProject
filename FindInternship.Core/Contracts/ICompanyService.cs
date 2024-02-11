using FindInternship.Core.Models;
using FindInternship.Core.Models.Class;
using FindInternship.Core.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Models.Lector;
using FindInternship.Core.Models.Meeting;

namespace FindInternship.Core.Contracts
{
    public interface ICompanyService
    {
        Task<List<CompanyViewModel>> GetAllCompaniesAsync(CompanyQueryModel model);
        Task<bool> IsCompanyAsync(string userId);

        Task<string?> GetCompanyIdByNameAsync(string companyName);
        Task<string?> GetCompanyIdAsync(string userId);
        Task<string?> GetCompanyNameByIdAsync(string companyId);

        Task AddClassToCompany(string classId, string companyId);

        Task CreateAsync(string userId, string services, string description);

        Task<bool> IsInCompanyScheduleAsync(string companyId, string meetingId);

        Task AddLectorToCompany(string companyId, AddLectorViewModel model, string profilePicture);

        Task<bool> IsLectorInCompany(string companyId, string lectorId);





    }
}
