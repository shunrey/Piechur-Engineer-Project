﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Resources
{
    public class AccomodationResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public string Alimentation { get; set; }
        public Location Location { get; set; }
    }
}