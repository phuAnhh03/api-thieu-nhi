namespace api.Dtos.Accounts
{
    public class AccountStockOwnershipDto
    {
        public string UserName { get; set; } = string.Empty;
        public List<StockOwnershipDto> Ownerships { get; set; } = [];
    }
}