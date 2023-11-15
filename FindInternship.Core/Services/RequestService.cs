using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Request;
using FindInternship.Data.Models;
using FindInternship.Data.Models.Enums;
using FindInternship.Data.Repository;
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
        public RequestService(IRepository repo)
        {
            this.repo = repo;
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

            await repo.AddAsync(request);
            await repo.SaveChangesAsync();
        }
    }
}
