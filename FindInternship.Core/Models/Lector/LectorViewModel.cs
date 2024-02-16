using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Lector
{
    public class LectorViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ProfilePicturUrl { get; set; } = null!;
    }
}
