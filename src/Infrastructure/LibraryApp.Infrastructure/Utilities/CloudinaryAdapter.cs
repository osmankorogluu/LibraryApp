using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Utilities
{
    public static class CloudinaryAdapter
    {
        public static string UploadPhoto(IFormFile file)
        {
            string picture;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                picture = Convert.ToBase64String(fileBytes);
            }
            Account account = new Account(
   "dj9hfdfcb",
   "592155627566213",
   "tLuve4MF_gThYoC7Isxx62wcgtg");

            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription($@"data:image/png;base64,{picture}"),
                Transformation = new Transformation().Width(1280).Height(720).Crop("fill")
            };
            var result = cloudinary.Upload(uploadParams);
            return result.Url.ToString();
        }
    }
}
