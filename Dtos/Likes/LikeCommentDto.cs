using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Likes
{
    public class LikeCommentDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public int CommentId { get; set; }
    }
}
