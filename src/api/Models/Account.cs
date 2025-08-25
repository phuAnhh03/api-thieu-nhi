using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class Account : IdentityUser
    {
        public List<Ownership> Ownerships { get; set; } = new List<Ownership>();
    }
}