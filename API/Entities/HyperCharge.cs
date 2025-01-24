using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class HyperCharge
    {
        public int HyperChargeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrawlerId { get; set; }
        public int SpeedIncrease { get; set; }
        public int DamageIncrease { get; set; }
        public int ShieldIncrease { get; set; }
        public Brawler Brawler { get; set; }
    }
}
