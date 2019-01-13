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
    [Route("api/attraction")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttractionRepository _attractionRepository;

        public AttractionController(IUnitOfWork unitOfWork, IAttractionRepository attractionRepository)
        {
            _unitOfWork = unitOfWork;
            _attractionRepository = attractionRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAttraction(AttractionResource attractionResource)
        {
            var attraction = AttractionMapper.MapAttractionResourceToAttraction(attractionResource);
            _attractionRepository.AddAttraction(attraction);
            await _unitOfWork.UpdateDatabase();

            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAttractions()
        {
            var attractions = await _attractionRepository.GetAttractions();
            var attractionResources = AttractionMapper.MapAttractionsToAttractionResources(attractions);

            return Ok(attractionResources);
        }

        [HttpGet("getAttraction/{id}")]
        public async Task<IActionResult> GetAttraction(int id)
        {
            var attraction = await _attractionRepository.GetAttraction(id);
            var attractionResource = AttractionMapper.MapAttractionToAttractionResource(attraction);

            return Ok(attractionResource);
        }
    }
}