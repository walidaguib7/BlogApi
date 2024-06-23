using BlogApi.Data;
using BlogApi.Dtos.Posts;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class PostRepo(ApplicationDBContext context) : IPost
    {
        private readonly ApplicationDBContext _context = context;
        public async Task<Post?> CreatePost(Post post)
        {
            await _context.posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> DeletePost(int id)
        {
            var post = await _context.posts.FindAsync(id);
            if (post == null) return null;
            _context.posts.Remove(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> GetPost(int id)
        {
            return await _context.posts.Include(p => p.comments)
                .Include(p => p.category)
                .Include(p => p.user)
                .Include(p => p.user.files)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _context.posts.Include(p => p.comments)
                .Include(p => p.user)
                .Include(p => p.category)
                .Include(p => p.user.files)
                .ToListAsync();
        }

        public async Task<Post?> UpdatePost(int id, UpdatePostDto postDto)
        {
            var post = await _context.posts.Include(p => p.comments)
                .Include(p => p.user)
                .Include(p => p.category)
                .Include(p => p.user.files)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (post == null) return null;
            post.Title = postDto.Title;
            post.Content = postDto.Content;
            post.CategoryId = postDto.categoryId;
            
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
