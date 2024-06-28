using BlogApi.Data;
using BlogApi.Dtos.Comments;
using BlogApi.Helpers;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class CommentRepo(ApplicationDBContext _context) : IComment
    {
        private readonly ApplicationDBContext context = _context;

        public async Task<Comment?> CreateComment(Comment comment)
        {
            await context.comments.AddAsync(comment);
            await context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteComment(int id)
        {
            var comment = await context.comments.FindAsync(id);
            if (comment == null) return null;
            context.comments.Remove(comment);
            await context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> GetComment(int id)
        {
            return await  context.comments
                .Include(c => c.user)
                .Include(c => c.post)
                
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Comment>> GetComments(CommentQuery query)
        {
            var comments = context.comments
                .Include(c => c.user)
                .Include(c => c.post)
                
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    comments = query.IsDescending ? comments.OrderByDescending(s => s.Id) : comments.OrderBy(s => s.Id);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.Limit;
            return await comments.Skip(skipNumber).Take(query.Limit).ToListAsync();
        }

        public async Task<Comment?> UpdateComment(int id, UpdateCommentDto commentDto)
        {
            var comment = await context.comments
                          .Include(c => c.user).Include(c => c.post)
                          .FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null) return null;

            comment.Content = commentDto.Content;
            comment.UpdatedAt = DateTime.Today;
            
            await context.SaveChangesAsync();
            return comment;
        }
    }
}
