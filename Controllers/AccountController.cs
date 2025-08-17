using api.Dtos.Accounts;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(IAccountService accountService, ITokenService tokenService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignInDto signInDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _accountService.CreateAccAsync(signInDto);
                if (result.Succeeded != true) return StatusCode(500, result.IdentityErrors.Select(e => e.Description));
                return Ok(_accountService.GetAccountJwtDto(result));   
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInDto logInDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _accountService.LogInAccAsync(logInDto);
            if (result.Succeeded) return Ok(_accountService.GetAccountJwtDto(result));
            else return Unauthorized("Username or Email incorrect");
        }
    }
}