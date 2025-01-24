using Common.Entities;

namespace API.Infrastructure.DTOs
{
    public class BrawlerDto
    {
        public int BrawlerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }
        // Brawler stats
        public int Health { get; set; }
        public int Attack { get; set; }
        public string MovementSpeed { get; set; }
        public string ReloadSpeed { get; set; }
        public string Range { get; set; }
        public HyperChargeDto? HyperCharge { get; set; }
    }
}
