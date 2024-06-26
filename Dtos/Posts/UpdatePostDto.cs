using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Posts
{
    public class UpdatePostDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int categoryId { get; set; }

        public int? filesId { get; set; }

    }
}
