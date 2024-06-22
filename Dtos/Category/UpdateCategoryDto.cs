using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        public string Title { get; set; }
    }
}
