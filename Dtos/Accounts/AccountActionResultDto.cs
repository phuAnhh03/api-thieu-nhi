using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Dtos.Accounts
{
    public class AccountActionResultDto
    {
        public Account User { get; set; } = new Account();
        public bool Succeeded { get; set; }
        public IEnumerable<IdentityError> IdentityErrors { get; set; } = [];
        public string SignInErrors { get; set; } = string.Empty;
    }
}