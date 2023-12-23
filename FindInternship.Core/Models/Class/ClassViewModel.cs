using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models
{
    public class ClassViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string School { get; set; } = null!;

        public string Teacher { get; set; } = null!;

        public int Students { get; set; } = 0;

		public string TeacherId { get; set; } = null!;
	}
}
