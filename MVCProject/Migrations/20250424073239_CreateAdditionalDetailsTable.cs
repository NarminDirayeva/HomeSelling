using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProject.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdditionalDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Waterfront = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuiltIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    View = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterfrontDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdditionalDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalDetails_ProductID",
                table: "AdditionalDetails",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalDetails");
        }
    }
}
