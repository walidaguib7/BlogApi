using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Followers
{
    public class FollowingDto
    {
        [Required]
        public string followerId { get; set; }

        [Required]
        public string followingId { get; set; }
    }
}
