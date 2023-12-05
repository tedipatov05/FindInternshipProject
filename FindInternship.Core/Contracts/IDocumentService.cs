using FindInternship.Core.Models.Document;
using FindInternship.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IDocumentService
    {
        Task<string> UploadDocumentAsync(IFormFile file, string folder);
        Task<string> Create(string documentUrl, string classId, string documentName);
        Task<bool> IsDocumentAsync(string name);

        Task<List<DocumentViewModel>> GetDocumentsAsync(HashSet<string> documentsIds);
    }
}
