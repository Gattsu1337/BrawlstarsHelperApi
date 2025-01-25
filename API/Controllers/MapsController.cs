using API.Infrastructure.DTOs;
using API.Infrastructure.DTOs.CreateDTOs;
using API.Infrastructure.DTOs.UpdateDTOs;
using Common.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
        private readonly BrawlstarsHelperDbContext _context;
        private readonly ILogger<MapsController> _logger;

        public MapsController(BrawlstarsHelperDbContext context, ILogger<MapsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<MapDto>> GetMaps([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation("Fetching maps with pagination - Page: {Page}, PageSize: {PageSize}", page, pageSize);

            return await _context.Maps
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new MapDto
                {
                    MapId = m.MapId,
                    Name = m.Name,
                    Description = m.Description,
                    Mode = m.Mode,
                    Stats = m.Stats
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MapDto>> GetMap(int id)
        {
            var map = await _context.Maps.FirstOrDefaultAsync(m => m.MapId == id);

            if (map == null)
            {
                _logger.LogError("Map with ID {Id} not found.", id);
                return NotFound();
            }

            return new MapDto
            {
                MapId = id,
                Name = map.Name,
                Description = map.Description,
                Mode = map.Mode,
                Stats = map.Stats
            };
        }


        [HttpPost]
        public async Task<IActionResult> CreateMap(MapCreateDto mapCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state for account creation.");
                    return BadRequest(ModelState);
                }

                if (await _context.Maps.AnyAsync(m => m.Name == mapCreateDto.Name))
                {
                    return Conflict("Map already exists!");
                }

                var map = new Map
                {
                    Name = mapCreateDto.Name,
                    Description = mapCreateDto.Description,
                    Mode = mapCreateDto.Mode,
                    Stats = mapCreateDto.Stats
                };

                _logger.LogInformation("Creating map with Name: {Name}", map.Name);

                _context.Maps.Add(map);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Map successfully created with ID: {Id}", map.MapId);

                return CreatedAtAction(nameof(GetMap), new { id = map.MapId }, new MapDto
                {
                    MapId = map.MapId,
                    Name = map.Name,
                    Description = map.Description,
                    Mode = map.Mode,
                    Stats = map.Stats
                });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the map.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the map.");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMap(int id,MapUpdateDto mapUpdateDto)
        {
            try
            {
                if (id != mapUpdateDto.MapId)
                {
                    _logger.LogError("Mismatch between URL ID and payload ID - URL ID: {Id}, Payload ID: {PayloadId}", id, mapUpdateDto.MapId);
                    return BadRequest("Map ID mismatch.");
                }

                var map = await _context.Maps.FirstOrDefaultAsync();
                if (map == null)
                {
                    _logger.LogInformation("Map with ID {Id} not found.", id);
                    return NotFound($"Map with ID {id} not found.");
                }

                map.Name = mapUpdateDto.Name;
                map.Description = mapUpdateDto.Description;
                map.Stats = mapUpdateDto.Stats;

                _logger.LogInformation("Updating Map with name {Name}...", map.Name);
                _context.Update(map);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Map with ID {Id} successfully updated.", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating Map with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMap(int id)
        {
            try
            {
                var map = await _context.Maps.FindAsync(id);

                if (map == null)
                {
                    _logger.LogInformation($"Map with ID {id} not found.");
                    return NotFound($"Map with ID {id} not found.");
                }

                _logger.LogInformation("Deleting map with Name: {Name}", map.Name);

                _context.Maps.Remove(map);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Map with ID {id} successfully deleted");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the map.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the map.");
            }
        }
    }
}
