using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class RemovePageCreatorForeignKeyFromGroupItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
        name: "FK_GroupItems_PageCreators_PageCreatorId",
        table: "GroupItems");

            migrationBuilder.DropIndex(
                name: "IX_GroupItems_PageCreatorId",
                table: "GroupItems");

            migrationBuilder.DropColumn(
                name: "PageCreatorId",
                table: "GroupItems");
        }
    }
}
