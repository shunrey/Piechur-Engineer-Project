using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Core.Models
{
    public class Alimentation
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string IsInOffert { get; set; }
        public double AdditionalPrice { get; set; }

        public Accomodation Accomodation { get; set; }
        public int AccomodationId { get; set; }

    }
}
