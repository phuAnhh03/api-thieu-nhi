using api.Dtos.Stocks;
using api.Helpers;
using api.Interfaces;
using api.Mappers;

namespace api.Services
{
    public class StockService(IStockRepository stockRepository): IStockService 
    {
        private readonly IStockRepository _stockRepository = stockRepository;

        public async Task<IEnumerable<GetStockDto>> ListAllStocksAsync(StockQueryObject query)
        {
            var stocks = await _stockRepository.GetAllStocksAsync(query);
            return stocks.Select(stock => stock.ToGetStockDto());
        }

        public async Task<GetStockDto?> DetailStockByIdAsync(int id)
        {
            var stock = await _stockRepository.GetStockByIdAsync(id);
            if (stock == null) return null;
            return stock.ToGetStockDto();
        }

        public async Task<GetStockDto> AddStockAsync(PostStockDto postStockDto)
        {
            var stock = await _stockRepository.CreateStockAsync(postStockDto);
            return stock.ToGetStockDto();
        }

        public async Task<GetStockDto?> EditStockAsync(int id, PutStockDto putStockDto)
        {
            var stock = await _stockRepository.UpdateStockAsync(id, putStockDto);
            if (stock == null) return null;
            return stock.ToGetStockDto();
        }

        public async Task<bool?> RemoveStockAsync(int id)
        {
            return await _stockRepository.DeleteStockAsync(id);
        }
    }
}