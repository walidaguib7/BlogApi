using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface ICommentLikes
    {
        public Task<CommentLikes> LikeComment(CommentLikes commentLikes);
        public Task<CommentLikes?> UnlikeComment(string userId , int commentId);
    }
}
