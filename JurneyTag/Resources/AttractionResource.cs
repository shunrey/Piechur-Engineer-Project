﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Resources
{
    public class AttractionResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double TicketPrice { get; set; }
        public double HalfTicketPrice { get; set; }
        public Address Address { get; set; }
        public string SeasonOpen { get; set; }
        public Location Location { get; set; }
    }
}
