using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models
{
    public class PostsPhotos
    {
        public string Id { get; set; }

        [ForeignKey(nameof(Photo))]
        public string PhotoId { get; set; }
        public Photo Photo { get; set; }

        [ForeignKey(nameof(Post))]
        public string PostId { get; set; }
        public Post Post { get; set; }
    }
}
