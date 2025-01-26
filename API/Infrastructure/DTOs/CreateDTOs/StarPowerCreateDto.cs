using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.CreateDTOs
{
    public class StarPowerCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string BrawlerName { get; set; }
    }
}
