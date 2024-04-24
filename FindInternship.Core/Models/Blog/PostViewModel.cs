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
        public PostViewModel()
        {
            CarouselPhotosUrls = new List<string>();
        }
        public string Id { get; set; } = null!;
        public string Topic { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string CompanyName { get; set; } = null!;
        public string CompanyProfilePictureUrl { get; set; } = null!;
        public string HeadImageUrl { get; set; } = null!;
        public List<string> CarouselPhotosUrls { get; set; } 
    }
}
