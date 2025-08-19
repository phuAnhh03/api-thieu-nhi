using api.Models;

namespace api.Dtos.Accounts
{
    public class AccountActionResultDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Succeeded { get; set; }
        public IEnumerable<string> IdentityErrors { get; set; } = [];
        public string SignInErrors { get; set; } = string.Empty;
    }
}