using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.User
{
    public class UpdatePasswordDto
    {
        [Required]
        [MinLength(12,ErrorMessage ="the password should have at least 12 caracters")]
        
        public string NewPassword { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
