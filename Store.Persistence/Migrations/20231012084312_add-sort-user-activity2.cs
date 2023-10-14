using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addsortuseractivity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Sizes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Shapes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "RegisterCarpets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Materials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Colors",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "RegisterCarpets");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Colors");
        }
    }
}
