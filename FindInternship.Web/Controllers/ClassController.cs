using FindInternship.Common;
using FindInternship.Core.Models.Company;
using FindInternship.Core.Services;
using FindInternship.Data.Models;
using Microsoft.AspNetCore.Mvc;
using FindInternship.Core.Contracts;
using FindInternship.Web.Extensions;


using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{
	public class ClassController : Controller
	{
		private readonly IClassService classService;
		private readonly ICompanyService companyService;

		public ClassController(IClassService classService, ICompanyService companyService)
		{
			this.classService = classService;
			this.companyService = companyService;
		}

		public async Task<IActionResult> CompanyClasses()
		{

			string userId = User.GetId()!;
			string companyId = await companyService.GetCompanyIdAsync(userId);

			bool IsCompany = await companyService.IsCompanyAsync(userId);
			if (!IsCompany)
			{
				TempData[ErrorMessage] = "Трябва да бъдете фирма за да достъпите класовете";
				return RedirectToAction("Index", "Home");
			}

			var classes = await classService.GetAllCompanyClassesAsync(companyId);

			return View(classes);

		}
	}
}
