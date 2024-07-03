using BlogApi.Data;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class CommentLikesRepo : ICommentLikes
    {
        private readonly ApplicationDBContext _context;
        public CommentLikesRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<CommentLikes> LikeComment(CommentLikes commentLikes)
        {
            await _context.commentLikes.AddAsync(commentLikes);
            await _context.SaveChangesAsync();
            return commentLikes;
        }

        public async Task<CommentLikes?> UnlikeComment(string userId, int commentId)
        {
            var comment = await _context.commentLikes.Where(l => l.UserId == userId && l.CommentId == commentId).FirstAsync();
            if (comment == null) return null;
            _context.commentLikes.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
