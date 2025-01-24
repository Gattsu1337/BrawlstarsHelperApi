using System.ComponentModel.DataAnnotations;

namespace API.Infrastructure.DTOs.UpdateDTOs
{
    public class MapUpdateDto
    {
        [Required]
        public int MapId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Mode { get; set; }
    }
}
