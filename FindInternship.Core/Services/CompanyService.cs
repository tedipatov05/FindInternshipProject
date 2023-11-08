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

            if(model.SearchString != null)
            {

				string wildCard = $"%{model.SearchString.ToLower()}%";

                companyQuery = companyQuery
                    .Where(c => EF.Functions.Like(c.User.Name, wildCard) ||
                                EF.Functions.Like(c.Description, wildCard) ||
                                EF.Functions.Like(c.Services, wildCard));
			}

            var companies = await companyQuery
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
