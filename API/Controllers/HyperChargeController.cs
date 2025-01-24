using API.Infrastructure.DTOs.CreateDTOs;
using API.Infrastructure.DTOs.UpdateDTOs;
using API.Infrastructure.DTOs;
using Common.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HyperChargeController : ControllerBase
    {
        private readonly BrawlstarsHelperDbContext _context;
        private readonly ILogger<HyperChargeController> _logger;

        public HyperChargeController(BrawlstarsHelperDbContext context, ILogger<HyperChargeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<HyperChargeDto>> GetHyperCharges()
        {

            return await _context.HyperCharges
                .Select(hc => new HyperChargeDto
                {
                    HyperChargeId = hc.HyperChargeId,
                    Name = hc.Name,
                    Description = hc.Description,
                    BrawlerId = hc.BrawlerId,
                    SpeedIncrease = hc.SpeedIncrease,
                    ShieldIncrease = hc.ShieldIncrease,
                    DamageIncrease = hc.DamageIncrease
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HyperChargeDto>> GetHyperCharge(int id)
        {
            var hypercharge = await _context.HyperCharges.FirstOrDefaultAsync(hc => hc.HyperChargeId == id);

            if (hypercharge == null)
            {
                _logger.LogError("Hypercharge with ID {Id} not found.", id);
                return NotFound();
            }

            return new HyperChargeDto
            {
                HyperChargeId = hypercharge.HyperChargeId,
                Name = hypercharge.Name,
                Description = hypercharge.Description,
                BrawlerId = hypercharge.BrawlerId,
                SpeedIncrease = hypercharge.SpeedIncrease,
                ShieldIncrease = hypercharge.ShieldIncrease,
                DamageIncrease = hypercharge.DamageIncrease
            };
        }


        [HttpPost]
        public async Task<IActionResult> CreateHyperCharge(HyperChargeCreateDto hyperChargeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state for hypercharge creation.");
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrWhiteSpace(hyperChargeDto.Name)|| 
                    await _context.HyperCharges.AnyAsync(hc => hc.Name.ToLower() == hyperChargeDto.Name.ToLower()))
                {
                    return Conflict("Hypercharge already exists!");
                }

                var hypercharge = new HyperCharge
                {
                    Name = hyperChargeDto.Name,
                    Description = hyperChargeDto.Description,
                    BrawlerId = hyperChargeDto.BrawlerId,
                    SpeedIncrease = hyperChargeDto.SpeedIncrease,
                    ShieldIncrease = hyperChargeDto.ShieldIncrease,
                    DamageIncrease = hyperChargeDto.DamageIncrease,
                };

                _logger.LogInformation("Creating hypercharge with Name: {Name}", hypercharge.Name);

                _context.HyperCharges.Add(hypercharge);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Modifier successfully created with ID: {Id}", hypercharge.HyperChargeId);

                return CreatedAtAction(nameof(GetHyperCharge), new { id = hypercharge.HyperChargeId}, new HyperChargeDto
                {
                    HyperChargeId = hypercharge.HyperChargeId,
                    Name = hypercharge.Name,
                    Description = hypercharge.Description,
                    SpeedIncrease = hypercharge.SpeedIncrease,
                    ShieldIncrease = hypercharge.ShieldIncrease,
                    DamageIncrease = hypercharge.DamageIncrease,
                });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the hypercharge.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the hypercharge.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHyperCharge(int id, HyperChargeUpdateDto hyperchargeUpdateDto)
        {
            try
            {
                if (id != hyperchargeUpdateDto.HyperChargeId)
                {
                    _logger.LogError("Mismatch between URL ID and payload ID - URL ID: {Id}, Payload ID: {PayloadId}", id, hyperchargeUpdateDto.HyperChargeId);
                    return BadRequest("Hypercharge ID mismatch.");
                }

                var hypercharge = await _context.HyperCharges.FirstOrDefaultAsync();
                if (hypercharge == null)
                {
                    _logger.LogInformation("Hypercharge with ID {Id} not found.", id);
                    return NotFound($"Hypercharge with ID {id} not found.");
                }

                hypercharge.Name = hyperchargeUpdateDto.Name;
                hypercharge.Description = hyperchargeUpdateDto.Description;
                hypercharge.SpeedIncrease = hyperchargeUpdateDto.SpeedIncrease;
                hypercharge.ShieldIncrease = hyperchargeUpdateDto.ShieldIncrease;
                hypercharge.DamageIncrease = hyperchargeUpdateDto.DamageIncrease;

                _logger.LogInformation("Updating hypercharge with name {Name}...", hypercharge.Name);
                _context.Update(hypercharge);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Hypercharge with ID {Id} successfully updated.", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating hypercharge with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHyperCharge (int id)
        {
            try
            {
                var hypercharge = await _context.HyperCharges.FindAsync(id);

                if (hypercharge == null)
                {
                    _logger.LogInformation($"Hypercharge with ID {id} not found.");
                    return NotFound($"Hypercharge with ID {id} not found.");
                }

                _logger.LogInformation("Deleting hypercharge with Name: {Name}", hypercharge.Name);

                _context.HyperCharges.Remove(hypercharge);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Hypercharge with ID {id} successfully deleted");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the hypercharge.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the hypercharge.");
            }
        }
    }
}
