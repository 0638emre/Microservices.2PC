using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coordinator.Migrations
{
    /// <inheritdoc />
    public partial class fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "transactionId",
                table: "NodeStates",
                newName: "TransactionId");

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("067fc436-58c5-462c-8d96-dfbaeb29398c"), "Payment.API" },
                    { new Guid("79fdad8a-34bf-4ce9-9072-04f8d475b563"), "Order.API" },
                    { new Guid("8edb8f0b-adf3-4bb5-a38e-6206e1982742"), "Stock.API" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("067fc436-58c5-462c-8d96-dfbaeb29398c"));

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("79fdad8a-34bf-4ce9-9072-04f8d475b563"));

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("8edb8f0b-adf3-4bb5-a38e-6206e1982742"));

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "NodeStates",
                newName: "transactionId");

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
    }
}
