using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Resources
{
    public class CityResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MetersAboveSeaLevel { get; set; }
        public int Population { get; set; }
        public double Area { get; set; }
        public double PopulationDensity { get; set; }
        public Location Location { get; set; }
    }
}
