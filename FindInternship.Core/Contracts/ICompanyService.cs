using FindInternship.Core.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface ICompanyService
    {
        Task<List<CompanyViewModel>> GetAllCompaniesAsync(CompanyQueryModel model);
        Task<bool> IsCompanyAsync(string userId);
        Task<string> GetCompanyIdAsync(string userId);
    }
}
