using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Map
    {
        public int MapId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Mode { get; set; }// Not directly mapped to the database
        [NotMapped]
        public string Stats { get; set; }
    }
}
