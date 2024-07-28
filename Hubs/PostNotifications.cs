using BlogApi.Data;
using BlogApi.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Hubs
{
    public class PostNotifications(
        ApplicationDBContext _context , ILogger _logger) : Hub
    {

        private readonly ApplicationDBContext context = _context;
        private readonly ILogger logger = _logger;

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("connected");
            return base.OnConnectedAsync();
        }

        public async Task AddFollowersToSpecificgroup(string userId)
        {
            var myFollowers = await context.followers.Where(u => u.UserId == userId).ToListAsync();
            if (myFollowers.Count == 0) logger.Log(LogLevel.Information, "No user Found!");
            foreach (var user in myFollowers)
            {
                await Groups.AddToGroupAsync(userId, "userGroup");
            }
        }

        public async Task SendNotificationToFollowers(Post post)
        {
            await Clients.Group("userGroup").SendAsync("ReceivedNotification", post);
        }


    }
}
