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
    [Route("api/offert")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class OffertController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOffertRespository _offertRespository;

        public OffertController(IUnitOfWork unitOfWork, IOffertRespository offertRespository)
        {
            _unitOfWork = unitOfWork;
            _offertRespository = offertRespository;
        }

        [HttpPost("addOffert")]
        public async Task<IActionResult> AddOffert(OffertResource offertResource)
        {
            var offert = OffertMapper.MapOffertResourceToOffert(offertResource);

            _offertRespository.AddOffert(offert);
            await _unitOfWork.UpdateDatabase();
            return Ok();
        }

        [HttpGet("getOffert/{id}")]
        public async Task<IActionResult> GetOffert(int id)
        {
            var offert = await _offertRespository.GetOffert(id);
            var offertResource = OffertMapper.MapOffertToOffertResource(offert);

            return Ok(offertResource);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetOfferts()
        {
            var offerts = await _offertRespository.GetOfferts();
            var offertResources = OffertMapper.MapOffertsToOffertsResources(offerts);

            return Ok(offertResources);
        }


    }
}