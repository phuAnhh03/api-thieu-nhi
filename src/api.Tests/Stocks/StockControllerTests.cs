using api.Controllers;
using api.Dtos.Stocks;
using api.Helpers;
using api.Interfaces;
using Shouldly;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace api.Tests.Stocks
{
    public class StockControllerTests
    {
        private readonly Mock<IStockService> _mockStockService;     
        private readonly StockController _controller;
        public StockControllerTests()
        {
            _mockStockService = new Mock<IStockService>();
            _controller = new StockController(_mockStockService.Object);
        }
        [Fact]
        public async Task StockController_GetAll_Stockdtos()
        {
            //Arrange
            var queryObject = new StockQueryObject{};
            var stockDtos = new List<GetStockDto>
            {
                new GetStockDto
                {
                    Symbol = "T1",
                    CompanyName = "Test1",
                },
                new GetStockDto
                {
                    Symbol = "T2",
                    CompanyName = "Test2"
                }
            };
            _mockStockService.Setup(s => s.ListAllStocksAsync(queryObject))
                .ReturnsAsync(stockDtos);

            //Act
            var result = await _controller.GetAll(queryObject);
            
            //Assert
            result.ShouldBeOfType<Microsoft.AspNetCore.Mvc.OkObjectResult>();
            var okResult = (OkObjectResult)result;
            okResult.StatusCode.ShouldBe(200);
            okResult.Value.ShouldBe(stockDtos);
        }
    }
}
