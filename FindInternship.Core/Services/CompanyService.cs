using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Company;
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
    public class CompanyService : ICompanyService
    {
        private readonly IRepository repo;

        public CompanyService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<CompanyViewModel>> GetAllCompaniesAsync()
        {
            var companies = await repo.All<Company>()
                .Select(c => new CompanyViewModel()
                {
                    Id = c.Id,
                    Name = c.User.Name,
                    ProfilePictureUrl = c.User.ProfilePictureUrl,
                    Address = c.User.Address
                })
                .ToListAsync();

            return companies;
        }
    }
}
