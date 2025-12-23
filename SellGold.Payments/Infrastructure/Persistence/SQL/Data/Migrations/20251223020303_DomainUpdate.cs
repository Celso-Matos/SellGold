using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellGold.Payments.Infrastructure.Persistence.SQL.Data.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardBrand",
                table: "PaymentTransactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardLast4Digits",
                table: "PaymentTransactions",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentProvider",
                table: "Payments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardBrand",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "CardLast4Digits",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentProvider",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Payments");
        }
    }
}
