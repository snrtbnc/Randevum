using System.IO;
using Microsoft.AspNetCore.Http;

namespace RandevumAPI.Helpers
{
    public static class ImageHelper
    {
        public static bool IsImage (this IFormFile postedFile)
        {
            if (postedFile.ContentType.ToLower () != "image/jpg" && postedFile.ContentType.ToLower () != "image/png")
            {
                return false;
            }

            if (Path.GetExtension (postedFile.FileName).ToLower () != ".jpg" && Path.GetExtension (postedFile.FileName).ToLower () != ".png")
            {
                return false;
            }

            return true;
        }
    }

}