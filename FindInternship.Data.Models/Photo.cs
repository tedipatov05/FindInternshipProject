using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models
{
    public class Photo
    {
        public Photo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }
        public string PhotoUrl { get; set; } = null!;

        [ForeignKey(nameof(Post))]
        public string PostId { get; set; }

        public Post Post { get; set; }
    }
}
