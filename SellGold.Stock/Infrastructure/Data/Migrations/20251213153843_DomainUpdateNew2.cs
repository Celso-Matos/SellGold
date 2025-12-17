using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellGold.Stock.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpdateNew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "StockProduct",
                schema: "dbo",
                newName: "StockProduct");

            migrationBuilder.RenameTable(
                name: "StockMovement",
                schema: "dbo",
                newName: "StockMovement");

            migrationBuilder.RenameTable(
                name: "StockLocation",
                schema: "dbo",
                newName: "StockLocation");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "dbo",
                newName: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "StockProduct",
                newName: "StockProduct",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "StockMovement",
                newName: "StockMovement",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "StockLocation",
                newName: "StockLocation",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Addresses",
                newSchema: "dbo");
        }
    }
}
