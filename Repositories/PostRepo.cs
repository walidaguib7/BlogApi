using BlogApi.Data;
using BlogApi.Dtos.Posts;
using BlogApi.Helpers;
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
                .Include(p => p.files)
                .Include(p => p.likes)
                .Include(p => p.user.likes)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Post>> GetPosts(PostQuery query)
        {
            var posts =   _context.posts.Include(p => p.comments)
                .Include(p => p.user)
                .Include(p => p.category)
                .Include(p => p.user.files)
                .Include(p => p.user.likes)
                .Include(p => p.files)
                .Include(p => p.likes)
                .AsQueryable();
            if (!string.IsNullOrEmpty(query.Title))
            {
                posts = posts.Where(b => b.Title.Contains(query.Title));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    posts = query.IsDescending ? posts.OrderByDescending(s => s.Title) : posts.OrderBy(s => s.Title);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.Limit;
            return await posts.Skip(skipNumber).Take(query.Limit).ToListAsync();
        }

        public async Task<Post?> UpdatePost(int id, UpdatePostDto postDto)
        {
            var post = await _context.posts.Include(p => p.comments)
                .Include(p => p.user)
                .Include(p => p.category)
                .Include(p => p.user.files)
                .Include(p => p.files)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (post == null) return null;
            post.Title = postDto.Title;
            post.Content = postDto.Content;
            post.CategoryId = postDto.categoryId;
            post.FilesId = (int)postDto.filesId;
            
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
