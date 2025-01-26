using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.Seasonal.CreateDTOs
{
    public class SeasonalMapCreateDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Mode { get; set; }
        public string Stats { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public DateTime SeasonStartDate { get; set; }
        [Required]
        public DateTime SeasonEndDate { get; set; }
    }
}
