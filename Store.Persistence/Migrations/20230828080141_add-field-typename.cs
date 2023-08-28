using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addfieldtypename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "RegisterCarpets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "RegisterCarpets");
        }
    }
}
