using FindInternship.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FindInternship.Web.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        public async Task<IActionResult> All()
        {
            var companies = await companyService.GetAllCompaniesAsync();
            return View(companies);
        }
    }
}
