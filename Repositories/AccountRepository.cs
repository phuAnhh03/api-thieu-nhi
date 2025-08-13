using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<Account?> AddAccAsync(SignInDto signInDto)
        {
            var acc = new Account
            {
                UserName = signInDto.AppUserName,
                Email = signInDto.Email
            };
            throw new NotImplementedException();
            
        }

        public Task<Account?> DetailAccByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account?> EditAccAsync(int id, SignInDto signInDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> ListAllAccAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RemoveAccAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}