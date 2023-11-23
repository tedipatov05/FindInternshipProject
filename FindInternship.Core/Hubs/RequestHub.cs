using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Request;
using FindInternship.Core.Services;
using FindInternship.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FindInternship.Web.Hubs
{
    public class RequestHub : Hub
    {
        private IRepository repo;
        private ITeacherService teacherService; 
        private IRequestService requestService;
        private ICompanyService companyService;

        public RequestHub(IRepository repo, ITeacherService teacherService, IRequestService requestService, ICompanyService companyService)
        {
            this.repo = repo;
            this.teacherService = teacherService;
            this.requestService = requestService;
            this.companyService = companyService;
        }

        public async Task SendRequest(string topic, string message, string requestId, string companyUserId)
        {
            var request = await requestService.GetRequestByIdAsync(requestId);

            await Clients.User(companyUserId).SendAsync("ReceiveRequest",  topic, message, request.Status, request.DateCreated, request.Id);
        }

        public async Task ChangeRequestStatus(string requestId, string newStatus)
        {
            
            await Clients.All.SendAsync("ReceiveNewStatus", newStatus, requestId);
        }
    }
}
