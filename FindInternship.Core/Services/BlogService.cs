using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Blog;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class BlogService : IBlogService
    {
        private IRepository repo;
        private readonly IImageService imageService;

        public BlogService(IRepository repo, IImageService imageService)
        {
            this.repo = repo;
            this.imageService = imageService;
        }

		

		public async Task CreatePostAsync(CreatePostFormModel model, string companyId)
        {
            var post = new Post()
            {
                CompanyId = companyId,
                Topic = model.Topic,
                Content = model.Content,
                CreatedOn = model.CreatedOn
            };

            var photos = new List<Photo>();

            foreach(var image in model.CarouselPhotos)
            {
                var photo = new Photo();
                photo.PhotoUrl = await imageService.UploadImageAsync(image, "projectImages", image.FileName);
                photo.PostId = post.Id;
                photos.Add(photo);


            }

            await repo.AddRangeAsync(photos);
            await repo.AddAsync(post);
            await repo.SaveChangesAsync();
        }

        public async Task<PostViewModel> GetPostAsync(string postId)
        {
            var post = await repo.All<Post>()
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Topic = p.Topic,
                    Content = p.Content,
                    CreatedOn = p.CreatedOn,
                    CompanyName = p.Company.User.Name,
                    CompanyProfilePictureUrl = p.Company.User.ProfilePictureUrl

                })
                 .FirstOrDefaultAsync(p => p.Id == postId);

			post.CarouselPhotosUrls = await GetAllPostPhotosAsync(post.Id);

			return post;
		}

        public async Task<List<PostViewModel>> GetAllPostAsync(int skipCount)
        {
            var posts = await repo.All<Post>()
                .Skip(skipCount)
                .Take(8)
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Topic = p.Topic,
                    Content = p.Content,
                    CreatedOn = p.CreatedOn,
                    CompanyName = p.Company.User.Name,
                    CompanyProfilePictureUrl = p.Company.User.ProfilePictureUrl,
                })
                .OrderByDescending(p => p.CreatedOn)
                .ToListAsync();

            foreach(var post in posts)
            {
                post.CarouselPhotosUrls = await GetAllPostPhotosAsync(post.Id);
                post.HeadImageUrl = post.CarouselPhotosUrls.FirstOrDefault()!;

            }

            return posts;
        }

        public async Task<List<string>> GetAllPostPhotosAsync(string postId)
        {
            var urls = await repo.All<Photo>()
                .Where(pp => pp.PostId == postId)
                .Select(pp => pp.PhotoUrl)
                .ToListAsync();

            return urls;

        }

        public async Task<bool> IsPostExistById(string postId)
        {
            bool result = await repo.All<Post>().AnyAsync(p => p.Id == postId);
            return result;
        }

        public async Task<int> AllPostsCountAsync()
        {
            var count = await repo.All<Post>().CountAsync();

            return count;
        }
    }
}
