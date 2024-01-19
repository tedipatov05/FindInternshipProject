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
        public CompanyQueryModel()
        {
            Companies = new List<CompanyViewModel>();
        }

        public string? SearchString { get; set; }
		public string Technology { get; set; }

		public List<string> Technologies { get; set; }

		public List<CompanyViewModel> Companies { get; set; }

		
	}
}
