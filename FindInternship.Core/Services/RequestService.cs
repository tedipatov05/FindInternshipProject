﻿using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Document;
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Request = FindInternship.Data.Models.Request;

namespace FindInternship.Core.Services
{
    public class RequestService : IRequestService
    {
        private IRepository repo;
       
        public RequestService(IRepository repo)
        {
            this.repo = repo;
            
        }

        public async Task<string> Create(CreateRequestModel model)
        {
            var request = new Request()
            {
                Topic = model.Topic,
                Message = model.Message,
                ClassId = model.ClassId!,
                CompanyId = model.CompanyId!,
                CreatedOn = DateTime.Now,
                Status = RequestStatusEnum.Waiting.ToString(),
            };

            await repo.AddAsync(request);
            await repo.SaveChangesAsync();


            return request.Id;
        }

        public async Task<bool> EditRequestStatus(string status, string requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);
            
            if(request != null)
            {
                request.Status = status;
                await repo.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<int> GetAcceptedRequestCountAsync()
        {
            var requests = await repo.All<Request>()
                .Where(r => r.Status == RequestStatusEnum.Accepted.ToString())
                .CountAsync();

            return requests;
        }

        public async Task<List<AllRequestsViewModel>> GetAllClassRequestsByIdAsync(string classId)
        {
            var requests = await repo.All<Request>()
                .Where(r => r.ClassId == classId && r.Status != RequestStatusEnum.Rejected.ToString())
                .Include(r => r.Documents)
                .Include(r => r.Class.Teacher)
                .Select(r => new AllRequestsViewModel()
                {
                    Id = r.Id,
                    Message = r.Message,
                    Status = r.Status,
                    Topic = r.Topic,
                    DateCreated = r.CreatedOn.ToString("dd MMMM, yyyy"),
                    CompanyId = r.CompanyId,
                    TeacherId = r.Class.Teacher!.UserId,
                    ClassId = classId ,
                    Documents = r.Documents
                    .Select(d => new DocumentViewModel()
                    {
                        Type = d.Type,
                        Url = d.DocumentUrl!
                    }).ToList()
                })
                .ToListAsync();

            return requests;
        }

        public async Task<List<AllRequestsViewModel>> GetAllCompanyRequestsByIdAsync(string companyId)
        {
             var requests = await repo.All<Request>()
                .Where(r => r.CompanyId == companyId && r.Status != RequestStatusEnum.Rejected.ToString())
                .Include(r => r.Class.Teacher)
                .Include(r => r.Class.Teacher!.User)
                .Select(r => new AllRequestsViewModel()
                {
                    Id = r.Id,
                    Message = r.Message,
                    Status = r.Status,
                    Topic = r.Topic,
                    DateCreated = r.CreatedOn.ToString("dd MMMM, yyyy"),
                    CompanyId = r.CompanyId,
                    TeacherId = r.Class.Teacher!.UserId,
                    TeacherName = r.Class.Teacher.User.Name, 
                    ClassId = r.ClassId,
                    
                })
                .ToListAsync();

            return requests;

        }

        
        public async Task<AllRequestsViewModel> GetRequestByIdAsync(string requestId)
        {
            var request = await repo.All<Request>()
                .Where(r => r.Id == requestId)
                .Include(r => r.Class.Teacher)
                .Include(r => r.Class.Teacher!.User)
                .Select(r => new AllRequestsViewModel()
                {
                    Id = requestId,
                    Message = r.Message,
                    Status = r.Status,
                    Topic = r.Topic,
                    DateCreated = r.CreatedOn.ToString("dd MMMM, yyyy", CultureInfo.CurrentCulture),
                    CompanyId = r.CompanyId,
                    TeacherId = r.Class.Teacher!.UserId, 
                    TeacherName = r.Class.Teacher.User.Name,
                    
                })
                .FirstOrDefaultAsync();

            return request!;
        }

        public async Task<bool> IsRequestExistsByIdAsync(string requestId)
        {
            var isExists = await repo.All<Request>()
                .AnyAsync(r => r.Id == requestId);

            return isExists;
        }
    }
}
