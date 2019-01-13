using JurneyTag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Core.Models
{
    public class Offert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public string OffertType { get; set; }
        public int Places { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int AccomodationId { get; set; }
        public Accomodation Accomodation { get; set; }

        public IEnumerable<OffertAttraction> OffertAttractions { get; set; }

    }
}
