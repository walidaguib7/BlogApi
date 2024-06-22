using BlogApi.Dtos.Category;
using BlogApi.Models;

namespace BlogApi.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto { Id = category.Id, Title = category.Title };
        }

        public static Category ToCategoryModel(this CreateCategoryDto categoryDto)
        {
            return new Category { Title = categoryDto.Title };
        }
    }
}
