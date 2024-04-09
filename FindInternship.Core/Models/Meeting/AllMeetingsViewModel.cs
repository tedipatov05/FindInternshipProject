using FindInternship.Core.Models.Class;
using FindInternship.Core.Models.CompanyInterns;
using FindInternship.Core.Models.Lector;
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
        public ICollection<MeetingViewModel> Day5 { get; set; } = new HashSet<MeetingViewModel>();
        public ICollection<MeetingViewModel> Day6 { get; set; } = new HashSet<MeetingViewModel>();

        public string? GroupId { get; set; }

        public int Days { get; set; } = 0;

        public string Month { get; set; } = null!;

        public ICollection<CompanyInternsViewModel> CompanyClasses { get; set; } = new HashSet<CompanyInternsViewModel>();

        public ICollection<LectorMeetingViewModel> CompanyLectors { get; set; } = new HashSet<LectorMeetingViewModel>();



    }
}
