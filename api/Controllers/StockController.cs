using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
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
        private readonly IStockRepository _stockRepo;

        public StockController(ApplicationDBContext context,  IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var stocks = await _stockRepo.GetAllAsync();
            var stockDtos = stocks.Select(s => s.ToStockDto());
            
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null){
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto createDto){
            var newStock = createDto.ToStockFromCreateDto();
            await _stockRepo.CreateAsync(newStock);

            // Generates a 201 Created HTTP response. 
            // It includes the location of the newly created resource in the Location header of the response.
            return CreatedAtAction(nameof(GetById), new { id = newStock.Id}, newStock.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){
            var oldStock = await _stockRepo.UpdateAsync(id, updateDto);

            if(oldStock == null){
                return NotFound();
            }

            return Ok(oldStock.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var stock = await _stockRepo.DeleteAsync(id);

            if(stock == null){
                return NotFound();
            }

            // NotContent is a good response for HttpDelete request :)
            return NoContent();
        }
    }
}