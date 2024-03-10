using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Materials;
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

        public async Task DeleteAllMeetingMaterials(string meetingId)
        {
            var materials = await repo.All<MeetingMaterial>()
                .Where(m => m.MeetingId == meetingId)
                .ToListAsync();

            repo.DeleteRange<MeetingMaterial>(materials);

            await repo.SaveChangesAsync();

        }

        public async Task<List<MaterialViewModel>> GetAllMeetingMatrialsAsync(string meetingId)
        {
            var meetingMaterials = await repo.All<MeetingMaterial>()
                .Where(m =>  m.MeetingId == meetingId)
                .Select(m => new MaterialViewModel()
                {
                    Name = m.Name,
                    Url = m.DocumentUrl, 
                })
                .ToListAsync();

            return meetingMaterials;
        }
    }
}
