using BlogApi.Dtos.Likes;
using BlogApi.Models;

namespace BlogApi.Mappers
{
    public static class LikesMapper
    {
        public static LikesModel ToLikesModel(this LikePostDto postDto)
        {
            return new LikesModel
            {
                UserId = postDto.UserId,
                PostId = postDto.PostId
            };
        }

        public static LikePostDto ToLikeDto(this LikesModel likesModel)
        {
            return new LikePostDto
            { 
              PostId = likesModel.PostId,
              UserId = likesModel.UserId,
            };
        }
    }
}
