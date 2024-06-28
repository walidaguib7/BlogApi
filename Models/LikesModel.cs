

namespace BlogApi.Models
{

    public class LikesModel
    {
        
        public string UserId { get; set; }
        public int PostId { get; set; }

        public User users { get; set; }

        public Post posts { get; set; }
        
    }
}
