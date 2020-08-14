using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Template.Default.Helper
{
    public static class PhotoHelper
    {
        private static string _basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ProductPhotos");
        public static void SavePhoto(Guid name, string photo)
        {
            var photoByteArray = Convert.FromBase64String(photo);
            var path = Path.Combine(_basePath, string.Concat(name.ToString(), ".jpg"));

            if (File.Exists(path))
            {
                byte[] oldImage = File.ReadAllBytes(path);

                if (oldImage != photoByteArray)
                    File.Delete(path);
                else return;
            }

            File.WriteAllBytes(path, photoByteArray);

        }

        public static void DeletePhoto(Guid name)
        {
            var path = Path.Combine(_basePath, string.Concat(name.ToString(), ".jpg"));

            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
