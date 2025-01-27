using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.Seasonal.UpdateDTOs
{
    public class SeasonalMapUpdateDto
    {
        [Required]
        public int SeasonalMapId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Mode { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Stats { get; set; }
        [Required]
        public List<int> SeasonalModifierIds { get; set; } // IDs of the related SeasonalModifiers
        [Required]
        public DateTime SeasonStartDate { get; set; }
        [Required]
        public DateTime SeasonEndDate { get; set; }
    }
}
