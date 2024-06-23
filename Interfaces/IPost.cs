using BlogApi.Dtos.Posts;
using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface IPost
    {
        public Task<List<Post>> GetPosts();
        public Task<Post?> GetPost(int id);
        public Task<Post?> CreatePost(Post post);
        public Task<Post?> UpdatePost(int id , UpdatePostDto postDto);
        public Task<Post?> DeletePost(int id);
    }
}
