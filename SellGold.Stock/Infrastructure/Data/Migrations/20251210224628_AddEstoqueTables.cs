using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellGold.Stock.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEstoqueTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "StockLocation",
                schema: "dbo",
                columns: table => new
                {
                    StockLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockLocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLocation", x => x.StockLocationId);
                });

            migrationBuilder.CreateTable(
                name: "StockMovement",
                schema: "dbo",
                columns: table => new
                {
                    StockMovementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateMovement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountMovement = table.Column<int>(type: "int", nullable: false),
                    MovementType = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMovement", x => x.StockMovementId);
                });

            migrationBuilder.CreateTable(
                name: "StockProduct",
                schema: "dbo",
                columns: table => new
                {
                    StockProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProduct", x => x.StockProductId);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbo",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_StockLocation_StockLocationId",
                        column: x => x.StockLocationId,
                        principalSchema: "dbo",
                        principalTable: "StockLocation",
                        principalColumn: "StockLocationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_StockLocationId",
                schema: "dbo",
                table: "Address",
                column: "StockLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StockMovement",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StockProduct",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StockLocation",
                schema: "dbo");
        }
    }
}
