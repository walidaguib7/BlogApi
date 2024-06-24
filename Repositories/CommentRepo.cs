using BlogApi.Data;
using BlogApi.Dtos.Comments;
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

        public Task<Comment?> GetComment(int id)
        {
            return context.comments
                .Include(c => c.user)
                .Include(c => c.post)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Comment>> GetComments()
        {
            return context.comments
                .Include(c => c.user)
                .Include(c => c.post)
                .ToListAsync();
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
