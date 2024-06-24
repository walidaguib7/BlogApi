using BlogApi.Dtos.Comments;
using BlogApi.Models;

namespace BlogApi.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                UserId = comment.UserId,
                PostId = comment.PostId,
                UpdatedAt = comment.UpdatedAt,
                userName = comment.user.UserName,
                
                
            };
        }

        public static Comment ToCommentModel(this CreateCommentDto commentDto)
        {
            return new Comment
            {
                Content = commentDto.Content,
                CreatedAt = DateTime.Today,
                UpdatedAt = null,
                UserId = commentDto.UserId,
                PostId = commentDto.PostId                
            };
        }
    }
}
