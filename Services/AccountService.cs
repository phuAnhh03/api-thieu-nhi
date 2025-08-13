using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class AccountService : IAccountService
    {
        public Task<Account?> CreateAccAsync(SignInDto signInDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteAccAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetAccByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> GetAllAccAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Account?> UpdateAccAsync(int id, LogInDto logInDto)
        {
            throw new NotImplementedException();
        }
    }
}