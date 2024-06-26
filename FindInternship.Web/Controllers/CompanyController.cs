﻿using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Company;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly ITeacherService teacherService;
        private readonly IAbilityService abilityService;

        public CompanyController(ICompanyService companyService, ITeacherService teacherService, IAbilityService abilityService)
        {
            this.companyService = companyService;
            this.teacherService = teacherService;
            this.abilityService = abilityService;
        }


        public async Task<IActionResult> All([FromQuery]CompanyQueryModel model)
        {
            string userId = User.GetId()!;

            bool IsTeacher = await teacherService.IsTeacherAsync(userId);
            if(!IsTeacher) 
            {
                TempData[ErrorMessage] = "Трябва да бъдете учител за да достъпите всички фирми";
                return RedirectToAction("Index", "Home");
            }

            model.Companies = await companyService.GetAllCompaniesAsync(model);
            model.Technologies = await abilityService.AllAbilityNamesAsync();
            
            return View(model);
        }

        public async Task<IActionResult> CompanyInterns(string companyInternId)
        {
            bool isCompanyExists = await companyService.IsCompanyInternExistsByIdAsync(companyInternId);
            if(!isCompanyExists)
            {
                TempData[ErrorMessage] = "Тази фирма не съществува";
                return RedirectToAction("Index", "Home");
            }

            var model = await companyService.GetCompanyInternsAsync(companyInternId);

            return View(model);


        }

        
    }
}
