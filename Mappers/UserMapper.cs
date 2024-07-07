
using BlogApi.Dtos.User;
using BlogApi.Models;

namespace BlogApi.Mappers
{
    public static class UserMapper
    {
        
        public static NewUser ToUserDto(this User user)
        {
            return new NewUser
            {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email,
                first_name = user.first_name,
                last_name = user.last_name,
                bio = user.bio,
                Picture = user.files.Image,
                PictureId = user.filesId,

            };
        }
    }
}
