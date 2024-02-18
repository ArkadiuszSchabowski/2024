using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _089.RestaurantTutorial.Migrations
{
    /// <inheritdoc />
    public partial class EntityUserPasswordChangeToHashPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "HashPassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashPassword",
                table: "Users",
                newName: "Password");
        }
    }
}
