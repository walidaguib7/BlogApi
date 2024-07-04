using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.User
{
    public class NewUser
    {
        public string UserId { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        
        
        public string first_name { get; set; }
        
        public string last_name { get; set; }
        
        public string bio { get; set; }
        
        public int PictureId { get; set; }

        public string Picture { get; set; }

        public string Token { get; set; }

        public ICollection friends { get; set; }
    }
}
