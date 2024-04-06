using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Student
{
    public class StudentInternViewModel
    {
        public string Id { get; set; } = null!;

        public string? ProfilePictureUrl { get; set; }

        public string Name { get; set; } = null!;

        public string School { get; set; } = null!;


        public List<string> Abilities { get; set; } = new List<string>();
    }
}
