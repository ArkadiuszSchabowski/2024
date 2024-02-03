using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _089.RestaurantTutorial.Migrations
{
    /// <inheritdoc />
    public partial class removeNameProperty_EntityAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Adresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Adresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
