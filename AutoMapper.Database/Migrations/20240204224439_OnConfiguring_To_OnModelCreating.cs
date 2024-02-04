using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoMapper.Database.Migrations
{
    /// <inheritdoc />
    public partial class OnConfiguring_To_OnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Name", "Phone", "isAdmin", "isPremiumAccount" },
                values: new object[,]
                {
                    { 1, "Chorzów", "Świnka", "7806969", true, true },
                    { 2, "Chorzów", "Paulina", "500100200", false, true },
                    { 3, "Chorzów", "Dominika", "600200300", false, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
