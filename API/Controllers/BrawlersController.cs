using API.Infrastructure;
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
    public class BrawlersController : ControllerBase
    {
        private readonly BrawlstarsHelperDbContext _context;
        private readonly ILogger<BrawlersController> _logger;

        public BrawlersController(BrawlstarsHelperDbContext context, ILogger<BrawlersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<BrawlerDto>> GetBrawlers()
        {
            //var starPowerDtos = _context.StarPowers.Select(sp => new StarPowerDto
            //{
            //    StarPowerId = sp.StarPowerId,
            //    Name = sp.Name,
            //    Description = sp.Description,
            //    ImageUrl = sp.ImageUrl
            //}).ToList();

            return await _context.Brawlers
                .Select(b => new BrawlerDto
                {
                    BrawlerId = b.BrawlerId,
                    Name = b.Name,
                    Description = b.Description,
                    Type = b.Type,
                    Rarity = b.Rarity,
                    ImageUrl = b.ImageUrl,
                    //StarPowers = starPowerDtos
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrawlerDto>> GetBrawler(int id)
        {
            var brawler = await _context.Brawlers.FirstOrDefaultAsync(b => b.BrawlerId == id);

            if (brawler == null)
            {
                _logger.LogError($"Brawler with {id} not found.");
                return NotFound();
            }

            //var starPowerDtos = brawler.StarPowers.Select(sp => new StarPowerDto
            //{
            //    StarPowerId = sp.StarPowerId,
            //    Name = sp.Name,
            //    Description = sp.Description,
            //    ImageUrl = sp.ImageUrl
            //}).ToList();

            return new BrawlerDto
            {
                BrawlerId = brawler.BrawlerId,
                Name = brawler.Name,
                Description = brawler.Description,
                Type = brawler.Type,
                Rarity = brawler.Rarity,
                ImageUrl = brawler.ImageUrl,
                //StarPowers= starPowerDtos
            };
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrawler(BrawlerCreateDto brawlerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state for brawler creation.");
                    return BadRequest(ModelState);
                }

                if(await _context.Brawlers.AnyAsync(b => b.Name == brawlerDto.Name))
                {
                    return Conflict("Brawler already exists!");
                }


                var brawler = new Brawler
                {
                    Name = brawlerDto.Name,
                    Type = brawlerDto.Type,
                    Rarity = brawlerDto.Rarity,
                    Description = brawlerDto.Description,
                    ImageUrl = brawlerDto.ImageUrl,
                    Health = brawlerDto.Health,
                    Attack = brawlerDto.Attack,
                    MovementSpeed = brawlerDto.MovementSpeed,
                    ReloadSpeed = brawlerDto.ReloadSpeed,
                    Range = brawlerDto.Range,
                    //StarPowers = brawlerDto.StarPowers,
                    //HyperCharge = brawlerDto.HyperCharge == null ? null : new HyperCharge
                    //{
                    //    Name = brawlerDto.HyperCharge.Name,
                    //    Description = brawlerDto.HyperCharge.Description,
                    //    BrawlerId = brawlerDto.HyperCharge.BrawlerId,
                    //    SpeedIncrease = brawlerDto.HyperCharge.SpeedIncrease,
                    //    DamageIncrease = brawlerDto.HyperCharge.DamageIncrease,
                    //    ShieldIncrease = brawlerDto.HyperCharge.ShieldIncrease,
                    //}
                };

                _logger.LogInformation("Creating brawler with Name: {Name}", brawlerDto.Name);

                _context.Brawlers.Add(brawler);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Brawler successfully created with ID: {Id}", brawler.BrawlerId);

                //var starPowerDtos = brawler.StarPowers.Select(sp => new StarPowerDto
                //{
                //    StarPowerId = sp.StarPowerId,
                //    Name = sp.Name,
                //    Description = sp.Description,
                //    ImageUrl = sp.ImageUrl
                //}).ToList();

                return CreatedAtAction(nameof(GetBrawler), new { id = brawler.BrawlerId }, new BrawlerDto
                {
                    BrawlerId = brawler.BrawlerId,
                    Name = brawler.Name,
                    Description = brawler.Description,
                    ImageUrl = brawler.ImageUrl,
                    Type = brawler.Type,
                    Rarity = brawler.Rarity,
                    Health = brawlerDto.Health,
                    Attack = brawlerDto.Attack,
                    MovementSpeed = brawlerDto.MovementSpeed,
                    ReloadSpeed = brawlerDto.ReloadSpeed,
                    Range = brawlerDto.Range,
                    //StarPowers = starPowerDtos,
                    //HyperCharge = brawlerDto.HyperCharge == null ? null : new HyperChargeDto
                    //{
                    //    HyperChargeId = brawler.HyperCharge.HyperChargeId,
                    //    Name = brawlerDto.HyperCharge.Name,
                    //    Description = brawlerDto.HyperCharge.Description,
                    //    BrawlerId = brawlerDto.HyperCharge.BrawlerId,
                    //    SpeedIncrease = brawlerDto.HyperCharge.SpeedIncrease,
                    //    DamageIncrease = brawlerDto.HyperCharge.DamageIncrease,
                    //    ShieldIncrease = brawlerDto.HyperCharge.ShieldIncrease,
                    //}
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the brawler.");
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the brawler.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrawler(int id, BrawlerUpdateDto brawlerUpdateDto)
        {
            try
            {
                if (id != brawlerUpdateDto.BrawlerId)
                {
                    _logger.LogError("Mismatch between URL ID and payload ID - URL ID: {Id}, Payload ID: {PayloadId}", id, brawlerUpdateDto.BrawlerId);
                    return BadRequest("Brawler ID mismatch.");
                }

                var brawler = await _context.Brawlers.FirstOrDefaultAsync();
                if (brawler == null)
                {
                    _logger.LogInformation("Brawler with ID {Id} not found.", id);
                    return NotFound($"Brawler with ID {id} not found.");
                }

                brawler.Name = brawlerUpdateDto.Name;
                brawler.Description = brawlerUpdateDto.Description;
                brawler.ImageUrl = brawlerUpdateDto.ImageUrl;
                brawler.Type = brawlerUpdateDto.Type;
                brawler.Rarity = brawlerUpdateDto.Rarity;
                brawler.Attack = brawlerUpdateDto.Attack;
                brawler.Health = brawlerUpdateDto.Health;
                brawler.Range = brawlerUpdateDto.Range;
                brawler.ReloadSpeed = brawlerUpdateDto.ReloadSpeed;
                brawler.MovementSpeed = brawlerUpdateDto.MovementSpeed;
                //brawler.StarPowers = brawlerUpdateDto.StarPowers;
                //if (brawlerUpdateDto.HyperCharge != null) brawler.HyperCharge = brawlerUpdateDto.HyperCharge;


                _logger.LogInformation("Updating Brawler with name {Name}...", brawler.Name);
                _context.Update(brawler);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Brawler with ID {Id} successfully updated.", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating Brawler with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrawler(int id)
        {
            try
            {
                var brawler = await _context.Brawlers.FindAsync(id);

                if(brawler == null)
                {
                    _logger.LogInformation($"Brawler with ID {id} not found.");
                    return NotFound($"Brawler with ID {id} not found.");
                }

                _logger.LogInformation("Deleting brawler with Name: {Name}", brawler.Name);

                _context.Brawlers.Remove(brawler);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Brawler with ID {id} successfully deleted.");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the brawlers.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the brawlers.");
            }
        }
    }
}
