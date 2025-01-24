using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.CreateDTOs
{
    public class MapCreateDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Mode { get; set; }
    }
}
