using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellGold.Stock.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpdateNew4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StockLocation_StockLocationId",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Address_StockLocationId",
                table: "Addresses",
                newName: "IX_Addresses_StockLocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_StockLocation_StockLocationId",
                table: "Addresses",
                column: "StockLocationId",
                principalTable: "StockLocation",
                principalColumn: "StockLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_StockLocation_StockLocationId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_StockLocationId",
                table: "Address",
                newName: "IX_Address_StockLocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StockLocation_StockLocationId",
                table: "Address",
                column: "StockLocationId",
                principalTable: "StockLocation",
                principalColumn: "StockLocationId");
        }
    }
}
