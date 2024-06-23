namespace BlogApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
        public string UserId { get; set; }
        public User user { get; set; }

        public int PostId { get; set; }
        
        public Post post { get; set; }
    }
}
