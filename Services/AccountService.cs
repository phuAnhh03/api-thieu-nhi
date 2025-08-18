using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Accounts;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
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

        public async Task<AccountActionResultDto?> CreateAdminAsync(SignInDto signInDto)
        {
            return await _accountRepository.AddAdminAsync(signInDto);
        }

        public async Task<AccountActionResultDto?> DeleteAccAsync(string userName)
        {
            var acc = await _accountRepository.RemoveAccAsync(userName);
            if (acc == null) return null;
            return acc;
        }

        public async Task<AccountStockOwnershipDto?> GetAccByUserNameAsync(string userName)
        {
            var acc = await _accountRepository.DetailAccByUserNameAsync(userName);
            if (acc == null) return null;
            return acc.ToAccountStockOwnership();
        }

        public async Task<List<Account>> GetAllAccAsync(AccountQueryObject query)
        {
            return await _accountRepository.ListAllAccAsync(query);
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

        public async Task<AccountActionResultDto?> UpdateAccAsync(string userName, SignInDto signInDto)
        {
            var acc = await _accountRepository.EditAccAsync(userName, signInDto);
            if (acc == null) return null;
            return acc;
        }
    }
}