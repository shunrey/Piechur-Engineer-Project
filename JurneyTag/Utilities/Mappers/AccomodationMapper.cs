using JurneyTag.Core.Models;
using JurneyTag.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Utilities.Mappers
{
    public class AccomodationMapper
    {
        public static Accomodation MapAccomodationResourceToAccomodation(AccomodationResource accomodationResource)
        {
            var accomodation = new Accomodation
            {
                Id = accomodationResource.Id,
                Description = accomodationResource.Description,
                Name = accomodationResource.Name,
                MapPositionLatitude = accomodationResource.Location.MapPositionLatitude,
                MapPositionLongitude = accomodationResource.Location.MapPositionLongitude,
                Type = accomodationResource.Type,
                Stars = accomodationResource.Stars,
                Alimentation = accomodationResource.Alimentation
            };

            return accomodation;
        }

        public static AccomodationResource MapAccomodationToAccomodationResource(Accomodation accomodation)
        {
            var accomodationResource = new AccomodationResource
            {
                Id = accomodation.Id,
                Description = accomodation.Description,
                Name = accomodation.Name,
                Type = accomodation.Type,
                Stars = accomodation.Stars,
                Alimentation = accomodation.Alimentation,
                Location = new Location
                {
                    MapPositionLatitude = accomodation.MapPositionLatitude,
                    MapPositionLongitude = accomodation.MapPositionLongitude
                }
            };

            return accomodationResource;
        }

        public static IEnumerable<Accomodation> MapAccomodationResourcesToAccomodations(IEnumerable<AccomodationResource> accomodationResources)
        {
            var accomodations = new List<Accomodation>();
            accomodationResources.ToList()
                         .ForEach(accRes => accomodations.Add(MapAccomodationResourceToAccomodation(accRes)));

            return accomodations;
        }

        public static IEnumerable<AccomodationResource> MapAccomodationsToAccomodationResources(IEnumerable<Accomodation> accomodations)
        {
            var accomodationResources = new List<AccomodationResource>();
            accomodations.ToList()
                  .ForEach(acc => accomodationResources.Add(MapAccomodationToAccomodationResource(acc)));

            return accomodationResources;
        }

        public static void SetAccomodationToUpdate(Accomodation accomodationFromDb, Accomodation updatedAccomodation)
        {
            accomodationFromDb.Id = updatedAccomodation.Id;
            accomodationFromDb.Description = updatedAccomodation.Description;
            accomodationFromDb.Name = updatedAccomodation.Name;
            accomodationFromDb.MapPositionLatitude = updatedAccomodation.MapPositionLatitude;
            accomodationFromDb.MapPositionLongitude = updatedAccomodation.MapPositionLongitude;
            accomodationFromDb.Type = updatedAccomodation.Type;
            accomodationFromDb.Stars = updatedAccomodation.Stars;
            accomodationFromDb.Alimentation = updatedAccomodation.Alimentation;
        }
    }
}
