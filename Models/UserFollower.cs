namespace BlogApi.Models
{
    public class UserFollower
    {
        public string UserId { get; set; }
        public User User { get; set; } // Navigation property for the followed user (followee)

        public string FollowerId { get; set; }
        public User follower { get; set; }
    }
}
