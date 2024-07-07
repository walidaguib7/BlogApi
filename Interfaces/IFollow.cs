using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface IFollow
    {
        public Task<List<UserFollower>> GetFollowers(string userId);
        public Task<List<UserFollower>> GetFollowings(string userId);

        public Task<UserFollower> GetFollow(string userId, string followerId);

        public Task<UserFollower> Follow(UserFollower follow);
        public Task<UserFollower> UnFollow(string userId, string target);
    }
}
