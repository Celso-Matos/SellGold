using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellGold.Stock.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEstoqueTablesUpdatesNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockLocationId",
                schema: "dbo",
                table: "Address");
        }
    }
}
