using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models
{
    public class Post
    {

        public Post()
        {
            this.Id = new Guid().ToString();
        }
        [Key]
        public string Id { get; set; } = null!;

        public string Topic { get;set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedOn { get; set; } 

        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; } = null!;
        public Company Company { get; set; } = null!;
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
        public ICollection<PostsPhotos> PostsPhotos { get; set;}
    }
}
