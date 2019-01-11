using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Core.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Standard { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        public Accomodation Accomodation { get; set; }
        public int AccomodationId { get; set; }
    }
}
