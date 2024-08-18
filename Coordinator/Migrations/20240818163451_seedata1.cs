using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coordinator.Migrations
{
    /// <inheritdoc />
    public partial class seedata1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("53874490-caec-4cad-9a6a-c69989f94405"), "Order.API" },
                    { new Guid("6b7fa2ae-e74a-48e7-baa5-821992dc974f"), "Stock.API" },
                    { new Guid("ae3aebe0-6ec4-474e-8a62-c70573ddd4d3"), "Payment.API" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("53874490-caec-4cad-9a6a-c69989f94405"));

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("6b7fa2ae-e74a-48e7-baa5-821992dc974f"));

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("ae3aebe0-6ec4-474e-8a62-c70573ddd4d3"));
        }
    }
}
