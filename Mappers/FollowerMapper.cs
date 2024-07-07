using BlogApi.Dtos.Followers;
using BlogApi.Models;

namespace BlogApi.Mappers
{
    public static class FollowerMapper
    {
        public static UserFollower ToUserFollower(this CreateFollowDto dto)
        {
            return new UserFollower 
            { 
                UserId = dto.userId,
                FollowerId = dto.followerId
            };
        }


        public static FollowerDto ToFollowerDto(this UserFollower follower)
        {
            return new FollowerDto
            {
                followerId = follower.FollowerId,
                UserName = follower.follower.UserName,
                ProfilePicture = follower.follower.files.Image
            };
        }

        public static FollowerDto ToFollowingDto(this UserFollower follower)
        {
            return new FollowerDto
            {
                followerId = follower.UserId,
                UserName = follower.User.UserName,
                ProfilePicture = follower.User.files.Image
            };
        }
    }
}
