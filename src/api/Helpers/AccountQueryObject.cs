namespace api.Helpers
{
    public class AccountQueryObject
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set;} = 3;
    }
}