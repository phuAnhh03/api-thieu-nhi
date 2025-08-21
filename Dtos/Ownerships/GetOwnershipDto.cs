namespace api.Dtos.Ownerships
{
    public class GetOwnershipDto
    {
        public string AccountId { get; set; } = string.Empty;
        public int StockId { get; set; }
        public int Amount { get; set; }
    }
}