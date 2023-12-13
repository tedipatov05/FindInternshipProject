using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Meeting
{
    public class MeetingViewModel
    {
        public string Title { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Day { get; set; } = null!;
        public int Number {  get; set; }

        public string StartHour { get; set; } = null!;

        public string EndHour { get; set; } = null!;

        //public string? CompanyId { get; set; }

        //public string? ClassId { get; set; }

    }
}
