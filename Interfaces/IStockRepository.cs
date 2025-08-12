using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllStocksAsync(StockQueryObject query);
        Task<Stock?> GetStockByIdAsync(int id);
        Task<Stock> CreateStockAsync(PostStockDto postStockDto);
        Task<Stock?> UpdateStockAsync(int id, PutStockDto putStockDto);
        Task<bool?> DeleteStockAsync(int id);
    }
}