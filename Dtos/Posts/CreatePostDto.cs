using BlogApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Posts
{
    public class CreatePostDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int categoryId { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public int filesId { get; set; }
    }
}
