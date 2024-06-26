namespace BlogApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UserId { get; set; }

        public int PostId { get; set; }
        public int? FilesId { get; set; }
        public User user { get; set; }

        public Post post { get; set; }

        public FilesModel files { get; set; }
    }
}
