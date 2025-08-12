using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StockRepository(ApplicationDBContext context) : IStockRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Stock> CreateStockAsync(PostStockDto postStockDto)
        {
            var stock = postStockDto.ToStockFromPostStockDto();
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<bool?> DeleteStockAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                return null;
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Stock>> GetAllStocksAsync(StockQueryObject query)
        {
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            var stocks = _context.Stocks.Include(c => c.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
                stocks = stocks.Where(x => x.CompanyName.Contains(query.CompanyName));
            else if (!string.IsNullOrWhiteSpace(query.Symbol))
                stocks = stocks.Where(x => x.Symbol.Contains(query.Symbol));

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                    stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                else if (query.SortBy.Equals("CompanyName", StringComparison.OrdinalIgnoreCase)) 
                    stocks = query.IsDescending ? stocks.OrderByDescending(s => s.CompanyName) : stocks.OrderBy(s => s.CompanyName) ;
            }
            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetStockByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Stock?> UpdateStockAsync(int id, PutStockDto putStockDto)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return null;
            }
            stock.Symbol = putStockDto.Symbol;
            stock.MarketCap = putStockDto.MarketCap;
            stock.Purchase = putStockDto.Purchase;
            stock.Industry = putStockDto.Industry;
            stock.CompanyName = putStockDto.CompanyName;
            stock.LastDiv = putStockDto.LastDiv;
            await _context.SaveChangesAsync();
            return stock;
        }
    }
}