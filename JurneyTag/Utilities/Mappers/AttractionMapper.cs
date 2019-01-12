using JurneyTag.Core.Models;
using JurneyTag.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Utilities.Mappers
{
    public static class AttractionMapper
    {
        public static Attraction MapAttractionResourceToAttraction(AttractionResource attractionResource)
        {
            var attraction = new Attraction
            {
                Id = attractionResource.Id,
                Name = attractionResource.Name,
                Description = attractionResource.Description,
                HalfTicketPrice = attractionResource.HalfTicketPrice,
                TicketPrice = attractionResource.TicketPrice,
                SeasonTime = attractionResource.SeasonOpen,
                MapPositionLatitude = attractionResource.Location.MapPositionLatitude,
                MapPositionLongitude = attractionResource.Location.MapPositionLongitude,
                AddressCity = attractionResource.Address.City,
                AddressStreet = attractionResource.Address.Street,
                AddressBuild = attractionResource.Address.Build
            };

            return attraction;
        }

        public static AttractionResource MapAttractionToAttractionResource(Attraction attraction)
        {
            var attractionResource = new AttractionResource
            {
                Id = attraction.Id,
                Name = attraction.Name,
                Description = attraction.Description,
                HalfTicketPrice = attraction.HalfTicketPrice,
                TicketPrice = attraction.TicketPrice,
                SeasonOpen = attraction.SeasonTime,
                Address = new Address
                {
                    City = attraction.AddressCity,
                    Street = attraction.AddressStreet,
                    Build = attraction.AddressBuild
                },
                Location = new Location
                {
                    MapPositionLatitude = attraction.MapPositionLatitude,
                    MapPositionLongitude = attraction.MapPositionLongitude
                }
            };

            return attractionResource;
        }

        public static IEnumerable<Attraction> MapAttractionResourcesToAttraction(IEnumerable<AttractionResource> attractionResources)
        {
            var attractions = new List<Attraction>();
            attractionResources.ToList()
                               .ForEach(a => attractions.Add(MapAttractionResourceToAttraction(a)));

            return attractions;
        }

        public static IEnumerable<AttractionResource> MapAttractionsToAttractionResources(IEnumerable<Attraction> attractions)
        {
            var attractionResources = new List<AttractionResource>();
            attractions.ToList()
                        .ForEach(a => attractionResources.Add(MapAttractionToAttractionResource(a)));

            return attractionResources;
        }
    }
}
