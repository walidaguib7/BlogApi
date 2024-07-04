using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface IFriends
    {
        public Task<User> AddFriend(User user);
        public Task<User> DeleteFriend(string Id);
    }
}
