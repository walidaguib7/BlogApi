using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
