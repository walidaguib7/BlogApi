using BlogApi.Models;

namespace BlogApi.Dtos.Posts
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string username { get; set; }
        public string userpicture { get; set; }

        public string CategoryTitle { get; set; }

        public List<Comment> comments { get; set; } 
    }
}
