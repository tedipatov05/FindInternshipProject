using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Class;
using FindInternship.Core.Models.CompanyInterns;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class CompanyInternsService : ICompanyInternsService
    {
        private readonly IRepository repo;

        public CompanyInternsService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<CompanyInternsViewModel>> GetClassMeetingAsync(string companyId)
        {
            var classes = await repo.All<CompanyInterns>()
                .Where(c => c.CompanyId == companyId)
                .Select(c => new CompanyInternsViewModel()
                {
                    Id = c.Id, 
                    Name = c.Name,
                 
                })
                .ToListAsync();

            return classes;
        }
    }
}
