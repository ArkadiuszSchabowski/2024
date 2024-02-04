using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _089.RestaurantTutorial.Migrations
{
    /// <inheritdoc />
    public partial class ChangeContactPhoneColumn_Restaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContantPhone",
                table: "Restaurants",
                newName: "ContactPhone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactPhone",
                table: "Restaurants",
                newName: "ContantPhone");
        }
    }
}
