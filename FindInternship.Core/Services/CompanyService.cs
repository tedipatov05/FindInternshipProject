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

        public async Task<List<CompanyViewModel>> GetAllCompaniesAsync(CompanyQueryModel model)
        {
            IQueryable<Company> companyQuery = repo.All<Company>()
                .Where(c => c.User.IsActive == true);

            if(!string.IsNullOrEmpty(model.SearchString))
            {

				string wildCard = $"%{model.SearchString.ToLower()}%";

                companyQuery = companyQuery
                    .Where(c => EF.Functions.Like(c.User.Name, wildCard) ||
                                EF.Functions.Like(c.Description, wildCard) ||
                                EF.Functions.Like(c.Services, wildCard));
			}

            if(!string.IsNullOrEmpty(model.Technology))
            {
                companyQuery = companyQuery
                    .Where(c => c.Technologies.Select(t => t.Ability.AbilityText).Contains(model.Technology));
            }

            var companies = await companyQuery
                .Select(c => new CompanyViewModel()
                {
                    Id = c.Id,
                    Name = c.User.Name, 
                    ProfilePictureUrl = c.User.ProfilePictureUrl,
                    Address = c.User.Address, 
                    Description = c.Description
                })
                .ToListAsync();

            return companies;
               
        }

        public async Task<string> GetCompanyIdAsync(string userId)
        {
            var company = await repo.All<Company>()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return company!.Id;
        }

        public async Task<bool> IsCompanyAsync(string userId)
        {
            return await repo.All<Company>().AnyAsync(c => c.UserId == userId);
        }
    }
}
