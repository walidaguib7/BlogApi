using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface ILike
    {
        public Task<LikesModel> LikePost(LikesModel like);
        public Task<LikesModel?> Unlike(int PostId , string userId);
    }
}
