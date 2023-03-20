using Microsoft.AspNetCore.Identity;

namespace SecureAPI.DTO
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
