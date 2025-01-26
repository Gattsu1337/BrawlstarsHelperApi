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
    public class ModifiersController : ControllerBase
    {
        private readonly BrawlstarsHelperDbContext _context;
        private readonly ILogger<ModifiersController> _logger;

        public ModifiersController(BrawlstarsHelperDbContext context, ILogger<ModifiersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ModifierDto>> GetModifiers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {

            _logger.LogInformation("Fetching modifiers with pagination - Page: {Page}, PageSize: {PageSize}", page, pageSize);

            return await _context.Modifiers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new ModifierDto
                {
                    ModifierId = m.ModifierId,
                    Name = m.Name,
                    Description = m.Description,
                    ImageUrl = m.ImageUrl,
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModifierDto>> GetModifier(int id)
        {
            var modifier = await _context.Modifiers.FirstOrDefaultAsync(m => m.ModifierId == id);

            if (modifier == null)
            {
                _logger.LogError("Modifier with ID {Id} not found.", id);
                return NotFound();
            }

            return new ModifierDto
            {
                ModifierId = id,
                Name = modifier.Name,
                Description = modifier.Description,
                ImageUrl = modifier.ImageUrl,
            };
        }


        [HttpPost]
        public async Task<IActionResult> CreateModifier(ModifierCreateDto ModifierCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state for modifier creation.");
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrWhiteSpace(ModifierCreateDto.Name) ||
                    await _context.Modifiers.AnyAsync(m => m.Name.ToLower() == ModifierCreateDto.Name.ToLower()))
                {
                    return Conflict("Modifier already exists!");
                }

                var modifier = new Modifier
                {
                    Name = ModifierCreateDto.Name,
                    Description = ModifierCreateDto.Description,
                    ImageUrl = ModifierCreateDto.ImageUrl,
                };

                _logger.LogInformation("Creating modifier with Name: {Name}", modifier.Name);

                _context.Modifiers.Add(modifier);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Modifier successfully created with ID: {Id}", modifier.ModifierId);

                return CreatedAtAction(nameof(GetModifier), new { id = modifier.ModifierId }, new ModifierDto
                {
                    ModifierId = modifier.ModifierId,
                    Name = modifier.Name,
                    Description = modifier.Description,
                    ImageUrl = modifier.ImageUrl,
                });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the modifier.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the modifier.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModifier(int id, ModifierUpdateDto modifierUpdateDto)
        {
            try
            {
                if (id != modifierUpdateDto.ModifierId)
                {
                    _logger.LogError("Mismatch between URL ID and payload ID - URL ID: {Id}, Payload ID: {PayloadId}", id, modifierUpdateDto.ModifierId);
                    return BadRequest("Modifier ID mismatch.");
                }

                var modifier = await _context.Modifiers.FirstOrDefaultAsync();
                if (modifier == null)
                {
                    _logger.LogInformation("Modifier with ID {Id} not found.", id);
                    return NotFound($"Modifier with ID {id} not found.");
                }

                modifier.Name = modifierUpdateDto.Name;
                modifier.Description = modifierUpdateDto.Description;
                modifier.ImageUrl = modifierUpdateDto.ImageUrl;

                _logger.LogInformation("Updating modifier with name {Name}...", modifier.Name);
                _context.Update(modifier);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Modifier with ID {Id} successfully updated.", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating modifier with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModifier(int id)
        {
            try
            {
                var modifier = await _context.Modifiers.FindAsync(id);

                if (modifier == null)
                {
                    _logger.LogInformation($"Modifier with ID {id} not found.");
                    return NotFound($"Modifier with ID {id} not found.");
                }

                _logger.LogInformation("Deleting modifier with Name: {Name}", modifier.Name);

                _context.Modifiers.Remove(modifier);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Modifier with ID {id} successfully deleted");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the modifier.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the modifier.");
            }
        }
    }
}
