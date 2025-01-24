namespace API.Infrastructure.DTOs.UpdateDTOs
{
    public class HyperChargeUpdateDto
    {
        public int HyperChargeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrawlerId { get; set; }
        public int SpeedIncrease { get; set; }
        public int DamageIncrease { get; set; }
        public int ShieldIncrease { get; set; }
    }
}
