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
        private readonly IAccomodationRepository _accomodationRepository;

        public PhotoController(IHostingEnvironment hostingEnvironment, ICityRepository cityRepository, 
                                                                       IAccomodationRepository accomodationRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _cityRepository = cityRepository;
            _accomodationRepository = accomodationRepository;
        }

        [HttpPost("addCityPhoto")]
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

        [HttpPost("addAccomodationPhoto")]
        public async Task<IActionResult> AddAccomodationPhoto(IFormFile image)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "AccomodationGallery", "User1");

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

        [HttpGet("getCityPhoto")]
        public async Task<IActionResult> GetCityPhoto(int id, string sufix)
        {
            var city = await _cityRepository.GetCity(id);
            var cityName = city.Name + sufix;

            var path = Path.Combine(_hostingEnvironment.WebRootPath, "CityGallery", "User1");
            var image = System.IO.File.OpenRead(path + "\\" + cityName + ".png");

            return File(image, "image/png");
        }

        [HttpGet("getAccdPhoto")]
        public async Task<IActionResult> GetAccomodationPhoto(int id, string sufix)
        {
            var accd = await _accomodationRepository.GetAccomodation(id);
            var accdName = accd.AddressCity + sufix;

            var path = Path.Combine(_hostingEnvironment.WebRootPath, "AccomodationGallery", "User1");
            var image = System.IO.File.OpenRead(path + "\\" + accdName + ".png");

            return File(image, "image/png");
        }


    }
}