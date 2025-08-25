using api.Dtos.Accounts;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignInDto signInDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _accountService.CreateAccAsync(signInDto);
                if (result.Succeeded != true) return StatusCode(500, result.IdentityErrors);
                return Ok(_accountService.GetAccountJwtDto(result.Id, result.UserName, result.Email));
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
            if (result.Succeeded) return Ok(_accountService.GetAccountJwtDto(result.Id,result.UserName, result.Email));
            else return Unauthorized("Username or Email incorrect");
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUserName([FromRoute] string username)
        {
            var result = await _accountService.GetAccByUserNameAsync(username);
            if (result == null) return BadRequest("Username not found");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AccountQueryObject query)
        {
            var accounts = await _accountService.GetAllAccAsync(query);
            return Ok(accounts);
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> Put([FromRoute] string userName, [FromBody] SignInDto signInDto)
        {
            var account = await _accountService.UpdateAccAsync(userName, signInDto);
            if (account == null) return BadRequest("Username not found");
            return Ok(account);
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete([FromRoute] string userName)
        {
            var account = await _accountService.DeleteAccAsync(userName);
            if (account == null) return BadRequest("Username not found");
            return NoContent();
        }
    }
}