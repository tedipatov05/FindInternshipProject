using FindInternship.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IRequestService
    {
        Task<string> Create(CreateRequestModel model);

        Task<AllRequestsViewModel> GetRequestByIdAsync(string requestId);

        Task<List<AllRequestsViewModel>> GetAllCompanyRequestsByIdAsync(string companyId);

        Task<bool> EditRequestStatus(string status, string requestId);
    }
}
