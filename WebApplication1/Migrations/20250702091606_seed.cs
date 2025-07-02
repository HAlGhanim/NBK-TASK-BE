using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Number", "DateOfBirth", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, new DateOnly(1990, 1, 1), "F", "Alice" },
                    { 2, new DateOnly(1985, 5, 20), "M", "Bob" },
                    { 3, new DateOnly(2000, 12, 15), "M", "Charlie" },
                    { 4, new DateOnly(1995, 8, 10), "F", "Diana" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 4);
        }
    }
}
