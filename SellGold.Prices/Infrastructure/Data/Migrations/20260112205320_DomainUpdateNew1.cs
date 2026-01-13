using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellGold.Prices.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpdateNew1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PriceId",
                table: "PricePolicies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PriceProducts",
                columns: table => new
                {
                    PriceProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceProducts", x => x.PriceProductId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PricePolicies_PriceId",
                table: "PricePolicies",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PricePolicies_Prices_PriceId",
                table: "PricePolicies",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "PriceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PricePolicies_Prices_PriceId",
                table: "PricePolicies");

            migrationBuilder.DropTable(
                name: "PriceProducts");

            migrationBuilder.DropIndex(
                name: "IX_PricePolicies_PriceId",
                table: "PricePolicies");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "PricePolicies");
        }
    }
}
