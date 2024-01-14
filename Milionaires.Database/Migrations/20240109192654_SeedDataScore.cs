using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Milionaires.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Id", "Date", "Name", "Result" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ania", 500 },
                    { 2, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maciek", 2000 },
                    { 3, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lena", 10000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
