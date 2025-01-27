using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.Seasonal.CreateDTOs
{
    public class SeasonalModifierCreateDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int SeasonalMapId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
