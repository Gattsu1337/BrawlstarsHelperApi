using API.Infrastructure.Dtos;
using API.Infrastructure.DTOs.CreateDTOs;
using API.Infrastructure.DTOs.UpdateDTOs;
using API.Services;
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
    public class AccountsController : ControllerBase
    {
        private readonly BrawlstarsHelperDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(BrawlstarsHelperDbContext context, IPasswordHasher passwordHesher, ILogger<AccountsController> logger)
        {
            _context = context;
            _passwordHasher = passwordHesher;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AccountDto>> GetAccounts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation("Fetching accounts with pagination - Page: {Page}, PageSize: {PageSize}", page, pageSize);

            return await _context.Accounts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new AccountDto
                {
                    AccountId = a.AccountId,
                    Username = a.Username,
                    Email = a.Email,
                    ImageUrl = a.ImageUrl
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccount(int id)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountId == id);

            if (account == null)
            {
                _logger.LogError("Account with ID {Id} not found.", id);
                return NotFound();
            }

            return new AccountDto
            {
                AccountId = account.AccountId,
                Username = account.Username,
                Email = account.Email,
                ImageUrl = account.ImageUrl
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, AccountUpdateDto accountUpdateDto)
        {
            try
            {
                if (accountUpdateDto.AccountId != id)
                {
                    return BadRequest("Map ID mismatch.");
                }

                var account = await _context.Accounts.FindAsync(id);
                if (account == null)
                {
                    return NotFound($"Seasonal modifier with ID {id} not found.");
                }

                account.Username = accountUpdateDto.Username;
                account.Email = accountUpdateDto.Email;
                account.ImageUrl = accountUpdateDto.ImageUrl;

                _logger.LogInformation("Updating Account with Username {Username}.", account.Username);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Account with ID {Id} successfully updated.", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Database update error occurred while updating Account with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the Seasonal Modifier.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(id);

                if (account == null)
                {
                    _logger.LogInformation($"Account with ID {id} not found.");
                    return NotFound($"Account with ID {id} not found.");
                }

                _logger.LogInformation("Deleting account with Username: {Username}", account.Username);

                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Account with ID {id} successfully deleted.");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the account.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the account.");
            }
        }
    }
}
