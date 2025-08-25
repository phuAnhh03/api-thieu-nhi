
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Tests.Stocks
{
    public class StockRepositoryTests
    {
        private async Task<ApplicationDBContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDBContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Stocks.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Stocks.Add(
                        new api.Models.Stock
                        {
                            Symbol = "T" + i,
                            CompanyName = "Test" + i,
                            Industry = "IT",
                            Purchase = 10 + i,
                            LastDiv = 5 + i,
                            MarketCap = 100 + i,
                            Comments = new List<api.Models.Comment>()
                        });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
        [Fact]
        public async Task StockRepository_GetAllStocks_ReturnsStocks()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var stockRepository = new api.Repositories.StockRepository(dbContext);
            //Act
            var stocks = await stockRepository.GetAllStocksAsync(new api.Helpers.StockQueryObject());
            //Assert
            Assert.NotNull(stocks);
            Assert.True(stocks.Count > 0);
        }
    }
}
