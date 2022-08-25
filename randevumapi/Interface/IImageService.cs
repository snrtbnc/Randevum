using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;


namespace RandevumAPI.Interface
{
    public interface IImageService
    {
        Task<string> UploadImage(IFormFile file);
        Task<Stream> DownloadImage(string guid);
    }

}