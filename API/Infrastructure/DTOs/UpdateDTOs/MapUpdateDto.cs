using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.UpdateDTOs
{
    public class MapUpdateDto
    {
        [Required]
        public int MapId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Mode { get; set; }
        [Required]
        public string Stats { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
