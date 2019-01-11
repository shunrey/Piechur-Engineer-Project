using JurneyTag.Core.Models;
using JurneyTag.Peristence;
using JurneyTag.Resources;
using JurneyTag.Utilities.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace Tests.IntegrationTests
{
    public class AccomodationControllerTest
    {
        private AccomodationResource accomodationResource;
        private UnitOfWork unitOfWork;
        private AccomodationRepository accomodationRepository;
        private ServiceDbContext serviceDbContext;

        public AccomodationControllerTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServiceDbContext>();
            optionsBuilder.UseSqlServer("server= DESKTOP-S9S847J\\SQLEXPRESS; database=JourneyService; integrated security=SSPI");
            serviceDbContext = new ServiceDbContext(optionsBuilder.Options);
            unitOfWork = new UnitOfWork(serviceDbContext);
            accomodationRepository = new AccomodationRepository(serviceDbContext);

            accomodationResource = new AccomodationResource
            {
                Name = "AcomodationName_1",
                Description = "AccomodationDesciption_1",
                Stars = 3,
                Alimentation = "Alimentation1_Alimentation2",
                Location = new Location
                {
                    MapPositionLatitude = 90.4,
                    MapPositionLongitude = 128.123,
                },
                Type = "AccomodationType_1",
            };
        }

        [Fact]
        public async Task AddAccomodation_IfDoesntExistInDb_ShouldAdd()
        {
            var accomodation = AccomodationMapper
                                  .MapAccomodationResourceToAccomodation(accomodationResource);

            accomodationRepository.AddAccomodation(accomodation);
            await unitOfWork.UpdateDatabase();
           
            var accomodationFromDb = await accomodationRepository.GetAccomodation(accomodation.Id);
            accomodationFromDb.Name.Should().Be("AcomodationName_1");
            accomodationFromDb.Description.Should().Be("AccomodationDesciption_1");
            accomodationFromDb.Stars.Should().Be(3);
            accomodationFromDb.Alimentation.Should().Be("Alimentation1_Alimentation2");
            accomodationFromDb.MapPositionLatitude.Should().Be(90.4);
            accomodationFromDb.MapPositionLongitude.Should().Be(128.123);
            accomodationFromDb.Type.Should().Be("AccomodationType_1");

            accomodationRepository.RemoveAccomodation(accomodation.Id);
            await unitOfWork.UpdateDatabase();
        }
    }
}
