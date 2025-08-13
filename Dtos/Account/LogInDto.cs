using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Account
{
    public class LogInDto
    {
        [Required]
        public string AppUserNameOrEmail { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}