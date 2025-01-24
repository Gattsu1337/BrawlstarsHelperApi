using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Club 
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Account> Members { get; set; }
        public int MembersCount { get; set; }
        public int RequiredTrophies { get; set; }
    }
}
