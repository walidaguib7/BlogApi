using BlogApi.Dtos.Replies;
using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface IReply
    {
        public Task<List<Replies>> GetReplies();

        public Task<Replies> CreateReply(Replies replies);
        public Task<Replies> UpdateReply(int id, UpdateReplyDto dto);
        public Task<Replies?> DeleteReply(int id);
    }
}
