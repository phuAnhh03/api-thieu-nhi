using api.Dtos.Accounts;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class AccountRepository (UserManager<Account> userManager, SignInManager<Account> signInManager): IAccountRepository
    {
        private readonly UserManager<Account> _userManager = userManager;
        private readonly SignInManager<Account> _signInManager = signInManager;

        public async Task<bool> AccExistAsync(string userName, string email)
        {
            var nameExist = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            var emailExist = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (nameExist == null && emailExist == null) return false;
            return true;
        }

        public async Task<AccountActionResultDto> AddAccAsync(SignInDto signInDto)
        {
            var acc = new Account
            {
                UserName = signInDto.AppUserName,
                Email = signInDto.Email,
            };
            var result = new AccountActionResultDto{User = acc};
            var createAcc = await _userManager.CreateAsync(acc, signInDto.Password);
            if (createAcc.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(acc, "User");
                if (roleResult.Succeeded) result.Succeeded = true;
                else result.IdentityErrors = roleResult.Errors;
            }
            else result.IdentityErrors = createAcc.Errors; 
            return result;
        }

        public Task<AccountActionResultDto?> AddAdminAsync(SignInDto signInDto)
        {
            throw new NotImplementedException();
        }

        public Task<Account?> DetailAccByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountActionResultDto?> EditAccAsync(int id, SignInDto signInDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> ListAllAccAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AccountActionResultDto> LogInAsync(LogInDto logInDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == logInDto.AppUserNameOrEmail);
            if (user == null) user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == logInDto.AppUserNameOrEmail);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, logInDto.Password, false);
                return new AccountActionResultDto
                {
                    User = user,
                    Succeeded = result.Succeeded,
                    SignInErrors = result.ToString(),
                };
            }
            return new AccountActionResultDto
            {
                Succeeded = false,
            };
        }

        public Task<AccountActionResultDto?> RemoveAccAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}