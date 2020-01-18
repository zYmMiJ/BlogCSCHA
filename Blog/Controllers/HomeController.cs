using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Data.FileManager;
using Blog.Data.Repository;
using Blog.Models;
using Blog.Models.Comments;
using Blog.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;
        private UserManager<IdentityUser> _userManager;

        public HomeController(IRepository ctx, IFileManager fileManager)
        {
            _repo = ctx;
            _fileManager = fileManager;
        }

        public IActionResult Index(int pageNumber, string category, string search)
        {
            if (pageNumber < 1)
                return RedirectToAction("Index", new { pageNumber = 1, category });

            var vm = _repo.GetAllPosts(pageNumber, category, search);
            return View(vm);
        }

        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }
        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.')+1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
        
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel vm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Post", new { id = vm.PostId });


            var userName = this.User.Identity.Name;
            var post = _repo.GetPost(vm.PostId);
            if (vm.MainCommentId == 0)
            {

                post.MainComments = post.MainComments ?? new List<MainComment>();

                post.MainComments.Add(new MainComment
                {
                    Message =userName+": "+vm.Message,
                    Created = DateTime.Now,

                });
                _repo.UpdatePost(post);
            }
            else
            {
                var comment = new SubComment
                {
                    MainCommentId = vm.MainCommentId,
                    Message = userName + ": " + vm.Message,
                    Created = DateTime.Now,
                };
                _repo.AddSubComment(comment);
            }

            await _repo.SaveChangesAsync();

            return RedirectToAction("Post", new { id = vm.PostId });
        }
        [HttpGet]
        public async Task<IActionResult> RemoveComment(int id, int idPost)
        {
            _repo.RemoveMainComments(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Post", new { id = idPost });
        }

        [HttpGet]
        public async Task<IActionResult> RemoveSubComment(int id, int idPost)
        {
            _repo.RemoveSubComments(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Post", new { id = idPost });
        }
    }
}

