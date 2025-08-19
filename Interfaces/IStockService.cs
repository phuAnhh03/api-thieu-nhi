using api.Dtos.Stocks;
using api.Helpers;

namespace api.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<GetStockDto>> ListAllStocksAsync(StockQueryObject query);
        Task<GetStockDto?> DetailStockByIdAsync(int id);
        Task<GetStockDto> AddStockAsync(PostStockDto postStockDto);
        Task<GetStockDto?> EditStockAsync(int id, PutStockDto putStockDto);
        Task<bool?> RemoveStockAsync(int id);
    }
}