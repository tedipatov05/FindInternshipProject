using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Blog;
using FindInternship.Core.Services;
using FindInternship.Data.Models;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blogService ;
		private readonly IUserService userService;
		private readonly ICompanyService companyService ;

		public BlogController(IBlogService blogService, IUserService userService, ICompanyService companyService)
		{
			this.blogService = blogService;
			this.userService = userService;
			this.companyService = companyService;
		}


        [HttpPost]
        [Route("Blog/CreatePost")]
        public async Task<IActionResult> CreatePost(string topic, string content, List<IFormFile> photos)
        {
            string userId = User.GetId();

            string? companyId = await companyService.GetCompanyIdAsync(userId);

            if(companyId == null)
            {

            }

            var model = new CreatePostFormModel()
            {
                Topic = topic,
                Content = content,
                CreatedOn = DateTime.Now,
                HeadImage = photos[0],
                CarouselPhotos = photos.Skip(1).ToList(),
            };

            await blogService.CreatePostAsync(model, companyId);

            return new JsonResult(new { model});
        }

        public async Task<IActionResult> BlogHome()
        {
            var posts = await blogService.GetAllPostAsync();

            return View(posts);
        }

        public async Task<IActionResult> PostDetails(string postId)
        {
            bool exist = await blogService.IsPostExistById(postId);
            if(!exist)
            {
                TempData[ErrorMessage] = "Този пост не съществува.";
                return RedirectToAction("BlogHome");
            }

            var model = await blogService.GetPostAsync(postId);
            model.Posts = await blogService.GetAllPostAsync();

            return View(model);
        }
    }
}
