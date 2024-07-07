using Microsoft.AspNetCore.Identity;
using System.Collections;


namespace BlogApi.Models
{
    public class User : IdentityUser
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string bio { get; set; }
        public int  filesId { get; set; }
        public FilesModel files { get; set; }
        public ICollection<LikesModel> likes { get; set; } = [];

        public ICollection<CommentLikes> commentLikes { get; set; } = [];

        public ICollection<UserFollower> followers { get; set; } = [];

    }
}
