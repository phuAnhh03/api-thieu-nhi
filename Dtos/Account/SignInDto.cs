using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Account
{
    public class SignInDto
    {
        [Required]
        [MinLength(1)]
        public string AppUserName { get; set; } = string.Empty;
        [Required]
        [MinLength(4)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

    }
}