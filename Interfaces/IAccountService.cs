using api.Dtos.Accounts;
using api.Models;

namespace api.Interfaces
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAccAsync();
        Task<Account?> GetAccByIdAsync(int id);
        Task<AccountActionResultDto> CreateAccAsync(SignInDto signInDto);
        Task<AccountActionResultDto?> UpdateAccAsync(int id, SignInDto signInDto);
        Task<AccountActionResultDto?> DeleteAccAsync(int id);
        Task<AccountActionResultDto?> CreateAdminAsync(LogInDto logInDto);
        Task<AccountActionResultDto> LogInAccAsync(LogInDto logInDto);
        AccountInfoDto GetAccountJwtDto(AccountActionResultDto accountActionResultDto);
    }
}