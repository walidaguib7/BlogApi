using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Likes
{
    public class LikePostDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public int PostId { get; set; }
    }
}
