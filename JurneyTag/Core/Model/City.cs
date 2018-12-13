using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MapPositionLatitude { get; set; }
        public double MapPositionLongitude { get; set; }
    }
}
