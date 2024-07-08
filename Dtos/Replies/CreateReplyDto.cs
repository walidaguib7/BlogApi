using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Replies
{
    public class CreateReplyDto
    {
        [Required]
        public string content { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public int commentId { get; set; }
    }
}
