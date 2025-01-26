using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Brawler
    {
        public int BrawlerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Rarity { get; set; }
        public string ImageUrl { get; set; }

        // Brawler stats
        public int Health { get; set; }
        public int Attack {  get; set; }
        public string MovementSpeed { get; set; }
        public string ReloadSpeed { get; set; }
        public string Range { get; set; }


        public ICollection<AccountBrawler> UnlockedByAccounts { get; set; }
        public ICollection<BrawlerGears> UnlockedGears { get; set; }
        public ICollection<StarPower> StarPowers { get; set; }
        public ICollection<Gadget> Gadgets { get; set; }
        public HyperCharge? HyperCharge { get; set; }
    }
}
