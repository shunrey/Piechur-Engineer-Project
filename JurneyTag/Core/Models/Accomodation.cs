using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Core.Models
{
    public class Accomodation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Standard { get; set; }
        public string Description { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string AddressBuild { get; set; }
        public double MapPositionLatitude { get; set; }
        public double MapPositionLongitude { get; set; }

        public IEnumerable<Alimentation> Alimentations { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}
