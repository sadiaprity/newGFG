using System.ComponentModel.DataAnnotations;

namespace evaluation2.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
        public string? OptionalPhone { get; set; }
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
