﻿using BlogApi.Dtos.Comments;
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
                UserName = comment.user.UserName,
                ProfilePicture = comment.user.files.Image,
                UserId = comment.UserId,
                likes = comment.commentLikes.Select(cl => cl.ToLikeCommentDto()).ToList(),
                replies = comment.replies.Select(r => r.ToReplyDto()).ToList()
                

            };
        }

        public static Comment ToCommentModel(this CreateCommentDto commentDto)
        {
            return new Comment
            {
                Content = commentDto.Content,
                UserId = commentDto.UserId,
                PostId = commentDto.PostId,
                
                
            };
        }
    }
}
