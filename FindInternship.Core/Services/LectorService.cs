using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Contracts;
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

            lector!.IsActive = false;

            await repo.SaveChangesAsync();
        }
    }
}
