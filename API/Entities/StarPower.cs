using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class StarPower
    {
        public int StarPowerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string BrawlerName { get; set; }
        public int? BrawlerId { get; set; }
        public Brawler? Brawler { get; set; }
    }
}
