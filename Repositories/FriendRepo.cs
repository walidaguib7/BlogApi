using BlogApi.Data;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class FriendRepo(ApplicationDBContext context) : IFriends
    {
        private readonly ApplicationDBContext _context = context;

        public Task<User> AddFriend(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteFriend(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
