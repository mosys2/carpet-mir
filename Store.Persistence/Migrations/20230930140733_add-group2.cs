using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addgroup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageCreators_GroupItems_GroupItemId",
                table: "PageCreators");

            migrationBuilder.DropIndex(
                name: "IX_PageCreators_GroupItemId",
                table: "PageCreators");

            migrationBuilder.DropColumn(
                name: "GroupItemId",
                table: "PageCreators");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //    migrationBuilder.AddColumn<string>(
            //        name: "GroupItemId",
            //        table: "PageCreators",
            //        type: "nvarchar(450)",
            //        nullable: false,
            //        defaultValue: "");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_PageCreators_GroupItemId",
            //        table: "PageCreators",
            //        column: "GroupItemId");

            //    migrationBuilder.AddForeignKey(
            //        name: "FK_PageCreators_GroupItems_GroupItemId",
            //        table: "PageCreators",
            //        column: "GroupItemId",
            //        principalTable: "GroupItems",
            //        principalColumn: "Id");
        }
    }
}
