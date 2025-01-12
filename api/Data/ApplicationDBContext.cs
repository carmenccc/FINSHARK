using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        // Data set i.e. tables
        public DbSet<Stock> Stocks {get; set;}
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        // Seeding Dummy Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many to many relationship
            modelBuilder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId}));
            modelBuilder.Entity<Portfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.AppUserId);
            modelBuilder.Entity<Portfolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.StockId);

            modelBuilder.Entity<Stock>().HasData(
                new Stock
                {
                    Id = 1,
                    Symbol = "AAPL",
                    CompanyName = "Apple Inc.",
                    Purchase = 145.67m,
                    LastDiv = 0.23m,
                    Industry = "Technology",
                    MarketCap = 2500000000000
                },
                new Stock
                {
                    Id = 2,
                    Symbol = "MSFT",
                    CompanyName = "Microsoft Corporation",
                    Purchase = 310.25m,
                    LastDiv = 0.28m,
                    Industry = "Technology",
                    MarketCap = 2200000000000
                },
                new Stock
                {
                    Id = 3,
                    Symbol = "TSLA",
                    CompanyName = "Tesla Inc.",
                    Purchase = 680.50m,
                    LastDiv = 0.00m,
                    Industry = "Automotive",
                    MarketCap = 800000000000
                }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Title = "Strong Earnings Report",
                    Content = "Apple's recent earnings beat expectations.",
                    CreatedOn = new DateTime(2025, 1, 1),
                    StockId = 1
                },
                new Comment
                {
                    Id = 2,
                    Title = "Cloud Growth",
                    Content = "Microsoft's cloud revenue is growing steadily.",
                    CreatedOn = new DateTime(2025, 1, 3),
                    StockId = 2
                },
                new Comment
                {
                    Id = 3,
                    Title = "EV Leader",
                    Content = "Tesla remains the leader in the EV market.",
                    CreatedOn = new DateTime(2025, 1, 5),
                    StockId = 3
                }
            );

            // Seed identity role data
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "d9b6f39f-761d-4f12-9fcd-92c44cc11d91",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                 new IdentityRole
                {
                    Id = "8c8d5b1e-46ef-497e-900e-f1c0f8b7a0d6",
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}