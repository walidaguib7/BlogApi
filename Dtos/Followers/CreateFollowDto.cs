using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Followers
{
    public class CreateFollowDto
    {
        [Required]
        public string userId { get; set; }

        [Required]
        public string followerId { get; set; }
    }
}
