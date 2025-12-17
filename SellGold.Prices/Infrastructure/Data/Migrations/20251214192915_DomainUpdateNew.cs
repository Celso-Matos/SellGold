using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellGold.Prices.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpdateNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PriceTaxes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Prices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PricePolicies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PriceDiscounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PriceTaxes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PricePolicies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PriceDiscounts");
        }
    }
}
