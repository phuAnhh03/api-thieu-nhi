using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.Dtos.Stocks;
using api.Interfaces;
using api.Helpers;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController(IStockService stockService) : ControllerBase
    {
        private readonly IStockService _stockService = stockService;

        // GET list of all stocks and its information via dtos
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] StockQueryObject query)
        {
            var stockdtos = await _stockService.ListAllStocksAsync(query);
            return Ok(stockdtos);
        }

        // GET detail of one stock by id 
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            var stock = await _stockService.DetailStockByIdAsync(id);
            if (stock == null) return NotFound();
            return Ok(stock);
        }

        // POST a new stock
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostStockDto postStockDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var stock = await _stockService.AddStockAsync(postStockDto);
            return CreatedAtAction(nameof(GetId), new { id = stock.Id }, stock);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PutStockDto putStockDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var stock = await _stockService.EditStockAsync(id, putStockDto);    
            if (stock == null) return NotFound();
            return Ok(stock);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var stock = await _stockService.RemoveStockAsync(id);
            if (stock == null) return NotFound();
            return NoContent();
        }

        // [HttpPost("sell)]
    }
}
