using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.User
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string bio { get; set; }

    }
}
