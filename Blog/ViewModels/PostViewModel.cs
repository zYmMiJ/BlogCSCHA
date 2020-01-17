using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string CurrentImage { get; set; } = "";
        //IformFile = Interface pour n'importe quel file video image etc...
        public IFormFile Image { get; set; } = null;

        public string Description { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Category { get; set; } = "";

    }
}
