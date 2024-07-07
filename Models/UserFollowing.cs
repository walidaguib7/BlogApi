namespace BlogApi.Models
{
    public class UserFollowing
    {
        public string UserId { get; set; }
        public User User { get; set; } // Navigation property for the user

        public string FollowingId { get; set; }
        public User following { get; set; }
    }
}
