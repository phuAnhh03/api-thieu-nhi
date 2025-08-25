namespace api.Helpers
{
    public class CommentQueryObject
    {
        public string? Content { get; set; } = null;
        public string? Title { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set;} = 3;
    }
}