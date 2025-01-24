using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class AccountStats
    {
        public int AccountStatsId { get; set; }

        //Relation with Account
        public int AccountId { get; set; }
        public Account Account { get; set; }

        //Currency
        public int Gems { get; set; }
        public int PowerPoints { get; set; }
        public int Coins { get; set; }
        public int Credits { get; set; }
        public int Bling { get; set; }

        //Progression
        public int Trophies { get; set; }
        public int TrophiesHighest { get; set; }
        public int RankedRank { get; set; }
        public int RankedHighestRank { get; set; }

        //Win-rate
        public int SoloVictories { get; set; }
        public int DuoVictorires { get; set; }
        public int TrioVictories { get; set; }
    }
}
