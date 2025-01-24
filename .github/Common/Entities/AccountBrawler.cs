using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class AccountBrawler
    {
        public int BrawlerId { get; set; }
        public Brawler Brawler { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
