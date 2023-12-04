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
        private readonly IRepository repo;
        private readonly ITeacherService teacherService; 
        private readonly IRequestService requestService;
        private readonly ICompanyService companyService;
        private readonly IDocumentService documentService;

        public RequestHub(IRepository repo, ITeacherService teacherService, IRequestService requestService, ICompanyService companyService, IDocumentService documentService)
        {
            this.repo = repo;
            this.teacherService = teacherService;
            this.requestService = requestService;
            this.companyService = companyService;
            this.documentService = documentService;
        }

        public async Task SendRequest(string topic, string message, string requestId, string companyUserId)
        {
            var request = await requestService.GetRequestByIdAsync(requestId);

            await Clients.User(companyUserId).SendAsync("ReceiveRequest", topic, message, request.Status, request.DateCreated, request.Id, request.TeacherId, request.TeacherName);
        }

        public async Task ChangeRequestStatus(string requestId, string newStatus)
        {
            await Clients.All.SendAsync("ReceiveNewStatus", newStatus, requestId);
        }

        public async Task SendDocuments(HashSet<string> documentIds, string teacherId, string requestId)
        {
            string receiverId = await teacherService.GetTeacherUserIdAsync(teacherId);

            var documents = await documentService.GetDocumentsAsync(documentIds);

            await Clients.User(receiverId).SendAsync("ReceiveDocuments", documents, requestId);
        }
    }
}
