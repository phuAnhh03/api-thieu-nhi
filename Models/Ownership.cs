namespace api.Models
{
    public class Ownership
    {
        public int Id { get; set;}
        public int Owned { get; set; }
        public string AccountId { get; set; } = string.Empty;
        public Account Account { get; set; } = null!;
        public int StockId { get; set; }
        public Stock Stock { get; set; } = null!;
    }
}