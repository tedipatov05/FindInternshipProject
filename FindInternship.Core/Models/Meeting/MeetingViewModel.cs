using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Meeting
{
    public class MeetingViewModel
    {
        public string Id { get; set; } = null!;
        public string? Title { get; set; } 

        public string? Address { get; set; } 

        public string Day { get; set; } = null!;
        public int Number {  get; set; }

        public string? StartHour { get; set; } 

        public string? EndHour { get; set; }

        public string? Class { get; set; }

        //public string? CompanyId { get; set; }

        //public string? ClassId { get; set; }

    }
}
