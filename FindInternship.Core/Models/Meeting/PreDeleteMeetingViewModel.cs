using FindInternship.Core.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Meeting
{
    public class PreDeleteMeetingViewModel
    {
        public PreDeleteMeetingViewModel()
        {
            this.Materials = new HashSet<MaterialViewModel>();
        }
        public string Title { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Description { get; set; } = null!;

        public string Lector { get; set; } = null!;
        public ICollection<MaterialViewModel> Materials { get; set; }


    }
}
