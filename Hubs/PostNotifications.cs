using BlogApi.Data;
using Microsoft.AspNet.SignalR;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Hubs
{
    public class PostNotifications(ApplicationDBContext _context) : Hub
    {
        private readonly ApplicationDBContext context = _context;
        
    }
}
