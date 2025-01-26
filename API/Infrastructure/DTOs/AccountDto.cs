using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.Dtos
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
    }
}
