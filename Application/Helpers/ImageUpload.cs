using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class ImageUpload
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpeg", ".jpg", ".png", ".gif" };
        public static long MaxFileSize => 2000000;
        public async Task<string> uploadImage(IFormFile image)
        {
            if (image == null)
                return null;
      
            var ext = Path.GetExtension(image.FileName);
            if (!AllowedExtensions.Contains(ext))
                throw new ImageExtensionNotAllowedException();

            if (image.Length > MaxFileSize)
                throw new ImageFileSizeNotAllowedException(image.Length);

            var newFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);
            await image.CopyToAsync(new FileStream(filePath, FileMode.Create));

            return newFileName;
        }
    }
}
