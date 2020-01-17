using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.FileManager
{
    public class FileManager : IFileManager
    {
        private string _imagePath;

        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Images"]; 
        }
        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
        }
        public async Task<string> SaveImage(IFormFile image)
        {
            try { 
            //Permet d'avoir un path dynamique et non en dur
            var save_path = Path.Combine(_imagePath);
            
            if (!Directory.Exists(_imagePath))
            {
                Directory.CreateDirectory(save_path);
            }
            // Internet explorer genère une erreur  C:/User/Foo/image.jpg
            //var fileName = image.FileName;
            

            //Permet d'avoir le type de l'image
            var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));

            //Permet de rename le file en y ajoutant la date et retire aussi les espaces
            var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";

            using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return fileName;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                    return "Error";
                
            }
        }
    }
}
