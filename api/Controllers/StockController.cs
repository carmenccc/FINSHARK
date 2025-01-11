using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var stocks = _context.Stocks.ToList()
            .Select(s => s.ToStockDto());
            
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var stock = _context.Stocks.Find(id);

            if (stock == null){
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto createDto){
            var newStock = createDto.ToStockFromCreateDto();
            _context.Stocks.Add(newStock);
            _context.SaveChanges();
                // The newStock object is populated with a new id right after the insertion(SaveChanges)

            // Generates a 201 Created HTTP response. 
            // It includes the location of the newly created resource in the Location header of the response.
            return CreatedAtAction(nameof(GetById), new { id = newStock.Id}, newStock.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){
            var oldStock = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if(oldStock == null){
                return NotFound();
            }

            oldStock.Symbol = updateDto.Symbol;
            oldStock.CompanyName = updateDto.CompanyName;
            oldStock.Purchase = updateDto.Purchase;
            oldStock.LastDiv = updateDto.LastDiv;
            oldStock.Industry = updateDto.Industry;
            oldStock.MarketCap = updateDto.MarketCap;
            
            _context.SaveChanges();

            return Ok(oldStock.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id){
            var stock = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if(stock == null){
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            _context.SaveChanges();

            // NotContent is a good response for HttpDelete request :)
            return NoContent();
        }
    }
}