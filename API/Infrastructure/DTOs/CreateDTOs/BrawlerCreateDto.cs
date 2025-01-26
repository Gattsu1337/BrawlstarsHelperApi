using Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.CreateDTOs
{
    public class BrawlerCreateDto
    {
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
        [StringLength(150, MinimumLength = 3)]
        public string Description { get; set; }

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
        [Required]
        public string ImageUrl { get; set; }
        //[Required]
        //public ICollection<StarPower> StarPowers { get; set; }
        //public HyperChargeCreateDto? HyperCharge { get; set; }
    }
}
