using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Company
{
    public class CompanyClassesViewModel
    {
        public List<ClassViewModel> CompanyClasses { get; set; }

        public CompanyClassesViewModel()
        {
            CompanyClasses = new();
        }
    }
}
