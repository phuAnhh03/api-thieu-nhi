using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Accounts;
using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class AccountService(IAccountRepository accountRepository, ITokenService tokenService) : IAccountService
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly ITokenService _tokenService = tokenService;
        public async Task<AccountActionResultDto> CreateAccAsync(SignInDto signInDto)
        {
            return await _accountRepository.AddAccAsync(signInDto);
        }

        public Task<AccountActionResultDto?> CreateAdminAsync(LogInDto logInDto)
        {
            throw new NotImplementedException();
        }

        public Task<AccountActionResultDto?> DeleteAccAsync(int id)
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

        public AccountInfoDto GetAccountJwtDto(AccountActionResultDto accountActionResultDto)
        {
            var acc = new AccountInfoDto
            {
                UserName = accountActionResultDto.User.UserName,
                Email = accountActionResultDto.User.Email,
                Token = _tokenService.CreateToken(accountActionResultDto.User)
            };
            return acc;
        }

        public async Task<AccountActionResultDto> LogInAccAsync(LogInDto logInDto)
        {
            return await _accountRepository.LogInAsync(logInDto);
        }

        public Task<AccountActionResultDto?> UpdateAccAsync(int id, SignInDto signInDto)
        {
            throw new NotImplementedException();
        }
    }
}