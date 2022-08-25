using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RandevumAPI.Helpers;
using RandevumAPI.Interface;
using RandevumAPI.Objects.CustomExceptions;



namespace randevumapi.Service
{

    public class ImageService : IImageService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string _imagePath;

        public ImageService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            this._imagePath = _configuration.GetValue<string>("ImageServiceSettings:ImagePath");
        }

        public async Task<string> UploadImage(IFormFile image)
        {
            if (image is null)
                throw new ServiceException("file is null ,you must upload a .png or .jpg file to the Request body");
            if (image.Length > 0)
            {
                long maxFileSize = _configuration.GetValue<long>("ImageServiceSettings:MaxFileSize");
                Guid guid = Guid.NewGuid();
                string fileName = guid.ToString() + Path.GetExtension(image.FileName);
                string http = _configuration.GetValue<string>("ImageServiceSettings:http");
                string host = _httpContextAccessor.HttpContext.Request.Host.Value;
                string getImageApi = "/api/Image/" + guid.ToString() + Path.GetExtension(image.FileName);

                if (image.Length > maxFileSize)
                    throw new ServiceException("Max File Size Exceed");
                if (!ImageHelper.IsImage(image))
                    throw new ServiceException("Wrong file extension,it must be .png or .jpg");

                if (!Directory.Exists(_imagePath))
                    Directory.CreateDirectory(_imagePath);

                using var stream = System.IO.File.Create(Path.Combine(_imagePath, fileName));
                await image.CopyToAsync(stream);

                return http + host + getImageApi;
            }

            throw new ServiceException("Unknown Error");
        }


        public async Task<Stream> DownloadImage(string guid)
        {
            return await Task.Run(() =>
            {
                var path = Path.Combine(_imagePath, guid);
                if (File.Exists(path))
                {
                    return System.IO.File.OpenRead(path);
                }
                else throw new ServiceException("Image Not Found");
            });
        }
    }
}