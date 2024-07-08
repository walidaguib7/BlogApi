using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Replies
{
    public class UpdateReplyDto
    {
        [Required]
        public string content { get; set; }
    }
}
