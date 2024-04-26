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
                return new JsonResult(new {isCompany = false});
            }

            var model = new CreatePostFormModel()
            {
                Topic = topic,
                Content = content,
                CreatedOn = DateTime.Now,
                CarouselPhotos = photos.ToList(),
            };

            await blogService.CreatePostAsync(model, companyId);

            return new JsonResult(new { isCompany = true, model });
        }

        public async Task<IActionResult> BlogHome(int skipCount = 0)
        {
            var posts = await blogService.GetAllPostAsync(skipCount);
            var totalPostsCount = await blogService.AllPostsCountAsync();

            var model = new BlogViewModel()
            {
                Posts = posts,
                PagesCount = totalPostsCount % 8 != 0 ? totalPostsCount / 8 + 1 : totalPostsCount / 8, 
                SkipCount = skipCount
            };

            return View(model);
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
            model.Posts = await blogService.GetAllPostAsync(0);

            return View(model);
        }
    }
}
