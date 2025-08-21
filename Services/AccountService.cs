using api.Dtos.Accounts;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Services
{
    public class AccountService(
        IAccountRepository accountRepository,
        UserManager<Account> userManager,
        SignInManager<Account> signInManager,
        ITokenService tokenService) : IAccountService
    {
        private readonly UserManager<Account> _userManager = userManager;
        private readonly SignInManager<Account> _signInManager = signInManager;
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly ITokenService _tokenService = tokenService;
        public async Task<AccountActionResultDto> CreateAccAsync(SignInDto signInDto)
        {
            var acc = new Account
            {
                UserName = signInDto.AppUserName,
                Email = signInDto.Email,
                Ownerships = new List<Ownership>()
            };
            var result = new AccountActionResultDto{UserName = acc.UserName, Email = acc.Email};
            var createAcc = await _userManager.CreateAsync(acc, signInDto.Password);
            if (createAcc.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(acc, "User");
                if (roleResult.Succeeded) result.Succeeded = true;
                else result.IdentityErrors = roleResult.Errors.Select(e => e.Description);
            }
            else result.IdentityErrors = createAcc.Errors.Select(e => e.Description); 
            result.Id = acc.Id;
            return result;
        }

        public async Task<AccountActionResultDto?> CreateAdminAsync(SignInDto signInDto)
        {
            var acc = new Account
            {
                UserName = signInDto.AppUserName,
                Email = signInDto.Email,
            };
            var result = new AccountActionResultDto{UserName = acc.UserName, Email = acc.Email};
            var createAcc = await _userManager.CreateAsync(acc, signInDto.Password);
            if (createAcc.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(acc, "Admin");
                if (roleResult.Succeeded) result.Succeeded = true;
                else result.IdentityErrors = roleResult.Errors.Select(e => e.Description);
            }
            else result.IdentityErrors = createAcc.Errors.Select(e => e.Description); 
            result.Id = acc.Id;
            return result;
        }

        public async Task<AccountActionResultDto?> DeleteAccAsync(string userName)
        {
            var acc = await _accountRepository.DetailAccByUserNameAsync(userName);
            if (acc == null) return null;
            var result = await _userManager.DeleteAsync(acc);
            return new AccountActionResultDto
            {
                Succeeded = result.Succeeded,
                IdentityErrors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<AccountStockOwnershipDto?> GetAccByUserNameAsync(string userName)
        {
            var acc = await _accountRepository.DetailAccByUserNameAsync(userName);
            if (acc == null) return null;
            return acc.ToAccountStockOwnership();
        }

        public async Task<List<AccountStockOwnershipDto>> GetAllAccAsync(AccountQueryObject query)
        {
            var list = await _accountRepository.ListAllAccAsync(query);
            return list.Select(x => x.ToAccountStockOwnership()).ToList();
        }

        public GetJwtDto GetAccountJwtDto(string id, string username, string email)
        {
            var acc = new GetJwtDto
            {
                Id = id,
                UserName = username,
                Email = email,
                Token = _tokenService.CreateToken(username, email)
            };
            return acc;
        }

        public async Task<AccountActionResultDto> LogInAccAsync(LogInDto logInDto)
        {
            var user = await _accountRepository.DetailAccByUserNameAsync(logInDto.AppUserNameOrEmail);
            if (user == null) user = await _accountRepository.DetailAccByEmailAsync(logInDto.AppUserNameOrEmail);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, logInDto.Password, false);
                return new AccountActionResultDto
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    Succeeded = result.Succeeded,
                    SignInErrors = result.ToString(),
                };
            }
            return new AccountActionResultDto
            {
                Succeeded = false,
            };
        }

        public async Task<AccountActionResultDto?> UpdateAccAsync(string userName, SignInDto signInDto)
        {
            var acc = await _accountRepository.DetailAccByUserNameAsync(userName);
            if (acc == null) return null;
            var token = await _userManager.GeneratePasswordResetTokenAsync(acc);
            var result = await _userManager.ResetPasswordAsync(acc, token, signInDto.Password);
            var setUserNameResult = await _userManager.SetUserNameAsync(acc, signInDto.AppUserName);
            var setEmailResult = await _userManager.SetEmailAsync(acc, signInDto.Email);
            return new AccountActionResultDto
            {
                Id = acc.Id,
                UserName = acc.UserName!,
                Email = acc.Email!,
                Succeeded = result.Succeeded,
                IdentityErrors = result.Errors.Select(e => e.Description)
            };
        }
    }
}