﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Resources
{
    public class ClientInfoResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Preferences { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }
        public bool IsRodoChecked { get; set; }

        public int OffertId { get; set; }
        public OffertResource Offert { get; set; }
    }
}
