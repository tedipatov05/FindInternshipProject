using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Profile
{
    public class StudentProfileViewModel : BaseProfileViewModel
    {
        
        public string Class { get; set; } = null!;
        public List<string> Abilities { get; set; } = new List<string>();



    }
}
