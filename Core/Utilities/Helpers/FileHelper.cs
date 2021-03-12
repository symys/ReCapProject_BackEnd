using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var imagePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var result = NewPath(file);
            File.Move(imagePath, result);
            return result;
        }

        public static string NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\WebAPI\Images");
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            var result = $@"{path}\{newPath}";
            return result;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }

        public static string Update(string imagePath, IFormFile file)
        {
            var result = NewPath(file).ToString();
            if (imagePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(imagePath);
            return result;
        }
    }
}
