using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? ClubId { get; set; }
        public Club Club { get; set; }
        public AccountStats AccountStats { get; set; }
        public ICollection<AccountBrawler> UnlockedBrawlers { get; set; }
    }
}
