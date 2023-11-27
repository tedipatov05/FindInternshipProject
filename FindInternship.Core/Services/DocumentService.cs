using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FindInternship.Core.Contracts;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.AspNetCore.Http;
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

        public async Task<string> UploadDocumentAsync(IFormFile file, string folder ,Document document)
        {
            using var stream = file.OpenReadStream();

            var uploadParams = new RawUploadParams()
            {
                File = new FileDescription(document.Id, stream),
                Folder = folder
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            if(uploadResult.Error != null) 
            {
                throw new InvalidOperationException(uploadResult.Error.Message);
            }

            return uploadResult.Url.ToString();


            
        }
    }
}
