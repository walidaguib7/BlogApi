using BlogApi.Dtos.Replies;
using BlogApi.Models;

namespace BlogApi.Mappers
{
    public static class RepliesMapper
    {
        public static ReplyDto ToReplyDto(this Replies replies)
        {
            return new ReplyDto
            {
                content = replies.content,
                userName = replies.user.UserName,
                userPicture = replies.user.files.Image
            };
        }

        public static Replies ToReplyModel(this CreateReplyDto dto)
        {
            return new Replies
            {
                content = dto.content,
                userId = dto.userId,
                commentId = dto.commentId
            };
        }
    }
}
