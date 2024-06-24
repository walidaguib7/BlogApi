using BlogApi.Models;

namespace BlogApi.Dtos.Comments
{
    public class CreateCommentDto
    {

        public string Content { get; set; }
        public string UserId { get; set; }

        public int PostId { get; set; }

    }
}
