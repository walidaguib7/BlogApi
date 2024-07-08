namespace BlogApi.Models
{
    public class Replies
    {
        public int Id { get; set; }
        public string content { get; set; }
        public string userId { get; set; }
        public User user { get; set; }
        public int commentId { get; set; }
        public Comment comment { get; set; }
    }
}
