using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class BrawlerGears
    {
        public int BrawlerId { get; set; }
        public Brawler Brawler { get; set; }

        public int GearId { get; set; }
        public Gear Gear { get; set; }

        public bool IsUnlocked { get; set; }

    }
}
