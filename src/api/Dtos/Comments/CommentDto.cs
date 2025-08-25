namespace api.Dtos.Comments

{
    public class CommentDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int StockId { get; set; }
    }
}