using FindInternship.Core.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Teacher
{
    public class TeacherStudentsViewModel
    {
        public string Id { get; set; } = null!;

        public string Class { get; set; } = null!;

        public string ClassSpeciality { get; set; } = null!;

        public string School { get; set; } = null!;

        public List<StudentViewModel> Students { get; set; } = new List<StudentViewModel>();
    }
}
