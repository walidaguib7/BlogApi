namespace BlogApi.Helpers
{
    public class UsersQuery
    {
        public string Username { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;

        public int Limit { get; set; } = 20;
    }
}
