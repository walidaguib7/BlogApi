namespace BlogApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }

        public int CategoryId { get; set; }

        public User user { get; set; }

        public Category category { get; set; }

        public List<Comment> comments { get; set; } = [];
    }
}
