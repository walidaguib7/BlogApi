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


        public static CommentLikes ToCommentLikes(this LikeCommentDto dto)
        {
            return new CommentLikes
            {
                UserId = dto.UserId,
                CommentId = dto.CommentId
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


        public static LikeCommentDto ToLikeCommentDto(this CommentLikes commentLikes)
        {
            return new LikeCommentDto
            {
                UserId = commentLikes.UserId ,
                CommentId = commentLikes.CommentId
            };
        }
    }
}
