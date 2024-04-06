using FindInternship.Core.Models.Class;
using FindInternship.Core.Models.CompanyInterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface ICompanyInternsService
    {
        Task<List<CompanyInternsViewModel>> GetClassMeetingAsync(string companyId);

        
    }
}
