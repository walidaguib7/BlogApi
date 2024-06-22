using BlogApi.Dtos.Category;
using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface ICategory
    {
        public Task<List<Category>> GetCategories();
        public Task<Category?> GetCategory(int id);
        public Task<Category?> CreateCategory(Category category);
        public Task<Category?> UpdateCategory(int id , UpdateCategoryDto categoryDto);
        public Task<Category?> DeleteCategory(int id);
    }
}
