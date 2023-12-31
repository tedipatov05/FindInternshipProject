using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Models.Lector;

namespace FindInternship.Core.Models.Profile
{
    public class CompanyProfileViewModel : BaseProfileViewModel
    {
        public string Description { get; set; } = null!;

        public string Services { get; set; } = null!;

        public List<string> Technologies { get; set; } = new List<string>();

        public List<LectorViewModel> Lectors { get; set; } = new List<LectorViewModel>();
    }
}
