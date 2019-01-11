using JurneyTag.Core.Models;
using JurneyTag.Resources;
using JurneyTag.Utilities.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Tests.UnitTests
{
   public class AccomodationMapperTest
    {
        private Accomodation accomodation;
        private AccomodationResource accomodationResource;

        public AccomodationMapperTest()
        {
            accomodation = new Accomodation
            {
                Id = 5,
                Name = "AcomodationName_1",
                Description = "AccomodationDesciption_1",
                Stars = 3,
                Alimentation = "Alimentation1_Alimentation2",
                MapPositionLatitude = 90.4,
                MapPositionLongitude = 128.123,
                Type = "AccomodationType_1"

            };
        }

        [Fact]
        public void MapAccomodationToAccomodationResource_IfExist_ShouldMap()
        {
            accomodation = new Accomodation
            {
                Id = 5,
                Name = "AcomodationName_1",
                Description = "AccomodationDesciption_1",
                Stars = 3,
                Alimentation = "Alimentation1_Alimentation2",
                MapPositionLatitude = 90.4,
                MapPositionLongitude = 128.123,
                Type = "AccomodationType_1"

            };
            var accomodationResource = AccomodationMapper
                                      .MapAccomodationToAccomodationResource(accomodation);

            accomodationResource.Id.Should().Be(5);
            accomodationResource.Name.Should().Be("AcomodationName_1");
            accomodationResource.Description.Should().Be("AccomodationDesciption_1");
            accomodationResource.Stars.Should().Be(3);
            accomodationResource.Alimentation.Should().Be("Alimentation1_Alimentation2");
            accomodationResource.Location.MapPositionLatitude.Should().Be(90.4);
            accomodationResource.Location.MapPositionLongitude.Should().Be(128.123);
            accomodationResource.Type.Should().Be("AccomodationType_1");
        }

        [Fact]
        public void MapAccomodationResourceToAccomodation_IfExist_ShouldMap()
        {
            accomodationResource = new AccomodationResource
            {
                Id = 5,
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

            var accomodation = AccomodationMapper
                                     .MapAccomodationResourceToAccomodation(accomodationResource);

            accomodation.Id.Should().Be(5);
            accomodation.Name.Should().Be("AcomodationName_1");
            accomodation.Description.Should().Be("AccomodationDesciption_1");
            accomodation.Stars.Should().Be(3);
            accomodation.Alimentation.Should().Be("Alimentation1_Alimentation2");
            accomodation.MapPositionLatitude.Should().Be(90.4);
            accomodation.MapPositionLongitude.Should().Be(128.123);
            accomodation.Type.Should().Be("AccomodationType_1");
        }
    }
}
