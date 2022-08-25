using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandevumAPI.Interface;


namespace RandevumAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [AllowAnonymous]
        [HttpPost, Route("uploadimage")]
        public async Task<string> UploadImage([FromForm(Name = "file")] IFormFile file)
        {
            return await imageService.UploadImage(file);
        }

        [AllowAnonymous]
        [HttpGet, Route("{guid}")]
        public async Task<IActionResult> Get(string guid)
        {
            var image = await imageService.DownloadImage(guid);
            return File(image, "image/png");
        }
    }
}