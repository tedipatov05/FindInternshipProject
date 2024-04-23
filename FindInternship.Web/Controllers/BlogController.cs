using FindInternship.Core.Contracts;
using FindInternship.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindInternship.Web.Controllers
{
    public class BlogController : Controller
    {
        IBlogService blogService ;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public async Task<IActionResult> BlogHome()
        {
            var posts = await blogService.GetAllPostAsync();

            return View(posts);
        }
    }
}
