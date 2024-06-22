using BlogApi.Data;
using BlogApi.Dtos.Category;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class CategoryRepo : ICategory
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Category?> CreateCategory(Category category)
        {
            await _context.category.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategory(int id)
        {
            var category = await _context.category.FindAsync(id);
            if (category == null) return null;
            _context.category.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public Task<List<Category>> GetCategories()
        {
            return _context.category.ToListAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {
            var category = await _context.category.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return null;
            return category;
        }

        public async Task<Category?> UpdateCategory(int id, UpdateCategoryDto categoryDto)
        {
            var category = await _context.category.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return null;
            category.Title = categoryDto.Title;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
