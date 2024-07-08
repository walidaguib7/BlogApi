using BlogApi.Data;
using BlogApi.Dtos.Replies;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class RepliesRepo(ApplicationDBContext context) : IReply
    {
        private readonly ApplicationDBContext _context = context;
        public async Task<Replies> CreateReply(Replies replies)
        {
            await _context.replies.AddAsync(replies);
            await _context.SaveChangesAsync();
            return replies;
        }

        public async Task<Replies?> DeleteReply(int id)
        {
            var reply = await _context.replies.FindAsync(id);
            if (reply == null) return null;
            _context.replies.Remove(reply);
            await _context.SaveChangesAsync();
            return reply;
        }

        public async Task<List<Replies>> GetReplies()
        {
            return await _context.replies
                .Include(r => r.user)
                .Include(r => r.comment)
                .Include(r => r.user.files)
                .ToListAsync();
        }



        public async Task<Replies> UpdateReply(int id, UpdateReplyDto dto)
        {
            var reply = await _context.replies.FindAsync(id);
            if (reply == null) return null;
            reply.content = dto.content;
            await _context.SaveChangesAsync();
            return reply;
        }
    }
}
