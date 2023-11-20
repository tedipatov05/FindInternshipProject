using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Request
{
    public class AllRequestsViewModel
    {
        public string Id { get; set; }

        public string Topic { get; set; } = null!;

        public string? Message { get; set; }

        public string Status { get; set; } = null!;

        public string DateCreated { get; set; } = null!;
    }
}
