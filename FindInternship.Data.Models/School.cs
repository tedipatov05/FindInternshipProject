using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FindInternship.Common.ModelValidationConstants.ClassConstants;


namespace FindInternship.Data.Models
{
    public class School
    {
        public School()
        {
            this.Classes = new HashSet<Class>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(SchoolMaxLength)]
        public string Name { get; set; } = null!;

        public string City { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}
