using api.Dtos.Stocks;
using api.Models;  
namespace api.Mappers
{
    public static class StockMappers
    {
        public static GetStockDto ToGetStockDto(this Stock stock)
        {
            return new GetStockDto
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Industry = stock.Industry,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                MarketCap = stock.MarketCap,
                Comments = stock.Comments.Select(c => c.ToGetCommentDto()).ToList(),
            };
        }

        public static Stock ToStockFromPostStockDto(this PostStockDto postStockDto)
        {
            return new Stock
            {
                Symbol = postStockDto.Symbol,
                CompanyName = postStockDto.CompanyName,
                Industry = postStockDto.Industry,
                Purchase = postStockDto.Purchase,
                LastDiv = postStockDto.LastDiv,
                MarketCap = postStockDto.MarketCap
            };
        }
    }
}