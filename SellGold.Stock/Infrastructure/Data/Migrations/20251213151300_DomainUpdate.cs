using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellGold.Stock.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StockLocation_StockLocationId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                schema: "dbo",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "dbo",
                newName: "Addresses",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Address_StockLocationId",
                schema: "dbo",
                table: "Addresses",
                newName: "IX_Addresses_StockLocationId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "StockProduct",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "StockProduct",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "StockMovement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "StockMovement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "StockLocation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "StockLocation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                schema: "dbo",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_StockLocation_StockLocationId",
                schema: "dbo",
                table: "Addresses",
                column: "StockLocationId",
                principalSchema: "dbo",
                principalTable: "StockLocation",
                principalColumn: "StockLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_StockLocation_StockLocationId",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "dbo",
                table: "StockProduct");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "dbo",
                table: "StockProduct");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "dbo",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "dbo",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "dbo",
                table: "StockLocation");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "dbo",
                table: "StockLocation");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "dbo",
                newName: "Address",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_StockLocationId",
                schema: "dbo",
                table: "Address",
                newName: "IX_Address_StockLocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                schema: "dbo",
                table: "Address",
                column: "AddressId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Address_StockLocation_StockLocationId",
            //    schema: "dbo",
            //    table: "Address",
            //    column: "StockLocationId",
            //    principalSchema: "dbo",
            //    principalTable: "StockLocation",
            //    principalColumn: "StockLocationId");
        }
    }
}
