using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.Seasonal
{
    public class SeasonalMap
    {
        public int SeasonalMapId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Mode { get; set; }
        public string Stats { get; set; }
        public ICollection<SeasonalModifier> SeasonalModifiers { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }

    }
}
