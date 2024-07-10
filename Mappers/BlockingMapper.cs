using BlogApi.Dtos.Blocking;
using BlogApi.Models;

namespace BlogApi.Mappers
{
    public static class BlockingMapper
    {
        public static BlockedUsers ToBlockedUser(this CreateBlockedUser user)
        {
            return new BlockedUsers
            {
                userId = user.UserId ,
                blockedUserId = user.BlockedUserId
            };
        }

        public static BlockedUserDto ToBlockedUserDto(this BlockedUsers users)
        {
            return new BlockedUserDto
            {
                Id = users.blockedUserId,
                userName = users.blockedUser.UserName,
                ProfilePicture = users.blockedUser.files.Image
            };
        }
    }
}
