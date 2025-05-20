using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProject.Migrations
{
    /// <inheritdoc />
    public partial class CreateCityStatusRows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");
        }
    }
}
