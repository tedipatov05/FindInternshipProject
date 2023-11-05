using FindInternship.Data.Models.Enums;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Company
{
	public class CompanyQueryModel
	{

		public string SearchString { get; set; } = null!;

		public string City { get; set; } = null!;

		public AbilityEnum Technology { get; set; }

		public ICollection<CompanyViewModel> Companies { get; set; }

		public CompanyQueryModel()
		{
			Companies = new HashSet<CompanyViewModel>();
		}
	}
}
