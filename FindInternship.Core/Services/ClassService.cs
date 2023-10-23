using FindInternship.Core.Contracts;
using FindInternship.Core.Models;
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
    public class ClassService : IClassService
    {
        private IRepository repo;

        public ClassService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<ClassViewModel>> AllClassesAsync()
        {
            var classes = await repo.All<Class>()
                .Select(c => new ClassViewModel()
                {
                    Id = c.Id,
                    Name = c.Grade
                })
                .ToListAsync();

            return classes;
        }
    }
}
