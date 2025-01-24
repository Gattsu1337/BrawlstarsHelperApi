using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.AuthDTOs
{
    public class LoginDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}
