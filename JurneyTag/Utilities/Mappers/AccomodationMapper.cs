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
                Standard = accomodationResource.Standard,
                MapPositionLatitude = accomodationResource.Location.MapPositionLatitude,
                MapPositionLongitude = accomodationResource.Location.MapPositionLongitude,
                AddressBuild = accomodationResource.Address.Build,
                AddressCity = accomodationResource.Address.City,
                AddressStreet = accomodationResource.Address.Street,
                Type = accomodationResource.Type,
                Alimentations = MapAlimentationResourcesToAlimentations(accomodationResource.Alimentations),
                Rooms = MapRoomResourcesToRooms(accomodationResource.Rooms)
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
                Location = new Location
                {
                    MapPositionLatitude = accomodation.MapPositionLatitude,
                    MapPositionLongitude = accomodation.MapPositionLongitude
                },
                Address = new Address
                {
                    City = accomodation.AddressCity,
                    Build = accomodation.AddressBuild,
                    Street = accomodation.AddressStreet
                },
                Standard = accomodation.Standard,
                Rooms = MapRoomsToRoomResources(accomodation.Rooms),
                Alimentations = MapAlimentationsToAlimentationResources(accomodation.Alimentations)
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
            
        }

        public static Alimentation MapAlimentationResourceToAlimentation(AlimentationResource alimentationResource)
        {
            var alimentation = new Alimentation
            {
                Id = alimentationResource.Id,
                Type = alimentationResource.Type,
                IsInOffert = alimentationResource.IsInOffert,
                AdditionalPrice = alimentationResource.AddPrice,
                AccomodationId = alimentationResource.AccomodationId,
            };

            return alimentation;
        }

        public static IEnumerable<Alimentation> MapAlimentationResourcesToAlimentations(IEnumerable<AlimentationResource> alimentationResources)
        {
            var alimentations = new List<Alimentation>();
            alimentationResources.ToList()
                .ForEach(a => alimentations.Add(MapAlimentationResourceToAlimentation(a)));

            return alimentations;
        }

        public static AlimentationResource MapAlimentationToAlimentationResource(Alimentation alimentation)
        {
            var alimentationResource = new AlimentationResource
            {
                Id = alimentation.Id,
                Type = alimentation.Type,
                IsInOffert = alimentation.IsInOffert,
                AddPrice = alimentation.AdditionalPrice,
                AccomodationId = alimentation.AccomodationId,
            };

            return alimentationResource;
        }

        public static IEnumerable<AlimentationResource> MapAlimentationsToAlimentationResources(IEnumerable<Alimentation> alimentations)
        {
            var alimentationResources = new List<AlimentationResource>();
            alimentations.ToList()
                .ForEach(a => alimentationResources.Add(MapAlimentationToAlimentationResource(a)));

            return alimentationResources;
        }

        public static Room MapRoomResourceToRoom(RoomResource roomResource)
        {
            var room = new Room
            {
                Id = roomResource.Id,
                Number = roomResource.Number,
                Price = roomResource.Price,
                Standard = roomResource.Standard,
                Type = roomResource.Type,
                AccomodationId = roomResource.AccomodationId
            };

            return room;
        }

        public static IEnumerable<Room> MapRoomResourcesToRooms(IEnumerable<RoomResource> roomResources)
        {
            var rooms = new List<Room>();
            roomResources.ToList()
                .ForEach(r => rooms.Add(MapRoomResourceToRoom(r)));

            return rooms;
        }

        public static RoomResource MapRoomToRoomResource(Room room)
        {
            var roomResource = new RoomResource
            {
                Id = room.Id,
                Number = room.Number,
                Price = room.Price,
                Standard = room.Standard,
                Type = room.Type,
                AccomodationId = room.AccomodationId
            };

            return roomResource;
        }

        public static IEnumerable<RoomResource> MapRoomsToRoomResources(IEnumerable<Room> rooms)
        {
            var roomResources = new List<RoomResource>();
            rooms.ToList()
                .ForEach(r => roomResources.Add(MapRoomToRoomResource(r)));

            return roomResources;
        }
    }
}
