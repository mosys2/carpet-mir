using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addgroup5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_GroupItems_PageCreators_PageCreatorId",
            //    table: "GroupItems");

            //migrationBuilder.DropIndex(
            //    name: "IX_GroupItems_PageCreatorId",
            //    table: "GroupItems");

            //migrationBuilder.DropColumn(
            //    name: "PageCreatorId",
            //    table: "GroupItems");

            migrationBuilder.AddColumn<string>(
                name: "GroupItemId",
                table: "PageCreators",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PageCreators_GroupItemId",
                table: "PageCreators",
                column: "GroupItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PageCreators_GroupItems_GroupItemId",
                table: "PageCreators",
                column: "GroupItemId",
                principalTable: "GroupItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PageCreators_GroupItems_GroupItemId",
            //    table: "PageCreators");

            //migrationBuilder.DropIndex(
            //    name: "IX_PageCreators_GroupItemId",
            //    table: "PageCreators");

            //migrationBuilder.DropColumn(
            //    name: "GroupItemId",
            //    table: "PageCreators");

            migrationBuilder.AddColumn<string>(
                name: "PageCreatorId",
                table: "GroupItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupItems_PageCreatorId",
                table: "GroupItems",
                column: "PageCreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupItems_PageCreators_PageCreatorId",
                table: "GroupItems",
                column: "PageCreatorId",
                principalTable: "PageCreators",
                principalColumn: "Id");
        }
    }
}
