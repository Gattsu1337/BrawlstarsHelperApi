namespace API.Infrastructure.DTOs.Seasonal
{
    public class SeasonalMapDto
    {
        public int SeasonalMapId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Mode { get; set; }
        public List<SeasonalModifierDto> SeasonalModifiers { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
    }
}
