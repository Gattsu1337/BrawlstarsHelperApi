using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Gadget 
    {
        public int GadgetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrawlerId { get; set; }
        public Brawler Brawler { get; set; }
        public bool IsChosen { get; set; }
    }
}
