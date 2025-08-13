using api.Dtos.Account;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(UserManager<Account> userManager) : ControllerBase
    {
        private readonly UserManager<Account> _userManager = userManager;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignInDto signInDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInDto logInDto) {
            if (!ModelState.IsValid) return BadRequest(ModelState);

        }
    }
}