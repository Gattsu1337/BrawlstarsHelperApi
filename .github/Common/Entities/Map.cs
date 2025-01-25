using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Map
    {
        public int MapId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Mode { get; set; }
        public string Stats { get; set; } // JSON field
    }
}
