using FindInternship.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IImageService
    {
        
        Task<string> UploadImage(IFormFile imageFile, string nameFolder, User user);

        Task<string> UploadImageToLectorAsync(IFormFile imageFile, string folderName, string name);
    }
}
