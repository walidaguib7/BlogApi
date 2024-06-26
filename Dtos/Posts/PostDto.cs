using BlogApi.Models;
using System.Collections;

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

        public string Image { get; set; }

        public ICollection comments { get; set; } 
    }
}
