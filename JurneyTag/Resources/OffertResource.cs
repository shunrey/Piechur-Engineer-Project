using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Resources
{
    public class OffertResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string OffertType { get; set; }
        public int MaxPlaces { get; set; }
        public int ActualPlaces { get; set; }
        public bool IsPublished { get; set; }

        public int CityId { get; set; }
        public int AccomodationId { get; set; }
        public IEnumerable<AttractionDateResource> AttractionsDates { get; set; }
        public IEnumerable<ClientInfoResource> ClientsInfo { get; set; }
    }
}
