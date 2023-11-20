﻿using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Email;
using FindInternship.Core.Models.Request;
using FindInternship.Data.Models;
using FindInternship.Data.Models.Enums;
using FindInternship.Data.Repository;
using FindInternship.Web.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Request = FindInternship.Data.Models.Request;

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

        public async Task<string> Create(CreateRequestModel model)
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


            return request.Id;
        }

        public async Task<List<AllRequestsViewModel>> GetAllCompanyRequestsByIdAsync(string companyId)
        {
             var requests = await repo.All<Request>()
                .Where(r => r.CompanyId == companyId)
                .Select(r => new AllRequestsViewModel()
                {
                    Id = r.Id,
                    Message = r.Message,
                    Status = r.Status,
                    Topic = r.Topic,
                    DateCreated = r.CreatedOn.ToString("dd MMMM, yyyy")
                })
                .ToListAsync();

            return requests;
        }

        public async Task<AllRequestsViewModel> GetRequestByIdAsync(string requestId)
        {
            var request = await repo.All<Request>()
                .Select(r => new AllRequestsViewModel()
                {
                    Id = requestId,
                    Message = r.Message,
                    Status = r.Status,
                    Topic = r.Topic,
                    DateCreated = r.CreatedOn.ToString("dd MMMM, yyyy")
                })
                .FirstOrDefaultAsync(r => r.Id == requestId);

            return request;
        }
    }
}