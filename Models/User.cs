using Microsoft.AspNetCore.Identity;

namespace BlogApi.Models
{
    public class User : IdentityUser
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string bio { get; set; }
        public int  filesId { get; set; }

        public FilesModel files { get; set; }
    }
}
