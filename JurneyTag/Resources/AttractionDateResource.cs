using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Resources
{
    public class AttractionDateResource
    {
        public int Id { get; set; }
        public int AttractionId { get; set; }
        public DateTime AttractionDate { get; set; }
    }
}
