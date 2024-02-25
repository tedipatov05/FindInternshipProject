using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Meeting
{
    public class FormMeetingViewModel
    {
        public string Title { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime Start {  get; set; }

        public DateTime End { get; set; }

        public string? ClassId { get; set; }


    }
}
