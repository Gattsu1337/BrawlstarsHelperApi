using Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.UpdateDTOs
{
    public class BrawlerUpdateDto
    {
        [Required]
        public int BrawlerId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Rarity { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        // Brawler stats
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Health cannot be a negative value.")]
        public int Health { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Attack cannot be a negative value.")]
        public int Attack { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string MovementSpeed { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string ReloadSpeed { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Range { get; set; }
        //public ICollection<StarPower> StarPowers { get; set; }
        //public HyperCharge? HyperCharge { get; set; }
    }
}
