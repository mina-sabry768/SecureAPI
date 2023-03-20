using System.ComponentModel.DataAnnotations;

namespace SecureAPI.DTO
{
    public class NewRegister
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ComperPassword { get; set; }
    }
}
