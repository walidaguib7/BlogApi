using BlogApi.Models;
using System.Collections;

namespace BlogApi.Dtos.Comments
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } 
        public string UserId { get; set; } 

        public string UserName { get; set; }

        public string ProfilePicture { get; set; }

        public ICollection likes { get; set; }

        public ICollection replies { get; set; }
    }
}
