﻿using FindInternship.Core.Contracts;
using FindInternship.Data.Models;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using static FindInternship.Common.NotificationConstants;


namespace FindInternship.Web.Controllers
{
    public class DocumentController : Controller
    {
       
        private IDocumentService documentService;
        private ITeacherService teacherService;
        private ICompanyService companyService;
        private IClassService classService;
        private IRequestService requestService;

        public DocumentController(IDocumentService documentService, ITeacherService teacherService, ICompanyService companyService, IClassService classService, IRequestService requestService)
        {
           
            this.documentService = documentService;
            this.teacherService = teacherService;
            this.companyService = companyService;
            this.classService = classService;
            this.requestService = requestService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IList<IFormFile> files, string requestId)
        {
            string userId = User.GetId()!;
            bool isCompany = await companyService.IsCompanyAsync(userId);

            if(!isCompany)
            {
                TempData[ErrorMessage] = "Трябва да си фирма, за да качваш файлове";
                return RedirectToAction("ClassRequests", "Request");
            }

            bool isRequestExists = await requestService.IsRequestExistsByIdAsync(requestId);
            if (requestId == null || !isRequestExists)
            {
                return new JsonResult(new { IsRequestExists = false });
            }

            HashSet<string> documentsIds = new HashSet<string>();

            string? classId = await classService.GetClassIdAsync(requestId);
            string? teacherUserId = await teacherService.GetTeacherUserIdByClassAsync(classId!);

            try
            {
               
                foreach (var file in files)
                {
                    string url = await documentService.UploadDocumentAsync(file, "projectDocuments");
                    string id = await documentService.Create(url, requestId, file.FileName);
                    documentsIds.Add(id);
                }

            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("CompanyRequests", "Request");
            }


            return new JsonResult(new { Documents = documentsIds, Receiver = teacherUserId, RequestId = requestId, IsRequestExists = true});
            
        }

    }
}
