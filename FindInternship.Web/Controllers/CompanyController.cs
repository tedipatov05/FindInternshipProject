﻿using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Company;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyService companyService;
        private ITeacherService teacherService;

        public CompanyController(ICompanyService companyService, ITeacherService teacherService)
        {
            this.companyService = companyService;
            this.teacherService = teacherService;
        }

        public async Task<IActionResult> All([FromQuery]CompanyQueryModel model)
        {
            string userId = User.GetId();

            bool IsTeacher = await teacherService.IsTeacherAsync(userId);
            if(!IsTeacher) 
            {
                TempData[ErrorMessage] = "You should be a teacher to see all companies";
                return RedirectToAction("Index");
            }

            model.Companies = await companyService.GetAllCompaniesAsync(model);
            
            return View(model);
        }
    }
}
