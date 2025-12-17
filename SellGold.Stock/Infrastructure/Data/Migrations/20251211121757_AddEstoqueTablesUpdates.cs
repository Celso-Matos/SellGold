using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellGold.Stock.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEstoqueTablesUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "dbo",
                table: "StockProduct");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "dbo",
                table: "StockMovement",
                newName: "StockProductId");

            migrationBuilder.AddColumn<Guid>(
                name: "StockProductId",
                schema: "dbo",
                table: "StockLocation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_StockProductId",
                schema: "dbo",
                table: "StockMovement",
                column: "StockProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockLocation_StockProductId",
                schema: "dbo",
                table: "StockLocation",
                column: "StockProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockLocation_StockProduct_StockProductId",
                schema: "dbo",
                table: "StockLocation",
                column: "StockProductId",
                principalSchema: "dbo",
                principalTable: "StockProduct",
                principalColumn: "StockProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_StockProduct_StockProductId",
                schema: "dbo",
                table: "StockMovement",
                column: "StockProductId",
                principalSchema: "dbo",
                principalTable: "StockProduct",
                principalColumn: "StockProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockLocation_StockProduct_StockProductId",
                schema: "dbo",
                table: "StockLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_StockProduct_StockProductId",
                schema: "dbo",
                table: "StockMovement");

            migrationBuilder.DropIndex(
                name: "IX_StockMovement_StockProductId",
                schema: "dbo",
                table: "StockMovement");

            migrationBuilder.DropIndex(
                name: "IX_StockLocation_StockProductId",
                schema: "dbo",
                table: "StockLocation");

            migrationBuilder.DropColumn(
                name: "StockProductId",
                schema: "dbo",
                table: "StockLocation");

            migrationBuilder.RenameColumn(
                name: "StockProductId",
                schema: "dbo",
                table: "StockMovement",
                newName: "ProductId");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                schema: "dbo",
                table: "StockProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
