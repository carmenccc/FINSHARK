using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPortfolioRepository _portfolioRepo;
        private readonly IStockRepository _stockRepo;
        
        public PortfolioController(UserManager<AppUser> userManager, IPortfolioRepository portfolioRepo, IStockRepository stockRepo)
        {
            _userManager = userManager;
            _portfolioRepo = portfolioRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            // Find the user: get username from claim, use UserManager
            var username = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(username);

            // Get all the portfolios of this user: use Repository method
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

            // Return user portfolios
            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            // Find the user & stock
            var username = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepo.GetBySymbolAsync(symbol);

            if (stock == null) return BadRequest("Stock not found");

            // Check for repetitive add
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
            if (userPortfolio.Any(stock => stock.Symbol.ToLower() == symbol.ToLower()))
                return BadRequest("Stock already exists in your portfolio.");
            
            // Create new portfolio
            var portfolioModel = new Portfolio
            {
                AppUserId = appUser.Id,
                StockId = stock.Id
            };

            portfolioModel = await _portfolioRepo.CreateAsync(portfolioModel);

            if (portfolioModel == null)
            {
                return StatusCode(500, "Could not create");
            }
            else{
                return Created();
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            // Find user
            var username = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(username);

            // Find user portfolio
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

            // Filter the stock to delete
            var stockToDelete = userPortfolio.Where(stock => stock.Symbol.ToLower() == symbol.ToLower()).ToList();

            if(stockToDelete.Count == 1)
            {
                await _portfolioRepo.DeletePortfolio(appUser, symbol);
            }
            else
            {
                return BadRequest("Stock not in your portfolio");
            }

            return Ok();
        }

    }
}