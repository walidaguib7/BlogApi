using BlogApi.Models;
using System.Collections;

namespace BlogApi.Dtos.Comments
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UserId { get; set; }

        public string userName { get; set; }

        public ICollection likes { get; set; }





    }
}
