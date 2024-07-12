using BlogApi.Data;
using BlogApi.Helpers;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class FollowingRepo(ApplicationDBContext context) : IFollow
    {
        private readonly ApplicationDBContext _context = context;


        public async Task<UserFollower> Follow(UserFollower follow)
        {
            await _context.followers.AddAsync(follow);
            await _context.SaveChangesAsync();
            return follow;
        }

        public Task<UserFollower?> GetFollow(string userId, string followerId)
        {
            return _context.followers
                .Where(u => u.UserId == userId && u.FollowerId == followerId)
                .FirstAsync();
        }

        public async Task<List<UserFollower>> GetFollowers(string userId , UsersQuery query)
        {
            var followers = _context.followers
                .Include(u => u.follower)
                .Include(u => u.follower.files)
                .Where(u => u.UserId == userId).AsQueryable();

            if (!string.IsNullOrEmpty(query.Username) || !string.IsNullOrWhiteSpace(query.Username)) 
            {
                followers = followers.Where(f => f.follower.UserName.Contains(query.Username));
            }
            var skipNumber = (query.PageNumber - 1) * query.Limit;
            return await followers.Skip(skipNumber).Take(query.Limit)
                .ToListAsync();
        }

        public async Task<List<UserFollower>> GetFollowings(string userId , UsersQuery query)
        {
            var following =  _context.followers
                .Include(u => u.User)
                .Include(u => u.User.files)
                .Where(u => u.FollowerId == userId).AsQueryable();

            if (!string.IsNullOrEmpty(query.Username) || !string.IsNullOrWhiteSpace(query.Username))
            {
                following = following.Where(f => f.User.UserName.Contains(query.Username));
            }

            var skipNumber = (query.PageNumber - 1) * query.Limit;
            return await following.Skip(skipNumber).Take(query.Limit)
                .ToListAsync();


        }

        public async Task<UserFollower> UnFollow(string userId, string target)
        {
            var user = await _context.followers
                .Where(u => u.UserId == userId && u.FollowerId == target).FirstAsync();
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }


    }
}
