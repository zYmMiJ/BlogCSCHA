﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Blog.Models;
using Blog.Models.Comments;
using Microsoft.EntityFrameworkCore;
using Blog.ViewModels;

namespace Blog.Data.Repository
{
    public class Repository : IRepository
    {
        private AppdbContext _ctx;

        public Repository(AppdbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);

        }

        public List<Post> GetAllPosts()
        {
            return _ctx.Posts.ToList();
        }


        public IndexViewModel GetAllPosts(int pageNumber, string category, string search)
        {
            Func<Post, bool> InCategory = (post) => { return post.Category.ToLower().Equals(category.ToLower()); };
            int pageSize = 3;

            int skipAmount = pageSize * (pageNumber - 1);

            var query = _ctx.Posts.AsQueryable();

            if (!String.IsNullOrEmpty(category))
            {
                query = query.Where(c => InCategory(c));
            }
            //Condition de recherche permet de voir si le string search récuperé en parametre contient un tite ou un body ou une description
            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Title.Contains(search) 
                                    || x.Body.Contains(search) 
                                    || x.Tags.Contains(search)
                                    || x.Description.Contains(search));
            }

            int postsCount = query.Count();
            int pageCount = (int)Math.Ceiling((double)postsCount/ pageSize);
            return new IndexViewModel
            {
                PageNumber = pageNumber,
                PageCount = pageCount,
                NextPage = postsCount > skipAmount + pageSize,
                Pages = PageNumbers(pageNumber, pageCount).ToList(),
                Category = category,
                Posts = query
                .Skip(skipAmount)
                .Take(pageSize)
                .ToList()
            };
        }

        private IEnumerable<int> PageNumbers(int pageNumber, int pageCount)
        {
            if ( pageCount <= 5)
            {
                for (int i = 1 ; i <= pageCount; i++)
                {
                    yield return i;
                }
            }
            else
            {

                int midPoint = pageNumber;
                if (midPoint < 3)
                {
                    midPoint = 3;
                }
                else if (midPoint > pageCount - 2)
                {
                    midPoint = pageCount - 2;
                }

                int lowerBound = midPoint - 2;
                int upperBound = midPoint + 2;

                if (lowerBound != 1)
                {
                    yield return 1;
                    if (lowerBound -1 > 1)
                    {
                        yield return -1;
                    }
                }

                for (int i = midPoint - 2; i <= upperBound; i++)
                {
                    yield return i;
                }

                if (upperBound != pageCount)
                {
                    if ( pageCount - upperBound  > 1 )
                    {
                        yield return -1;
                    }
                    yield return pageCount;
                }
            }
        }
        public Post GetPost(int id)
        {
            return _ctx.Posts
                .Include(p => p.MainComments)
                    .ThenInclude(mc => mc.SubComments)
                .FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            _ctx.Posts.Remove(GetPost(id));
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
           if ( await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void AddSubComment(SubComment comment)
        {
            _ctx.SubComments.Add(comment);
        }
        public MainComment GetMainComment(int id)
        {
            return _ctx.MainComments
                .FirstOrDefault(p => p.Id == id); ;
        }

        public void RemoveMainComments(int id)
        {
            _ctx.MainComments.Remove(GetMainComment(id));
        }

        public SubComment GetSubComment(int id)
        {
            return _ctx.SubComments
                .FirstOrDefault(p => p.Id == id); ;
        }

        public void RemoveSubComments(int id)
        {
            _ctx.SubComments.Remove(GetSubComment(id));
        }
    }
}
