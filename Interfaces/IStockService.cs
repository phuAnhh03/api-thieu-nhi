using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<GetStockDto>> ListAllStocksAsync(StockQueryObject query);
        Task<Stock?> DetailStockByIdAsync(int id);
        Task<Stock> AddStockAsync(PostStockDto postStockDto);
        Task<Stock?> EditStockAsync(int id, PutStockDto putStockDto);
        Task<bool?> RemoveStockAsync(int id);
    }
}