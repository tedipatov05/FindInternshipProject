using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Blog
{
    public class BlogViewModel
    {
        public BlogViewModel()
        {
            this.Posts = new List<PostViewModel>();
            this.PostsPerPage = 8;
        }

        public List<PostViewModel> Posts { get; set; }

        public int PagesCount { get; set; }

        public int PostsPerPage { get; set; }


    }
}
