using API.Infrastructure.DTOs.Seasonal;
using API.Infrastructure.DTOs.Seasonal.CreateDTOs;
using API.Infrastructure.DTOs.Seasonal.UpdateDTOs;
using Common.Entities.Seasonal;
using Common.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonalModifiersController : ControllerBase
    {
        private readonly BrawlstarsHelperDbContext _context;
        private readonly ILogger<SeasonalModifiersController> _logger;

        public SeasonalModifiersController(BrawlstarsHelperDbContext context, ILogger<SeasonalModifiersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<SeasonalModifierDto>> GetSeasonalModifiers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation("Fetching SeasonalModifiers with pagination - Page: {Page}, PageSize: {PageSize}", page, pageSize);

            return await _context.SeasonalModifiers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new SeasonalModifierDto
                {
                    SeasonalModifierId = m.SeasonalModifierId,
                    Name = m.Name,
                    Description = m.Description,
                    ImageUrl = m.ImageUrl,
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeasonalModifierDto>> GetSeasonalModifier(int id)
        {
            var modifier = await _context.SeasonalModifiers.FirstOrDefaultAsync(m => m.SeasonalModifierId == id);

            if (modifier == null)
            {
                _logger.LogError("SeasonalModifier with ID {Id} not found.", id);
                return NotFound();
            }

            return new SeasonalModifierDto
            {
                SeasonalModifierId = id,
                Name = modifier.Name,
                Description = modifier.Description,
                ImageUrl = modifier.ImageUrl
            };
        }


        [HttpPost]
        public async Task<IActionResult> CreateSeasonalModifier(SeasonalModifierCreateDto SeasonalModifierCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state for account creation.");
                    return BadRequest(ModelState);
                }

                if (await _context.SeasonalModifiers.AnyAsync(m => m.Name == SeasonalModifierCreateDto.Name))
                {
                    return Conflict("SeasonalModifier already exists!");
                }

                var modifier = new SeasonalModifier
                {
                    Name = SeasonalModifierCreateDto.Name,
                    Description = SeasonalModifierCreateDto.Description,
                    SeasonalMapId = SeasonalModifierCreateDto.SeasonalMapId,
                    ImageUrl = SeasonalModifierCreateDto.ImageUrl
                };

                _logger.LogInformation("Creating Seasonal Modifier with Name: {Name}", modifier.Name);

                _context.SeasonalModifiers.Add(modifier);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Seasonal Modifier successfully created with ID: {Id}", modifier.SeasonalModifierId);

                return CreatedAtAction(nameof(GetSeasonalModifier), new { id = modifier.SeasonalModifierId }, new SeasonalModifierDto
                {
                    SeasonalModifierId = modifier.SeasonalModifierId,
                    Name = modifier.Name,
                    Description = modifier.Description,
                    ImageUrl = modifier.ImageUrl

                });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Seasonal Modifier.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the Seasonal Modifier.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeasonalModifier(int id, SeasonalModifierUpdateDto seasonalModifierUpdateDto)
        {
            try
            {
                if (seasonalModifierUpdateDto.SeasonalModifierId != id)
                {
                    return BadRequest("Map ID mismatch.");
                }

                var seasonalModifier = await _context.SeasonalModifiers.FindAsync(id);
                if (seasonalModifier == null)
                {
                    return NotFound($"Seasonal modifier with ID {id} not found.");
                }

                seasonalModifier.Name = seasonalModifierUpdateDto.Name;
                seasonalModifier.Description = seasonalModifierUpdateDto.Description;
                seasonalModifier.ImageUrl = seasonalModifierUpdateDto.ImageUrl;

                _logger.LogInformation("Updating seasonal modifier with Name {Name}.", seasonalModifier.Name);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Seasonal Modifier with ID {Id} successfully updated.", id);

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Database update error occurred while updating Seasonal Modifier with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the Seasonal Modifier.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeasonalModifier(int id)
        {
            try
            {
                var modifier = await _context.SeasonalModifiers.FindAsync(id);

                if (modifier == null)
                {
                    _logger.LogInformation($"Seasonal Modifier with ID {id} not found.");
                    return NotFound($"Seasonal Modifier with ID {id} not found.");
                }

                _logger.LogInformation("Deleting Seasonal Modifier with Name: {Name}", modifier.Name);

                _context.SeasonalModifiers.Remove(modifier);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Seasonal Modifier with ID {id} successfully deleted");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the Seasonal Modifier.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the Seasonal Modifier.");
            }
        }
    }
}
