using BlogApi.Dtos.Posts;
using BlogApi.Models;

namespace BlogApi.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToPostDto(this Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                username = post.user.UserName,
                CategoryTitle = post.category.Title,
                userpicture = post.user.files.Image,
                comments = [.. post.comments],
            };
        }

        public static Post ToPostModel(this CreatePostDto postDto)
        {
            return new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                UserId = postDto.userId ,
                CategoryId = postDto.categoryId,
                
            };
        }
    }
}
