using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Core.Models
{
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double TicketPrice { get; set; }
        public double HalfTicketPrice { get; set; }
        public double MapPositionLatitude { get; set; }
        public double MapPositionLongitude { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string AddressBuild { get; set; }
        public string SeasonTime { get; set; }
    }
}
