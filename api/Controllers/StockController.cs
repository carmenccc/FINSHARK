using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll(){
            var stocks = await _context.Stocks.ToListAsync();
            var stockDtos = stocks.Select(s => s.ToStockDto());
            
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null){
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto createDto){
            var newStock = createDto.ToStockFromCreateDto();
            await _context.Stocks.AddAsync(newStock);
            await _context.SaveChangesAsync();
                // The newStock object is populated with a new id right after the insertion(SaveChanges)

            // Generates a 201 Created HTTP response. 
            // It includes the location of the newly created resource in the Location header of the response.
            return CreatedAtAction(nameof(GetById), new { id = newStock.Id}, newStock.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){
            var oldStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(oldStock == null){
                return NotFound();
            }

            oldStock.Symbol = updateDto.Symbol;
            oldStock.CompanyName = updateDto.CompanyName;
            oldStock.Purchase = updateDto.Purchase;
            oldStock.LastDiv = updateDto.LastDiv;
            oldStock.Industry = updateDto.Industry;
            oldStock.MarketCap = updateDto.MarketCap;
            
            await _context.SaveChangesAsync();

            return Ok(oldStock.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(stock == null){
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            // NotContent is a good response for HttpDelete request :)
            return NoContent();
        }
    }
}