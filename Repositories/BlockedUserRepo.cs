using BlogApi.Data;
using BlogApi.Helpers;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace BlogApi.Repositories
{
    public class BlockedUserRepo(ApplicationDBContext context , IFollow _followRepo) : IBlockedUser
    {
        private readonly ApplicationDBContext _context = context;
        private readonly IFollow followRepo = _followRepo;
        public async Task<BlockedUsers> BlockUser(BlockedUsers user)
        {
            try 
            {
                // the user I follow
                var user1 = await followRepo.GetFollow(user.userId, user.blockedUserId);
                var follow = await followRepo.UnFollow(user1!.UserId, user1.FollowerId);

                if(user1 == null || follow == null)
                {
                    Console.WriteLine("User or follow relationship not found!");
                }

            } catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                //The user who follows me
                var user2 = await followRepo.GetFollow(user.blockedUserId, user.userId);
                var follow = await followRepo.UnFollow(user2!.UserId, user2.FollowerId);

                if (user2 == null || follow == null)
                {
                    Console.WriteLine("User or follow relationship not found!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            

            await _context.blockedUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<List<BlockedUsers>> GetBlockedUsers(string id , UsersQuery query)
        {
            var users =  _context.blockedUsers
                .Include(b => b.blockedUser)
                .Include(b => b.blockedUser.files)
                .Where(b => b.userId == id)
                .AsQueryable();

            
            var skipNumber = (query.PageNumber - 1) * query.Limit;
            return await users.Skip(skipNumber).Take(query.Limit)
                .ToListAsync();

        }

        public async Task<BlockedUsers?> UnBlockUser(string id , string blockedId)
        {
            var blockedUser = await _context.blockedUsers
                .Where(b => b.userId == id && b.blockedUserId == blockedId)
                .FirstAsync();
            if (blockedUser == null) return null;
            _context.blockedUsers.Remove(blockedUser);
            await _context.SaveChangesAsync();
            return blockedUser;
        }
    }
}
