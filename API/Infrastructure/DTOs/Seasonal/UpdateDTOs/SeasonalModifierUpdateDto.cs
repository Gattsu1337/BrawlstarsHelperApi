using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.Seasonal.UpdateDTOs
{
    public class SeasonalModifierUpdateDto
    {
        [Required]
        public int SeasonalModifierId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
