using FindInternship.Core.Models.Lector;
using FindInternship.Core.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Meeting
{
    public class DetailsMeetingViewModel
    {
        public DetailsMeetingViewModel()
        {
            this.Materials = new HashSet<MaterialViewModel>();
        }
        public string Id { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Class {  get; set; } = null!;

        public LectorDetailsMeetingViewModel Lector { get; set; } = null!;

        public ICollection<MaterialViewModel> Materials { get; set; }
    }
}
