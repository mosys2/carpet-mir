using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addvideofild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "GalleryItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Video",
                table: "GalleryItems");
        }
    }
}
