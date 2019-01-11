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
    [Route("api/accomodation")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class AccomodationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccomodationRepository _accomodationRepository;

        public AccomodationController(IUnitOfWork unitOfWork, IAccomodationRepository accomodationRepository)
        {
            _unitOfWork = unitOfWork;
            _accomodationRepository = accomodationRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAccomodation(AccomodationResource accomodationResource)
        {
            var accomodation = AccomodationMapper.MapAccomodationResourceToAccomodation(accomodationResource);

            _accomodationRepository.AddAccomodation(accomodation);
            await _unitOfWork.UpdateDatabase();

            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAccomodations()
        {
            var accomodations = await _accomodationRepository.GetAccomodations();
            var accomodationsResources = AccomodationMapper.MapAccomodationsToAccomodationResources(accomodations);

            return Ok(accomodationsResources);
        }
    }
}