using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Gear 
    {
        public int GearId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnlockCost { get; set; }
        public ICollection<BrawlerGears> UnlockedByBrawler { get; set; }
    }
}
