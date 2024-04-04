using FindInternship.Core.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Teacher
{
    public class CompanyInternGroupViewModel
    {
        public CompanyInternGroupViewModel()
        {
            this.Interns = new List<StudentInternViewModel>();
        }
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public List<StudentInternViewModel> Interns { get; set; }
    }
}
