using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Customerseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Number", "DateOfBirth", "Gender", "Name" },
                values: new object[,]
                {
                    { 5, new DateOnly(1988, 3, 5), "M", "Edward" },
                    { 6, new DateOnly(1992, 7, 19), "F", "Fiona" },
                    { 7, new DateOnly(1983, 10, 23), "M", "George" },
                    { 8, new DateOnly(1999, 11, 11), "F", "Hannah" },
                    { 9, new DateOnly(1991, 2, 17), "M", "Ian" },
                    { 10, new DateOnly(1996, 6, 6), "F", "Julia" },
                    { 11, new DateOnly(1987, 4, 13), "M", "Kevin" },
                    { 12, new DateOnly(1993, 9, 2), "F", "Laura" },
                    { 13, new DateOnly(1989, 12, 24), "M", "Mike" },
                    { 14, new DateOnly(1997, 1, 30), "F", "Nina" },
                    { 15, new DateOnly(1982, 8, 18), "M", "Oscar" },
                    { 16, new DateOnly(1994, 5, 9), "F", "Paula" },
                    { 17, new DateOnly(1990, 10, 4), "M", "Quentin" },
                    { 18, new DateOnly(1998, 3, 22), "F", "Rachel" },
                    { 19, new DateOnly(1986, 6, 14), "M", "Steve" },
                    { 20, new DateOnly(1995, 12, 1), "F", "Tina" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Number",
                keyValue: 20);
        }
    }
}
