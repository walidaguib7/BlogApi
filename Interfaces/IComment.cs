using BlogApi.Dtos.Comments;
using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface IComment
    {
        public Task<List<Comment>> GetComments();
        public Task<Comment?> GetComment(int id);
        public Task<Comment?> CreateComment(Comment comment);

        public Task<Comment?> UpdateComment(int id, UpdateCommentDto commentDto);

        public Task<Comment?> DeleteComment(int id);
    }
}
