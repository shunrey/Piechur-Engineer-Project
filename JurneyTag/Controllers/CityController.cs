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

        [HttpGet("getAll")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityRepository.GetCities();
            var citiesResources = CityMapper.MapCitiesToCityResources(cities);

            return Ok(citiesResources);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCity(int id)
        {
            _cityRepository.RemoveCity(id);
            _unitOfWork.UpdateDatabase();
            return Ok();
        }

        [HttpGet("getCity/{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var city = await _cityRepository.GetCity(id);
            var cityResource = CityMapper.MapCityToCityResource(city);

            return Ok(cityResource);
        }


    }
}