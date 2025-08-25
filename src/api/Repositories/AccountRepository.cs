using api.Dtos.Accounts;
using api.Helpers;
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

        // public async Task<bool> AccExistAsync(string userName, string email)
        // {
        //     var nameExist = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        //     var emailExist = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
        //     if (nameExist == null && emailExist == null) return false;
        //     return true;
        // }

        // public async Task<AccountActionResultDto> AddAccAsync(SignInDto signInDto)
        // {
        //     var acc = new Account
        //     {
        //         UserName = signInDto.AppUserName,
        //         Email = signInDto.Email,
        //     };
        //     var result = new AccountActionResultDto{User = acc};
        //     var createAcc = await _userManager.CreateAsync(acc, signInDto.Password);
        //     if (createAcc.Succeeded)
        //     {
        //         var roleResult = await _userManager.AddToRoleAsync(acc, "User");
        //         if (roleResult.Succeeded) result.Succeeded = true;
        //         else result.IdentityErrors = roleResult.Errors.Select(e => e.Description);
        //     }
        //     else result.IdentityErrors = createAcc.Errors.Select(e => e.Description); 
        //     return result;
        // }

        // public async Task<AccountActionResultDto?> AddAdminAsync(SignInDto signInDto)
        // {
        //     var acc = new Account
        //     {
        //         UserName = signInDto.AppUserName,
        //         Email = signInDto.Email,
        //     };
        //     var result = new AccountActionResultDto{User = acc};
        //     var createAcc = await _userManager.CreateAsync(acc, signInDto.Password);
        //     if (createAcc.Succeeded)
        //     {
        //         var roleResult = await _userManager.AddToRoleAsync(acc, "Admin");
        //         if (roleResult.Succeeded) result.Succeeded = true;
        //         else result.IdentityErrors = roleResult.Errors.Select(e => e.Description);
        //     }
        //     else result.IdentityErrors = createAcc.Errors.Select(e => e.Description); 
        //     return result;
        // }

        public async Task<Account?> DetailAccByUserNameAsync(string userName)
        {
            var acc = await _userManager.Users
            .Include(u => u.Ownerships)
            .ThenInclude(o => o.Stock)
            .FirstOrDefaultAsync(u => u.UserName == userName);
            return acc;
        }
        
        public async Task<Account?> DetailAccByEmailAsync(string email)
        {
            var acc = await _userManager.Users
            .Include(u => u.Ownerships)
            .ThenInclude(o => o.Stock)
            .FirstOrDefaultAsync(u => u.Email == email);
            return acc;
        }

        // public async Task<AccountActionResultDto?> EditAccAsync(string userName, SignInDto signInDto)
        // {
        //     var acc = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        //     if (acc == null) return null;
        //     var token = await _userManager.GeneratePasswordResetTokenAsync(acc);
        //     var result = await _userManager.ResetPasswordAsync(acc, token, signInDto.Password);
        //     var setUserNameResult = await _userManager.SetUserNameAsync(acc, signInDto.AppUserName);
        //     var setEmailResult = await _userManager.SetEmailAsync(acc, signInDto.Email);
        //     return new AccountActionResultDto
        //     {
        //         User = acc,
        //         Succeeded = result.Succeeded,
        //         IdentityErrors = result.Errors.Select(e => e.Description)
        //     };
        // }

        public async Task<List<Account>> ListAllAccAsync(AccountQueryObject query)
        {
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            var accounts = _userManager.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.UserName))
                accounts = accounts.Where(c => c.UserName != null && c.UserName!.Contains(query.UserName));
            else if (!string.IsNullOrWhiteSpace(query.Email))
                accounts = accounts.Where(c => c.Email != null && c.Email!.Contains(query.Email));
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("UserName", StringComparison.OrdinalIgnoreCase))
                    accounts = query.IsDescending ? accounts.OrderByDescending(s => s.UserName) : accounts.OrderBy(s => s.UserName);
                else if (query.SortBy.Equals("Email", StringComparison.OrdinalIgnoreCase))
                    accounts = query.IsDescending ? accounts.OrderByDescending(s => s.Email) : accounts.OrderBy(s => s.Email);
            }
            return await accounts.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        // public async Task<AccountActionResultDto> LogInAsync(LogInDto logInDto)
        // {
        //     var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == logInDto.AppUserNameOrEmail);
        //     if (user == null) user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == logInDto.AppUserNameOrEmail);
        //     if (user != null)
        //     {
        //         var result = await _signInManager.CheckPasswordSignInAsync(user, logInDto.Password, false);
        //         return new AccountActionResultDto
        //         {
        //             User = user,
        //             Succeeded = result.Succeeded,
        //             SignInErrors = result.ToString(),
        //         };
        //     }
        //     return new AccountActionResultDto
        //     {
        //         Succeeded = false,
        //     };
        // }

        // public async Task<AccountActionResultDto?> RemoveAccAsync(string userName)
        // {
        //     var acc = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        //     if (acc == null) return null;
        //     var result = await _userManager.DeleteAsync(acc);
        //     return new AccountActionResultDto
        //     {
        //         Succeeded = result.Succeeded,
        //         IdentityErrors = result.Errors.Select(e => e.Description)
        //     };
        // }
    }
}