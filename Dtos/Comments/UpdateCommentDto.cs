using BlogApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Comments
{
    public class UpdateCommentDto
    {
        [Required]
        public string Content { get; set; }

        public int? FilesId { get; set; }
    }
}
