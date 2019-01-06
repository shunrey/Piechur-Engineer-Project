using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using FluentAssertions;
using JurneyTag.Models;
using JurneyTag.Resources;
using JurneyTag.Utilities.Mappers;

namespace Tests.UnitTests
{
    public class CityMapperTest
    {
        private City city;
        private CityResource cityResource;


        public CityMapperTest()
        {
            city = new City
            {
                Id = 3,
                Description = "City Description A",
                Area = 130.9

            };
            //city.Description.Returns("City Description A");
            //city.Id.Returns(12);
            //city.Area.Returns(130.9);
            //city.PopulationDensity.Returns(76.5);
            //city.Name.Returns("City A");
            //city.Population.Returns(3000);
            //city.MetersAboveSeaLevel.Returns(760);
            //city.MapPositionLatitude.Returns(80.9);
            //city.MapPositionLongitude.Returns(120.989);
        }

        [Fact]
        public void MapCityResourceFromCity_IfCityExists_ShouldMap()
        {
           var testCityResource = CityMapper.MapCityToCityResource(city);
           testCityResource.Id.Should().Be(3);
           testCityResource.Description.Should().Be("City Description A");
           testCityResource.Area.Should().Be(130.9);
        }
    }
}
