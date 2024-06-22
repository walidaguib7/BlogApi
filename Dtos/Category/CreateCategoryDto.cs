using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Category
{
    public class CreateCategoryDto
    
    {
        [Required]
        public string Title { get; set; }
    }
}
