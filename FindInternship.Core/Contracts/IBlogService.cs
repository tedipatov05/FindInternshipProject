﻿using FindInternship.Core.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IBlogService
    {
        Task<List<PostViewModel>> GetAllPostAsync(int skipCount);

        Task<List<string>> GetAllPostPhotosAsync(string postId);
        Task CreatePostAsync(CreatePostFormModel model, string companyId);
        Task<bool> IsPostExistById(string postId);
        Task<PostViewModel> GetPostAsync(string postId);

        Task<int> AllPostsCountAsync();

	}
}
