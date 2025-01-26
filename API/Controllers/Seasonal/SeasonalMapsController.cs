using API.Infrastructure.DTOs.Seasonal;
using API.Infrastructure.DTOs.Seasonal.CreateDTOs;
using API.Infrastructure.DTOs.Seasonal.UpdateDTOs;
using Common.Entities.Seasonal;
using Common.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Seasonal
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonalMapsController : ControllerBase
    {
        private readonly BrawlstarsHelperDbContext _context;
        private readonly ILogger<SeasonalMapsController> _logger;

        public SeasonalMapsController(BrawlstarsHelperDbContext context, ILogger<SeasonalMapsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<SeasonalMapDto>> GetSeasonalMaps([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation("Fetching seasonal maps with pagination - Page: {Page}, PageSize: {PageSize}", page, pageSize);

            return await _context.SeasonalMaps
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new SeasonalMapDto
                {
                    SeasonalMapId = m.SeasonalMapId,
                    Name = m.Name,
                    Description = m.Description,
                    Mode = m.Mode,
                    Stats = m.Stats,
                    SeasonStartDate = m.SeasonStartDate,
                    SeasonEndDate = m.SeasonEndDate,
                    ImageUrl = m.ImageUrl,
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeasonalMapDto>> GetSeasonalMap(int id)
        {
            var seasonalMap = await _context.SeasonalMaps
                .Include(sm => sm.SeasonalModifiers)
                .FirstOrDefaultAsync(sm => sm.SeasonalMapId == id);


            if (seasonalMap == null)
            {
                _logger.LogError("Seasonal map with ID {Id} not found.", id);
                return NotFound();
            }

            return new SeasonalMapDto
            {
                SeasonalMapId = id,
                Name = seasonalMap.Name,
                Description = seasonalMap.Description,
                Mode = seasonalMap.Mode,
                Stats = seasonalMap.Stats,
                SeasonStartDate = seasonalMap.SeasonStartDate,
                SeasonEndDate = seasonalMap.SeasonEndDate,
                ImageUrl = seasonalMap.ImageUrl
            };
        }


        [HttpPost]
        public async Task<IActionResult> CreateMap(SeasonalMapCreateDto seasonalMapCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state for account creation.");
                    return BadRequest(ModelState);
                }

                if (await _context.SeasonalMaps.AnyAsync(m => m.Name == seasonalMapCreateDto.Name))
                {
                    return Conflict("Seasonal map already exists!");
                }

                var map = new SeasonalMap
                {
                    Name = seasonalMapCreateDto.Name,
                    Description = seasonalMapCreateDto.Description,
                    Mode = seasonalMapCreateDto.Mode,
                    Stats = seasonalMapCreateDto.Stats,
                    SeasonStartDate = seasonalMapCreateDto.SeasonStartDate,
                    SeasonEndDate = seasonalMapCreateDto.SeasonEndDate,
                    ImageUrl = seasonalMapCreateDto.ImageUrl
                };

                _logger.LogInformation("Creating map with Name: {Name}", map.Name);

                _context.SeasonalMaps.Add(map);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Seasonal map successfully created with ID: {Id}", map.SeasonalMapId);

                return CreatedAtAction(nameof(GetSeasonalMap), new { id = map.SeasonalMapId }, new SeasonalMapDto
                {
                    SeasonalMapId = map.SeasonalMapId,
                    Name = map.Name,
                    Description = map.Description,
                    Mode = map.Mode,
                    SeasonStartDate = map.SeasonStartDate,
                    SeasonEndDate = map.SeasonEndDate,
                    ImageUrl = map.ImageUrl
                });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the seasonal map.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the seasonal map.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeasonalMap(int id, SeasonalMapUpdateDto seasonalMapUpdateDto)
        {
            try
            {
                // Validate ID match
                if (id != seasonalMapUpdateDto.SeasonalMapId)
                {
                    _logger.LogError("Mismatch between URL ID and payload ID - URL ID: {Id}, Payload ID: {PayloadId}", id, seasonalMapUpdateDto.SeasonalMapId);
                    return BadRequest("Seasonal Map ID mismatch.");
                }

                // Find the map in the database
                var seasonalMap = await _context.SeasonalMaps
                    .Include(sm => sm.SeasonalModifiers)
                    .FirstOrDefaultAsync(sm => sm.SeasonalMapId == id);

                if (seasonalMap == null)
                {
                    _logger.LogInformation("Seasonal Map with ID {Id} not found.", id);
                    return NotFound($"Seasonal Map with ID {id} not found.");
                }

                // Update fields
                seasonalMap.Name = seasonalMapUpdateDto.Name;
                seasonalMap.Description = seasonalMapUpdateDto.Description;
                seasonalMap.Mode = seasonalMapUpdateDto.Mode;
                seasonalMap.Stats = seasonalMapUpdateDto.Stats;
                seasonalMap.SeasonStartDate = seasonalMapUpdateDto.SeasonStartDate;
                seasonalMap.SeasonEndDate = seasonalMapUpdateDto.SeasonEndDate;
                seasonalMap.ImageUrl = seasonalMapUpdateDto.ImageUrl;

                if (seasonalMapUpdateDto.SeasonalModifierIds != null)
                {
                    var seasonalModifiers = await _context.SeasonalModifiers
                        .Where(sm => seasonalMapUpdateDto.SeasonalModifierIds.Contains(sm.SeasonalModifierId))
                        .ToListAsync();

                    seasonalMap.SeasonalModifiers = seasonalModifiers;
                }

                // Save changes
                _context.SeasonalMaps.Update(seasonalMap);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Seasonal Map with ID {Id} successfully updated.", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating Seasonal Map with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeasonalMap(int id)
        {
            try
            {
                var map = await _context.SeasonalMaps.FindAsync(id);

                if (map == null)
                {
                    _logger.LogInformation($"Seasonal map with ID {id} not found.");
                    return NotFound($"Seasonal map with ID {id} not found.");
                }

                _logger.LogInformation("Deleting seasonal map with Name: {Name}", map.Name);

                _context.SeasonalMaps.Remove(map);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Seasonal map with ID {id} successfully deleted");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the seasonal map.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the seasonal map.");
            }
        }
    }
}
