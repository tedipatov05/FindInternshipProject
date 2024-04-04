using FindInternship.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Student
{
    public class ChooseStudentViewModel
    {
        public ChooseStudentViewModel()
        {
            this.Users = new HashSet<UserViewModel>();
        }
        public string? SearchString { get; set; }

        public string ClassId { get; set; } = null!;

        public string RequestId { get; set; } = null!;

        public ICollection<UserViewModel> Users { get; set; }
    }
}
