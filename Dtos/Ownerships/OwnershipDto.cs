namespace api.Dtos.Ownerships
{
    public class OwnershipDto
    {
        public int Id { get; set;}
        public string AccountId { get; set; } = string.Empty;
        public int StockId { get; set; }
        public int Amount { get; set; }
    }
}