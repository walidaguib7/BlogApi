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
            return await context.comments
                .Include(c => c.user)
                .Include(c => c.post)
                .Include(c => c.commentLikes)
                .Include(c => c.user.files)
                .Include(c => c.replies)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ICollection<Comment>> GetComments()
        {
            var comments = await context.comments
                .Include(c => c.user)
                .Include(c => c.user.files)
                .Include(c => c.post)
                .Include(c => c.commentLikes)
                .Include(c => c.replies)
                .ToListAsync();

            return comments;
        }

        public async Task<Comment?> UpdateComment(int id, UpdateCommentDto commentDto)
        {
            var comment = await context.comments
                          .Include(c => c.user).Include(c => c.post)
                          .FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null) return null;

            comment.Content = commentDto.Content;
            
            await context.SaveChangesAsync();
            return comment;
        }
    }
}
