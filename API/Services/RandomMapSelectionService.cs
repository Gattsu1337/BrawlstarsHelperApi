using Common.Entities.Seasonal;
using Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class RandomMapSelectionService
    {

        private readonly BrawlstarsHelperDbContext _context;
        private readonly Random _random;

        public RandomMapSelectionService(BrawlstarsHelperDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task<(SeasonalMap map, SeasonalModifier modifier)> GetRandomMapAndModifierAsync()
        {
            var seasonalMaps = await _context.SeasonalMaps
            .Include(m => m.SeasonalModifiers) // Include modifiers for eager loading
            .ToListAsync();

            if (!seasonalMaps.Any())
            {
                throw new InvalidOperationException("No seasonal maps are available.");
            }

            var randomMap = seasonalMaps[_random.Next(seasonalMaps.Count)];

            if (randomMap.SeasonalModifiers == null || !randomMap.SeasonalModifiers.Any())
            {
                throw new InvalidOperationException($"No modifiers are available for the map {randomMap.Name}.");
            }

            var randomModifier = randomMap.SeasonalModifiers.ElementAt(_random.Next(randomMap.SeasonalModifiers.Count));

            return (randomMap, randomModifier);
        }
    }
}
