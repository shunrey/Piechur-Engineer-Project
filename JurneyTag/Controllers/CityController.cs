using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JurneyTag.Core;
using JurneyTag.Resources;
using JurneyTag.Utilities.Mappers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JurneyTag.Controllers
{
    [Route("api/city")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICityRepository _cityRepository;

        public CityController(IUnitOfWork unitOfWork, ICityRepository cityRepository)
        {
            _unitOfWork = unitOfWork;
            _cityRepository = cityRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCity(CityResource cityResource)
        {
            var city = CityMapper.MapCityResourceToCity(cityResource);
            _cityRepository.AddCity(city);
            await _unitOfWork.UpdateDatabase();

            return Ok();
        }
    }
}