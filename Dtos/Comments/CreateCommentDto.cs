using BlogApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Comments
{
    public class CreateCommentDto
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int PostId { get; set; }


    }
}
