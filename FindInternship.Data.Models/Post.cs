using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.PostConstants;

namespace FindInternship.Data.Models
{
    public class Post
    {

        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PostsPhotos = new HashSet<PostsPhotos>();
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public string Id { get; set; } = null!;

        [MaxLength(PostTopicMaxLength)]
        public string Topic { get;set; } = null!;

        [MaxLength(PostContentMaxLength)]
        public string Content { get; set; } = null!;
        public DateTime CreatedOn { get; set; } 

        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; } = null!;
        public Company Company { get; set; } = null!;
        public ICollection<PostsPhotos> PostsPhotos { get; set;}
    }
}
