using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.Seasonal
{
    public class SeasonalModifier
    {
        public int SeasonalModifierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SeasonalMapId { get; set; }
        public SeasonalMap SeasonalMap { get; set; }
    }
}
