using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Company
{
    public class CompanyViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? ProfilePictureUrl { get; set; }

        public string Address { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
