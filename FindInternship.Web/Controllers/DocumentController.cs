using FindInternship.Core.Contracts;
using FindInternship.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FindInternship.Web.Controllers
{
    public class DocumentController : Controller
    {
        private IRepository repo;
        private IDocumentService documentService;
        private ITeacherService teacherService;

        public DocumentController(IRepository repo, IDocumentService documentService, ITeacherService teacherService)
        {
            this.repo = repo;
            this.documentService = documentService;
            this.teacherService = teacherService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocuments(List<IFormFile> files, string teacherId)
        {
            return RedirectToAction("CompanyRequests", "Request");
        }
        
    }
}
