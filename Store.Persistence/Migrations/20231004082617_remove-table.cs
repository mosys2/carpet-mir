using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class removetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
        name: "ItemColors");

            migrationBuilder.DropTable(
        name: "ItemMaterials");

            migrationBuilder.DropTable(
        name: "ItemShapes");

            migrationBuilder.DropTable(
        name: "ItemSizes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
       name: "ItemColors");

            migrationBuilder.DropTable(
        name: "ItemMaterials");

            migrationBuilder.DropTable(
        name: "ItemShapes");

            migrationBuilder.DropTable(
        name: "ItemSizes");
        }
    }
}
