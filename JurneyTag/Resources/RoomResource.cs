using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Resources
{
    public class RoomResource
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Standard { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        public AccomodationResource Accomodation { get; set; }
        public int AccomodationId { get; set; }
    }
}
