namespace BlogApi.Models
{
    public class CommentLikes
    {
        public string UserId { get; set; }

        public int CommentId { get; set; }

        public User users { get; set; }

        public Comment comments { get; set; }
    }
}
