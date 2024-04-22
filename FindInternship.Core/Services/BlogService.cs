﻿using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Blog;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
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

        public BlogService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task CreatePost(PostViewModel model, string companyId)
        {
            var post = new Post()
            {
                CompanyId = companyId,
                Topic = model.Topic,
                Content = model.Content,
                CreatedOn = model.CreatedOn
            };

            await repo.AddAsync(post);
            await repo.SaveChangesAsync();
        }

        public async Task<List<PostViewModel>> GetAllPostAsync()
        {
            var posts = await repo.All<Post>()
                .Select(p => new PostViewModel()
                {
                    Topic = p.Topic,
                    Content = p.Content,
                    CreatedOn = p.CreatedOn,
                    //CarouselPhotosUrls = GetAllPostPhotosAsync(p.Id)
                })
                .ToListAsync();

            return posts;
        }

        public async Task<List<string>> GetAllPostPhotosAsync(string postId)
        {
            var urls = await repo.All<PostsPhotos>()
                .Where(pp => pp.PostId == postId)
                .Select(pp => pp.Photo.PhotoUrl)
                .ToListAsync();

            return urls;

        }
    }
}
