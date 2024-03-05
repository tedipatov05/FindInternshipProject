using FindInternship.Core.Contracts;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IRepository repo;
        public MaterialService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<string> CreateAsync(string documentUrl, string name, string meetingId)
        {
            var material = new MeetingMaterial()
            {
                Name = name,
                DocumentUrl = documentUrl,
                MeetingId = meetingId
            };

            await repo.AddAsync(material);

            await repo.SaveChangesAsync();

            return material.Id;
        }
    }
}
