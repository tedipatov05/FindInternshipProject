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
            this.PostsPhotos = new HashSet<PostsPhotos>();
        }

        [Key]
        public string Id { get; set; }
        public string PhotoUrl { get; set; } = null!;
        public ICollection<PostsPhotos> PostsPhotos { get; set; }
    }
}
