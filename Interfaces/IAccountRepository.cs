using api.Dtos.Accounts;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> ListAllAccAsync(AccountQueryObject query);
        Task<Account?> DetailAccByUserNameAsync(string userName);
        Task<AccountActionResultDto> AddAccAsync(SignInDto signInDto);
        Task<AccountActionResultDto?> EditAccAsync(string userName, SignInDto signInDto);
        Task<AccountActionResultDto?> RemoveAccAsync(string userName);
        Task<bool> AccExistAsync(string userName, string email);
        Task<AccountActionResultDto?> AddAdminAsync(SignInDto signInDto);
        Task<AccountActionResultDto> LogInAsync(LogInDto logInDto);
    }
}