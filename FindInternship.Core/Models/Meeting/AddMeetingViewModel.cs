using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Meeting
{
    public class AddMeetingViewModel
    {
        public string Title { get; set; }

        public string Address { get; set; }

        public DateTime Start {  get; set; }

        public DateTime End { get; set; }


    }
}
