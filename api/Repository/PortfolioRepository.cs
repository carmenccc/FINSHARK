using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;
        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();

            return portfolio;
        }

        public async Task<Portfolio> DeletePortfolio(AppUser user, string symbol)
        {
            var portfolioModel = await _context.Portfolios.FirstOrDefaultAsync(p => p.AppUserId == user.Id && p.Stock.Symbol.ToLower() == symbol.ToLower());

            if(portfolioModel == null)
            {
                return null;
            }

            _context.Portfolios.Remove(portfolioModel);
            await _context.SaveChangesAsync();
            return portfolioModel;
        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await _context.Portfolios
                    .Where(p => p.AppUserId == user.Id)
                    .Include(p => p.Stock)
                    .Select(p => p.Stock)
                    .ToListAsync();
        }
    }
}