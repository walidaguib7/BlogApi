using BlogApi.Models;

namespace BlogApi.Dtos.User
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string bio { get; set; }

        public int PictureId { get; set; }

        public string Picture { get; set; }
    }
}
