using JurneyTag.Core.Models;
using JurneyTag.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Utilities.Mappers
{
    public static class OffertMapper
    {
        public static Offert MapOffertResourceToOffert(OffertResource offertResource)
        {
            var offert = new Offert
            {
                Name = offertResource.Name,
                Description = offertResource.Description,
                MaxPrice = offertResource.MaxPrice,
                MinPrice = offertResource.MinPrice,
                DateEnd = offertResource.DateEnd,
                DateStart = offertResource.DateStart,
                Places = offertResource.MaxPlaces,
                OffertType = offertResource.OffertType,
                AccomodationId = offertResource.AccomodationId,
                CityId = offertResource.CityId,
                OffertAttractions = MapAttractionDatesResourcesToOffertAttractions(offertResource.AttractionsDates)
            };

            return offert;
        }

        public static IEnumerable<Offert> MapOffertsResourcesToOfferts(IEnumerable<OffertResource> offertResources)
        {
            var offerts = new List<Offert>();
            offertResources.ToList()
                           .ForEach(of => offerts.Add(MapOffertResourceToOffert(of)));

            return offerts;
        }

        public static OffertResource MapOffertToOffertResource(Offert offert)
        {
            var offertResource = new OffertResource
            {
                Id = offert.Id,
                Name = offert.Name,
                Description = offert.Description,
                MaxPrice = offert.MaxPrice,
                MinPrice = offert.MinPrice,
                DateEnd = offert.DateEnd,
                DateStart = offert.DateStart,
                MaxPlaces = offert.Places,
                OffertType = offert.OffertType,
                AccomodationId = offert.AccomodationId,
                CityId = offert.CityId,
                AttractionsDates = MapOffertAttractionsToAttractionDatesResources(offert.OffertAttractions)
            };

            return offertResource;
        }

        public static IEnumerable<OffertResource> MapOffertsToOffertsResources(IEnumerable<Offert> offert)
        {
            var offertResources = new List<OffertResource>();
            offert.ToList()
                  .ForEach(of => offertResources.Add(MapOffertToOffertResource(of)));

            return offertResources;
        }

        private static IEnumerable<OffertAttraction> MapAttractionDatesResourcesToOffertAttractions(IEnumerable<AttractionDateResource> attractionDateResources)                                                                                                             
        {
            var offertsAttractions = new List<OffertAttraction>();
            attractionDateResources.ToList()
                                   .ForEach(ad => offertsAttractions.Add(new OffertAttraction
                                   {
                                       AttractionId = ad.AttractionId,
                                       Date = ad.AttractionDate,
        
                                   }));

            return offertsAttractions;

        }

        private static IEnumerable<AttractionDateResource> MapOffertAttractionsToAttractionDatesResources(IEnumerable<OffertAttraction> offertAttractions)
        {
            var attractionDateResources = new List<AttractionDateResource>();
            offertAttractions.ToList()
                             .ForEach(ad => attractionDateResources.Add(new AttractionDateResource
                               {
                                   AttractionId = ad.AttractionId,
                                   AttractionDate = ad.Date,
                  
                                }));

            return attractionDateResources;

        }

    }
}
