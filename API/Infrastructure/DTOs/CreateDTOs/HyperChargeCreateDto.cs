namespace API.Infrastructure.DTOs.CreateDTOs
{
    public class HyperChargeCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrawlerId { get; set; }
        public int SpeedIncrease { get; set; }
        public int DamageIncrease { get; set; }
        public int ShieldIncrease { get; set; }
    }
}
