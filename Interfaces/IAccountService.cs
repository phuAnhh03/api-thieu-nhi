using api.Dtos.Account;
using api.Models;

namespace api.Interfaces
{
    public interface IAccountService
    {
        public Task<List<Account>> GetAllAccAsync();
        public Task<Account?> GetAccByIdAsync(int id);
        public Task<Account?> CreateAccAsync(SignInDto signInDto);
        public Task<Account?> UpdateAccAsync(int id, LogInDto logInDto);
        public Task<bool?> DeleteAccAsync(int id);
    }
}