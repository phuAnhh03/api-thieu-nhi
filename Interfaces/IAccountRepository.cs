
using api.Dtos.Accounts;
using api.Models;

namespace api.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> ListAllAccAsync();
        Task<Account?> DetailAccByIdAsync(int id);
        Task<AccountActionResultDto> AddAccAsync(SignInDto signInDto);
        Task<AccountActionResultDto?> EditAccAsync(int id, SignInDto signInDto);
        Task<AccountActionResultDto?> RemoveAccAsync(int id);
        Task<bool> AccExistAsync(string userName, string email);
        Task<AccountActionResultDto?> AddAdminAsync(SignInDto signInDto);
        Task<AccountActionResultDto> LogInAsync(LogInDto logInDto);


    }
}