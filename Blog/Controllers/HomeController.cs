using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Data.FileManager;
using Blog.Data.Repository;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public HomeController(IRepository ctx, IFileManager fileManager)
        {
            _repo = ctx;
            _fileManager = fileManager;
        }

        public IActionResult Index(int pageNumber, string category)
        {
            if (pageNumber < 1)
                return RedirectToAction("Index", new { pageNumber = 1, category });

            var vm = _repo.GetAllPosts(pageNumber, category);
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
    }
}
