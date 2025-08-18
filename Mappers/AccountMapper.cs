using api.Dtos.Accounts;
using api.Models;

namespace api.Mappers
{
    public static class AccountMapper
    {
        public static AccountStockOwnershipDto ToAccountStockOwnership(this Account acc)
        {
            if (acc.UserName == null) throw new ArgumentNullException(nameof(acc));
            return new AccountStockOwnershipDto
            {
                UserName = acc.UserName,
                Ownerships = acc.Ownerships.Select(o => new StockOwnershipDto
                {
                    Owned = o.Owned,
                    StockOwnedNames = o.Stock.CompanyName
                }).ToList()
            };
        }
    }
}