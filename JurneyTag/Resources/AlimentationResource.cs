using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Resources
{
    public class AlimentationResource
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string IsInOffert { get; set; }
        public double AddPrice { get; set; }

        public AccomodationResource Accomodation { get; set; }
        public int AccomodationId { get; set; }
    }
}
