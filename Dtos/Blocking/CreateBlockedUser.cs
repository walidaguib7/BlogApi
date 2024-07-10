using System.ComponentModel.DataAnnotations;


namespace BlogApi.Dtos.Blocking
{
    public class CreateBlockedUser
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string BlockedUserId { get; set; }
    }
}
