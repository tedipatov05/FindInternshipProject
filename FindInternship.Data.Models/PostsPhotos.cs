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

        [ForeignKey(nameof(Photo))]
        public string PhotoId { get; set; } = null!;
        public Photo Photo { get; set; } = null!;

        [ForeignKey(nameof(Post))]
        public string PostId { get; set; } = null!;
        public Post Post { get; set; } = null!;
    }
}
