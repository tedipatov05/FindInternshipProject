using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Profile
{
    public class CompanyProfileViewModel : BaseProfileViewModel
    {
        public string Description { get; set; } = null!;

        public string Services { get; set; } = null!;

        public List<string> Technologies { get; set; } = new List<string>();

        // TODO: Add company meeting for classes in internship
    }
}
