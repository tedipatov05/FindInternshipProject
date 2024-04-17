using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models
{
    public class Photo
    {
        public Photo()
        {
            this.Id = new Guid().ToString();
        }
        [Key]
        public string Id { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PostsPhotos> PostsPhotos { get; set; }
    }
}
