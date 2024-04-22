using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Blog
{
    public class PostViewModel
    {
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; } 
        public string HeadImageUrl { get; set; }
        public List<string> CarouselPhotosUrls { get;set; }
    }
}
