using FindInternship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Profile
{
    public class TeacherProfileViewModel : BaseProfileViewModel
    {
        public string Class { get; set; } = null!;

        public List<string> StudentsNames { get; set; } = new List<string>();
    }
}
