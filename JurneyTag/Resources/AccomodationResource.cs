using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Resources
{
    public class AccomodationResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Standard { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }

        public IEnumerable<AlimentationResource> Alimentations { get; set; }
        public IEnumerable<RoomResource> Rooms { get; set; }

        public Location Location { get; set; }
    }
}
