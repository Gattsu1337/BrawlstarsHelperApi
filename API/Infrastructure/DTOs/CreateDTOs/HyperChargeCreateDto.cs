using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.CreateDTOs
{
    public class HyperChargeCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int BrawlerId { get; set; }
        [Required]
        public int SpeedIncrease { get; set; }
        [Required]
        public int DamageIncrease { get; set; }
        [Required]
        public int ShieldIncrease { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
