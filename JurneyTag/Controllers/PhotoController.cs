using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JurneyTag.Core;
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
        private readonly ICityRepository _cityRepository;

        public PhotoController(IHostingEnvironment hostingEnvironment, ICityRepository cityRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _cityRepository = cityRepository;
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
        public async Task<IActionResult> GetCityPhoto(int id, string sufix)
        {
            var city = await _cityRepository.GetCity(id);
            var cityName = city.Name + sufix;

            var path = Path.Combine(_hostingEnvironment.WebRootPath, "CityGallery", "User1");
            var image = System.IO.File.OpenRead(path + "\\" + cityName + ".png");

            return File(image, "image/png");
        }


    }
}