using api.Dtos.Accounts;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IAccountService
    {
        Task<List<AccountStockOwnershipDto>> GetAllAccAsync(AccountQueryObject query);
        Task<AccountStockOwnershipDto?> GetAccByUserNameAsync(string userName);
        Task<AccountActionResultDto> CreateAccAsync(SignInDto signInDto);
        Task<AccountActionResultDto?> UpdateAccAsync(string userName, SignInDto signInDto);
        Task<AccountActionResultDto?> DeleteAccAsync(string userName);
        Task<AccountActionResultDto?> CreateAdminAsync(SignInDto signInDto);
        Task<AccountActionResultDto> LogInAccAsync(LogInDto logInDto);
        GetJwtDto GetAccountJwtDto(string id, string username, string email);
    }
}