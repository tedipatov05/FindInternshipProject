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
    public class ImageService : IImageService
    {
        private readonly Cloudinary cloudinary;
        private readonly IRepository repo;

        public ImageService(
            Cloudinary cloudinary,
            IRepository _repo)
        {
            this.cloudinary = cloudinary;
            repo = _repo;
        }
        public async Task<string> UploadImage(IFormFile imageFile, string nameFolder, User user)
        {

            using var stream = imageFile.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(user.Id, stream),
                Folder = nameFolder
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new InvalidOperationException(uploadResult.Error.Message);
            }

            user.ProfilePictureUrl = uploadResult.SecureUrl.ToString();

            this.repo.Update(user);

            await repo.SaveChangesAsync();

            return user.ProfilePictureUrl;
        }

        public async Task<string> UploadImageAsync(IFormFile imageFile, string folderName, string name)
        {
            using var stream = imageFile.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name ,stream),
                Folder = folderName
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new InvalidOperationException(uploadResult.Error.Message);
            }

            return uploadResult.SecureUrl.ToString();
        }
    }
}
