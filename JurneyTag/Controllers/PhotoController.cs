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
        private readonly IAttractionRepository _attractionRepository;
        private readonly IOffertRespository _offertRespository;

        public PhotoController(IHostingEnvironment hostingEnvironment, ICityRepository cityRepository, 
                                                                       IAccomodationRepository accomodationRepository,
                                                                       IAttractionRepository attractionRepository,
                                                                       IOffertRespository offertRespository)
        {
            _hostingEnvironment = hostingEnvironment;
            _cityRepository = cityRepository;
            _accomodationRepository = accomodationRepository;
            _attractionRepository = attractionRepository;
            _offertRespository = offertRespository;
        }

        [HttpPost("addCityPhoto/{cityName}")]
        public async Task<IActionResult> AddCityPhoto(IFormFile image, string cityName)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "CityGallery", "User1");
            var imageName = cityName + "Main" + ".png";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(path, imageName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            return Ok();
        }

        [HttpPost("addAccomodationPhoto/{accomodationName}")]
        public async Task<IActionResult> AddAccomodationPhoto(IFormFile image, string accomodationName)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "AccomodationGallery", "User1");
            var imageName = accomodationName + "Main" + ".png";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(path, imageName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            return Ok();
        }

        [HttpPost("addAttractionPhoto/{attractionName}")]
        public async Task<IActionResult> AddAttractionPhoto(IFormFile image, string attractionName)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "AttractionGallery", "User1");
            var imageName = attractionName + "Main" + ".png";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(path, imageName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            return Ok();
        }

        [HttpPost("addOffertPhoto/{offertName}")]
        public async Task<IActionResult> AddOffertPhoto(IFormFile image, string offertName )
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "OffertGallery", "User1");
            var imageName = offertName + "Main" + ".png";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(path, imageName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            return Ok();
        }


        [HttpGet("getOffertPhoto")]
        public async Task<IActionResult> GetOffertPhoto(int id, string sufix)
        {
            var offert = await _offertRespository.GetOffert(id);
            var offertName = offert.Name + sufix;

            var path = Path.Combine(_hostingEnvironment.WebRootPath, "OffertGallery", "User1");
            var image = System.IO.File.OpenRead(path + "\\" + offertName + ".png");

            return File(image, "image/png");
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
            var accdName = accd.Name + sufix;

            var path = Path.Combine(_hostingEnvironment.WebRootPath, "AccomodationGallery", "User1");
            var image = System.IO.File.OpenRead(path + "\\" + accdName + ".png");

            return File(image, "image/png");
        }

        [HttpGet("getAttractionPhoto")]
        public async Task<IActionResult> GetAttractionPhoto(int id, string sufix)
        {
            var attr = await _attractionRepository.GetAttraction(id);
            var attrName = attr.Name + sufix;

            var path = Path.Combine(_hostingEnvironment.WebRootPath, "AttractionGallery", "User1");
            var image = System.IO.File.OpenRead(path + "\\" + attrName + ".png");

            return File(image, "image/png");
        }


    }
}