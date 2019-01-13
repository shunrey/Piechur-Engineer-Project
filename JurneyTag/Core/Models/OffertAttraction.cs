using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Core.Models
{
    public class OffertAttraction
    {
        public int OffertId { get; set; }
        public Offert Offert { get; set; }

        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }

        public DateTime Date { get; set; }
    }
}
