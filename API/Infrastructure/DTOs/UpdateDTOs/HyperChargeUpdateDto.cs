using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.UpdateDTOs
{
    public class HyperChargeUpdateDto
    {
        [Required]
        public int HyperChargeId { get; set; }
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
