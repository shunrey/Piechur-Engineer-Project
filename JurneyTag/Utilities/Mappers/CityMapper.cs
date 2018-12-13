using JurneyTag.Models;
using JurneyTag.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Utilities.Mappers
{
    public static class CityMapper
    {
        public static City MapCityResourceToCity(CityResource cityResource)
        {
            var city = new City
            {
                Id = cityResource.Id,
                Description = cityResource.Description,
                Name = cityResource.Name,
                MapPositionLatitude = cityResource.Location.MapPositionLatitude,
                MapPositionLongitude = cityResource.Location.MapPositionLongitude,
                MetersAboveSeaLevel = cityResource.MetersAboveSeaLevel,
                Population = cityResource.Population,
                Area = cityResource.Area,
                PopulationDensity = cityResource.PopulationDensity
            };

            return city;
        }

        public static CityResource MapCityToCityResource(City city)
        {
            var cityResource = new CityResource
            {
                Id = city.Id,
                Description = city.Description,
                Name = city.Name,
                MetersAboveSeaLevel = city.MetersAboveSeaLevel,
                Population = city.Population,
                Area = city.Area,
                PopulationDensity = city.PopulationDensity,
                Location = new Location
                {
                    MapPositionLatitude = city.MapPositionLatitude,
                    MapPositionLongitude = city.MapPositionLongitude
                }
            };

            return cityResource;
        }

        public static IEnumerable<City> MapCityResourcesToCities(IEnumerable<CityResource> cityResources)
        {
            var cities = new List<City>();
            cityResources.ToList()
                         .ForEach(cityRes => cities.Add(MapCityResourceToCity(cityRes)));

            return cities;            
        }

        public static IEnumerable<CityResource> MapCitiesToCityResources(IEnumerable<City> cities)
        {
            var cityResources = new List<CityResource>();
            cities.ToList()
                  .ForEach(city => cityResources.Add(MapCityToCityResource(city)));

            return cityResources;
        }

        public static void SetCityToUpdate(City cityFromDb, City updatedCity)
        {
            cityFromDb.Description = updatedCity.Description;
            cityFromDb.MapPositionLatitude = updatedCity.MapPositionLatitude;
            cityFromDb.MapPositionLongitude = updatedCity.MapPositionLongitude;
            cityFromDb.Name = updatedCity.Name;
            cityFromDb.PopulationDensity = updatedCity.PopulationDensity;
            cityFromDb.MetersAboveSeaLevel = updatedCity.MetersAboveSeaLevel;
            cityFromDb.Population = updatedCity.Population;
            cityFromDb.Area = updatedCity.Area;
        }
    }
}
