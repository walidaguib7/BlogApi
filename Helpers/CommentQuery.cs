namespace BlogApi.Helpers
{
    public class CommentQuery
    {
        public string? SortBy { get; set; } = null;

        public bool IsDescending { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int Limit { get; set; } = 20;
    }
}
