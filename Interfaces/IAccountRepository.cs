
using api.Dtos.Account;
using api.Models;

namespace api.Interfaces
{
    public interface IAccountRepository
    {
        public Task<List<Account>> ListAllAccAsync();
        public Task<Account?> DetailAccByIdAsync(int id);
        public Task<Account?> AddAccAsync(SignInDto signInDto);
        public Task<Account?> EditAccAsync(int id, SignInDto signInDto);
        public Task<bool?> RemoveAccAsync(int id);
    }
}