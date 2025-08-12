using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;

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

        public async Task<Stock?> DetailStockByIdAsync(int id)
        {
            var stock = await _stockRepository.GetStockByIdAsync(id);
            return stock;
        }

        public async Task<Stock> AddStockAsync(PostStockDto postStockDto)
        {
            var stock = await _stockRepository.CreateStockAsync(postStockDto);
            return stock;
        }

        public async Task<Stock?> EditStockAsync(int id, PutStockDto putStockDto)
        {
            var stock = await _stockRepository.UpdateStockAsync(id, putStockDto);
            return stock;
        }

        public async Task<bool?> RemoveStockAsync(int id)
        {
            return await _stockRepository.DeleteStockAsync(id);
        }
    }
}