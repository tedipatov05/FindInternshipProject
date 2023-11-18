using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Email;
using FindInternship.Core.Models.Request;
using FindInternship.Data.Models;
using FindInternship.Data.Models.Enums;
using FindInternship.Data.Repository;
using FindInternship.Web.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class RequestService : IRequestService
    {
        private IRepository repo;
        private IHubContext<RequestHub> hubContext;
        public RequestService(IRepository repo, IHubContext<RequestHub> hubContext)
        {
            this.repo = repo;
            this.hubContext = hubContext;
        }

        public async Task Create(CreateRequestModel model)
        {
            var request = new Request()
            {
                Topic = model.Topic,
                Message = model.Message,
                ClassId = model.ClassId,
                CompanyId = model.CompanyId,
                CreatedOn = DateTime.Now,
                Status = RequestStatusEnum.Waiting.ToString(),
            };

            //await hubContext.Clients.User(companyUserId).SendAsync("ReceiveRequest", request.Topic,request.Message);

            await repo.AddAsync(request);
            await repo.SaveChangesAsync();
        }
    }
}
