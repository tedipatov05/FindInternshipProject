using FindInternship.Core.Contracts;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using static FindInternship.Common.NotificationConstants;


namespace FindInternship.Web.Controllers
{
    public class DocumentController : Controller
    {
       
        private IDocumentService documentService;
        private ITeacherService teacherService;
        private ICompanyService companyService;
        private IClassService classService;

        public DocumentController(IDocumentService documentService, ITeacherService teacherService, ICompanyService companyService, IClassService classService)
        {
           
            this.documentService = documentService;
            this.teacherService = teacherService;
            this.companyService = companyService;
            this.classService = classService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IList<IFormFile> files, string requestId)
        {
            string userId = User.GetId();
            bool isCompany = await companyService.IsCompanyAsync(userId);

            if(!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма, за да качваш файлове";
                return RedirectToAction("Request", "CompanyRequests");
            }

            HashSet<string> documentsIds = new HashSet<string>();


            string teacherId = null;

			try
            {
                string classId = await classService.GetClassIdAsync(requestId);
                teacherId = await teacherService.GetTeacherIdByClassAsync(classId);
                foreach (var file in files)
                {
                    string url = await documentService.UploadDocumentAsync(file, "projectDocuments");
                    string id = await documentService.Create(url, classId, file.FileName);
                    documentsIds.Add(id);
                }

            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("CompanyRequests", "Request");
            }


            return new JsonResult(new { Documents = documentsIds, Receiver = teacherId, RequestId = requestId});
            
        }
        
    }
}
