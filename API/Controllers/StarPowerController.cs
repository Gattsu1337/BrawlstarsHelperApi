using API.Infrastructure.DTOs.CreateDTOs;
using API.Infrastructure.DTOs.UpdateDTOs;
using API.Infrastructure.DTOs;
using Common.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarPowerController : ControllerBase
    {
        private readonly BrawlstarsHelperDbContext _context;
        private readonly ILogger<StarPowerController> _logger;

        public StarPowerController(BrawlstarsHelperDbContext context, ILogger<StarPowerController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<StarPowerDto>> GetStarPowers()
        {

            _logger.LogInformation("Fetching star powers");

            return await _context.StarPowers
                .Select(m => new StarPowerDto
                {
                    StarPowerId = m.StarPowerId,
                    Name = m.Name,
                    Description = m.Description,
                    ImageUrl = m.ImageUrl,
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StarPowerDto>> GetStarPower(int id)
        {
            var starpower = await _context.StarPowers.FirstOrDefaultAsync(m => m.StarPowerId == id);

            if (starpower == null)
            {
                _logger.LogError("Star power with ID {Id} not found.", id);
                return NotFound();
            }

            return new StarPowerDto
            {
                StarPowerId = id,
                Name = starpower.Name,
                Description = starpower.Description,
                ImageUrl = starpower.ImageUrl,
            };
        }


        [HttpPost]
        public async Task<IActionResult> CreateStarPower(StarPowerCreateDto starpowerCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state for star power creation.");
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrWhiteSpace(starpowerCreateDto.Name) ||
                    await _context.StarPowers.AnyAsync(m => m.Name.ToLower() == starpowerCreateDto.Name.ToLower()))
                {
                    return Conflict("Star Power already exists!");
                }

                var starpower = new StarPower
                {
                    Name = starpowerCreateDto.Name,
                    Description = starpowerCreateDto.Description,
                    ImageUrl = starpowerCreateDto.ImageUrl,
                    BrawlerName = starpowerCreateDto.BrawlerName
                };

                _logger.LogInformation("Creating star power with Name: {Name}", starpower.Name);

                _context.StarPowers.Add(starpower);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Star power successfully created with ID: {Id}", starpower.StarPowerId);

                return CreatedAtAction(nameof(GetStarPower), new { id = starpower.StarPowerId }, new StarPowerDto
                {
                    StarPowerId = starpower.StarPowerId,
                    Name = starpower.Name,
                    Description = starpower.Description,
                    ImageUrl = starpower.ImageUrl,
                });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the star power.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the star power.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStarPower(int id, StarPowerDto starpowerUpdateDto)
        {
            try
            {
                if (id != starpowerUpdateDto.StarPowerId)
                {
                    _logger.LogError("Mismatch between URL ID and payload ID - URL ID: {Id}, Payload ID: {PayloadId}", id, starpowerUpdateDto.StarPowerId);
                    return BadRequest("Star power ID mismatch.");
                }

                var starpower = await _context.StarPowers.FirstOrDefaultAsync();
                if (starpower == null)
                {
                    _logger.LogInformation("Star power with ID {Id} not found.", id);
                    return NotFound($"STar power with ID {id} not found.");
                }

                starpower.Name = starpowerUpdateDto.Name;
                starpower.Description = starpowerUpdateDto.Description;
                starpower.ImageUrl = starpowerUpdateDto.ImageUrl;
                starpower.BrawlerName = starpowerUpdateDto.BrawlerName;

                _logger.LogInformation("Updating star power with name {Name}...", starpower.Name);
                _context.Update(starpower);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Star power with ID {Id} successfully updated.", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating star power with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStarPower(int id)
        {
            try
            {
                var starpower = await _context.StarPowers.FindAsync(id);

                if (starpower == null)
                {
                    _logger.LogInformation($"Star power with ID {id} not found.");
                    return NotFound($"Star power with ID {id} not found.");
                }

                _logger.LogInformation("Deleting star power with Name: {Name}", starpower.Name);

                _context.StarPowers.Remove(starpower);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Star power with ID {id} successfully deleted");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the star power.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the star power.");
            }
        }
    }
}
