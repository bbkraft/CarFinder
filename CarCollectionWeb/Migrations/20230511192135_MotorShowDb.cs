using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCollectionWeb.Migrations
{
    /// <inheritdoc />
    public partial class MotorShowDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
         name: "CarModel",
         table: "Cars",
         nullable: true);
            //  migrationBuilder.CreateTable(
            //      name: "CarCategorys",
            //      columns: table => new
            //      {
            //          Id = table.Column<int>(type: "int", nullable: false)
            //              .Annotation("SqlServer:Identity", "1, 1"),
            //          NameCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //          Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //      },
            //      constraints: table =>
            //      {
            //          table.PrimaryKey("PK_CarCategorys", x => x.Id);
            //      });
            //
            //  migrationBuilder.CreateTable(
            //      name: "Cars",
            //      columns: table => new
            //      {
            //          Id = table.Column<int>(type: "int", nullable: false)
            //              .Annotation("SqlServer:Identity", "1, 1"),
            //          CarBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //          CarModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //          Year = table.Column<int>(type: "int", nullable: false),
            //          EngineСapacity = table.Column<int>(type: "int", nullable: false),
            //          FuelType = table.Column<int>(type: "int", nullable: false),
            //          CarCategoryId = table.Column<int>(type: "int", nullable: false)
            //      },
            //      constraints: table =>
            //      {
            //          table.PrimaryKey("PK_Cars", x => x.Id);
            //          table.ForeignKey(
            //              name: "FK_Cars_CarCategorys_CarCategoryId",
            //              column: x => x.CarCategoryId,
            //              principalTable: "CarCategorys",
            //              principalColumn: "Id",
            //              onDelete: ReferentialAction.Cascade);
            //      });
            //
            //  migrationBuilder.CreateIndex(
            //      name: "IX_Cars_CarCategoryId",
            //      table: "Cars",
            //      column: "CarCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarCategorys");
        }
    }
}
