using BlogApi.Data;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class LikesRepo(ApplicationDBContext context) : ILike
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<LikesModel> LikePost(LikesModel like)
        {
            await _context.likes.AddAsync(like);
            await _context.SaveChangesAsync();
            return like;
        }

        public async Task<LikesModel?> Unlike(int PostId, string userId)
        {
            var like = await _context.likes.Where(l => l.PostId == PostId && l.UserId == userId).FirstAsync();
            if (like == null) return null;
            _context.Remove(like);
            await _context.SaveChangesAsync();
            return like;
        }
    }
}
