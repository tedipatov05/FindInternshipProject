using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Lector;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace FindInternship.Core.Services
{
    public class LectorService : ILectorService
    {
        private readonly IRepository repo;

        public LectorService(IRepository repo)
        {
            this.repo = repo;
        }
        public async Task DeleteAsync(string id)
        {
            var lector = await repo.All<Lector>()
                .FirstOrDefaultAsync(l => l.Id == id && l.IsActive);

            if(lector == null)
            {
                return;
            }

            lector!.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task<List<LectorMeetingViewModel>> GetAllCompanyLectorsAsync(string companyId)
        {
            var lectors = await repo.All<Lector>()
                .Where(l => l.CompanyId == companyId)
                .Select(l => new LectorMeetingViewModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                })
                .ToListAsync();

            return lectors;
        }

        public async Task<bool> IsLectorExistsAsync(string id)
        {
            var isExists = await repo.All<Lector>()
                .AnyAsync(l => l.Id == id);

            return isExists;
        }
    }
}
