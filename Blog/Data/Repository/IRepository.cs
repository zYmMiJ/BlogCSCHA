﻿using Blog.Models;
using Blog.Models.Comments;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        MainComment GetMainComment(int id);
        SubComment GetSubComment(int id);
        List<Post> GetAllPosts();
        IndexViewModel GetAllPosts(int pageNumber, string Category, string search);

        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        void RemoveMainComments(int id);
        void RemoveSubComments(int id);
        void AddSubComment(SubComment comment);

        Task<bool> SaveChangesAsync();
    }
}
