using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JurneyTag.Controllers
{
    [Route("api/photo")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class PhotoController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public PhotoController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCityPhoto(IFormFile image)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "CityGallery", "User1");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(path, image.FileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            return Ok();
        }

        [HttpGet("get")]
        public IActionResult GetCityPhoto(string id)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "CityGallery", "User1");
            var image = System.IO.File.OpenRead(path + "\\id.png");

            return File(image, "image/png");
        }


    }
}