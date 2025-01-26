using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.UpdateDTOs
{
    public class AccountUpdateDto
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Email { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
