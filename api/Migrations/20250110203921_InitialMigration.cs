using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastDiv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketCap = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Industry", "LastDiv", "MarketCap", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 1, "Apple Inc.", "Technology", 0.23m, 2500000000000L, 145.67m, "AAPL" },
                    { 2, "Microsoft Corporation", "Technology", 0.28m, 2200000000000L, 310.25m, "MSFT" },
                    { 3, "Tesla Inc.", "Automotive", 0.00m, 800000000000L, 680.50m, "TSLA" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, "Apple's recent earnings beat expectations.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Strong Earnings Report" },
                    { 2, "Microsoft's cloud revenue is growing steadily.", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Cloud Growth" },
                    { 3, "Tesla remains the leader in the EV market.", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "EV Leader" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StockId",
                table: "Comments",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
