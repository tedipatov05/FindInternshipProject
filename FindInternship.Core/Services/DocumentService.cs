using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FindInternship.Core.Contracts;
using FindInternship.Core.Models;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class DocumentService : IDocumentService
    {
        private Cloudinary cloudinary;
        private IRepository repo;

        public DocumentService(Cloudinary cloudinary, IRepository repo)
        {
            this.cloudinary = cloudinary;
            this.repo = repo;
        }

        public async Task<string> UploadDocumentAsync(IFormFile file, string folder)
        {
            using var stream = file.OpenReadStream();

            var uploadParams = new RawUploadParams()
            {
                File = new FileDescription(file.Name, stream),
                Folder = folder
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            if(uploadResult.Error != null) 
            {
                throw new InvalidOperationException(uploadResult.Error.Message);
            }

            return uploadResult.Url.ToString();

        }

        public async Task<string> Create(string documentUrl, string classId, string documentName)
        {
            Document document = new Document()
            {
                Type = documentName,
                DocumentUrl = documentUrl,
                ClassId = classId

            };

            await repo.AddAsync(document);
            await repo.SaveChangesAsync();

            return document.Id;
            
        }

        public async Task<List<DocumentViewModel>> GetDocumentsAsync(HashSet<string> documentsIds)
        {
            var documents = await repo.All<Document>()
                .Where(d => documentsIds.Contains(d.Id))
                .Select(d => new DocumentViewModel()
                {
                    Type = d.Type,
                    Url = d.DocumentUrl
                })
                .ToListAsync();

            return documents;
        }
    }
}
