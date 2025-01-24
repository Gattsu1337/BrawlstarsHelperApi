using API.Infrastructure.DTOs.CreateDTOs;
using API.Infrastructure.Dtos;
using API.Services;
using Common.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using API.Infrastructure.DTOs.AuthDTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BrawlstarsHelperDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<AuthController> _logger;

        public AuthController(BrawlstarsHelperDbContext context, IPasswordHasher passwordHesher, ILogger<AuthController> logger)
        {
            _context = context;
            _passwordHasher = passwordHesher;
            _logger = logger;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(AccountCreateDto accountCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state for registration.");
                    return BadRequest(ModelState);
                }

                if (await _context.Accounts.AnyAsync(a => a.Username == accountCreateDto.Username))
                {
                    return Conflict("Username is already taken!");
                }

                if (await _context.Accounts.AnyAsync(a => a.Email == accountCreateDto.Email))
                {
                    return Conflict("Email is already taken!");
                }


                var hashedPassword = _passwordHasher.HashPassword(accountCreateDto.Password);

                var account = new Account
                {
                    Username = accountCreateDto.Username,
                    Email = accountCreateDto.Email,
                    Password = hashedPassword
                };

                _logger.LogInformation("Creating account with Username: {Username}", account.Username);

                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Account successfully created with ID: {Id}", account.AccountId);

                return CreatedAtAction("GetAccount", "Accounts", new { id = account.AccountId }, new AccountDto
                {
                    AccountId = account.AccountId,
                    Username = account.Username,
                    Email = account.Email
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the account.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the account.");
            }
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto, [FromServices]TokenService tokenService)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == loginDto.Username || a.Email == loginDto.Username);

            if (account == null || !_passwordHasher.VerifyPassword(account.Password, loginDto.Password))
            {
                _logger.LogWarning("Invalid login attempt for Username/Email: {Username}", loginDto.Username);
                return Unauthorized("Invalid username or password.");
            }

            var token = tokenService.GenerateToken(account.Username /*TODO, roles*/);

            _logger.LogInformation("User {Username} successfully logged in.", account.Username);

            return Ok(new { Token = token });
        }
    }
}
