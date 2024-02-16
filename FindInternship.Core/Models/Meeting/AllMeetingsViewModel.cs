using FindInternship.Core.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Meeting
{
    public class AllMeetingsViewModel
    {

        public ICollection<MeetingViewModel> DayNow { get; set; } = new HashSet<MeetingViewModel>();
        public ICollection<MeetingViewModel> DayTomorrow { get; set; } = new HashSet<MeetingViewModel>();
        public ICollection<MeetingViewModel> Day2 { get; set; } = new HashSet<MeetingViewModel>();
        public ICollection<MeetingViewModel> Day3 { get; set; } = new HashSet<MeetingViewModel>();
        public ICollection<MeetingViewModel> Day4 { get; set; } = new HashSet<MeetingViewModel>();

        public string? ClassId { get; set; }

        public int Days { get; set; } = 0;

        public string Month { get; set; } = null!;

        public ICollection<ClassMeetingViewModel> CompanyClasses { get; set; } = new HashSet<ClassMeetingViewModel>();



    }
}
