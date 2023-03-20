using System.ComponentModel.DataAnnotations;

namespace SecureAPI.DTO
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
