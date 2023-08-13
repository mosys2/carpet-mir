using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemColors_Colors_ColorId",
                table: "ItemColors");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMaterials_Materials_MaterialId",
                table: "ItemMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemShapes_Shapes_ShapeId",
                table: "ItemShapes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSizes_Sizes_SizeId",
                table: "ItemSizes");

            migrationBuilder.AlterColumn<string>(
                name: "SizeId",
                table: "ItemSizes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ColorId",
                table: "ItemSizes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialId",
                table: "ItemSizes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShapeId",
                table: "ItemSizes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShapeId",
                table: "ItemShapes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ColorId",
                table: "ItemShapes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialId",
                table: "ItemShapes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeId",
                table: "ItemShapes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialId",
                table: "ItemMaterials",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ColorId",
                table: "ItemMaterials",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShapeId",
                table: "ItemMaterials",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeId",
                table: "ItemMaterials",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ColorId",
                table: "ItemColors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "MaterialId",
                table: "ItemColors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShapeId",
                table: "ItemColors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeId",
                table: "ItemColors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemSizes_ColorId",
                table: "ItemSizes",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSizes_MaterialId",
                table: "ItemSizes",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSizes_ShapeId",
                table: "ItemSizes",
                column: "ShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemShapes_ColorId",
                table: "ItemShapes",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemShapes_MaterialId",
                table: "ItemShapes",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemShapes_SizeId",
                table: "ItemShapes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaterials_ColorId",
                table: "ItemMaterials",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaterials_ShapeId",
                table: "ItemMaterials",
                column: "ShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaterials_SizeId",
                table: "ItemMaterials",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemColors_MaterialId",
                table: "ItemColors",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemColors_ShapeId",
                table: "ItemColors",
                column: "ShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemColors_SizeId",
                table: "ItemColors",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemColors_Colors_ColorId",
                table: "ItemColors",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemColors_Materials_MaterialId",
                table: "ItemColors",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemColors_Shapes_ShapeId",
                table: "ItemColors",
                column: "ShapeId",
                principalTable: "Shapes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemColors_Sizes_SizeId",
                table: "ItemColors",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMaterials_Colors_ColorId",
                table: "ItemMaterials",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMaterials_Materials_MaterialId",
                table: "ItemMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMaterials_Shapes_ShapeId",
                table: "ItemMaterials",
                column: "ShapeId",
                principalTable: "Shapes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMaterials_Sizes_SizeId",
                table: "ItemMaterials",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemShapes_Colors_ColorId",
                table: "ItemShapes",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemShapes_Materials_MaterialId",
                table: "ItemShapes",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemShapes_Shapes_ShapeId",
                table: "ItemShapes",
                column: "ShapeId",
                principalTable: "Shapes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemShapes_Sizes_SizeId",
                table: "ItemShapes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSizes_Colors_ColorId",
                table: "ItemSizes",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSizes_Materials_MaterialId",
                table: "ItemSizes",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSizes_Shapes_ShapeId",
                table: "ItemSizes",
                column: "ShapeId",
                principalTable: "Shapes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSizes_Sizes_SizeId",
                table: "ItemSizes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemColors_Colors_ColorId",
                table: "ItemColors");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemColors_Materials_MaterialId",
                table: "ItemColors");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemColors_Shapes_ShapeId",
                table: "ItemColors");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemColors_Sizes_SizeId",
                table: "ItemColors");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMaterials_Colors_ColorId",
                table: "ItemMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMaterials_Materials_MaterialId",
                table: "ItemMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMaterials_Shapes_ShapeId",
                table: "ItemMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMaterials_Sizes_SizeId",
                table: "ItemMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemShapes_Colors_ColorId",
                table: "ItemShapes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemShapes_Materials_MaterialId",
                table: "ItemShapes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemShapes_Shapes_ShapeId",
                table: "ItemShapes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemShapes_Sizes_SizeId",
                table: "ItemShapes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSizes_Colors_ColorId",
                table: "ItemSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSizes_Materials_MaterialId",
                table: "ItemSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSizes_Shapes_ShapeId",
                table: "ItemSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSizes_Sizes_SizeId",
                table: "ItemSizes");

            migrationBuilder.DropIndex(
                name: "IX_ItemSizes_ColorId",
                table: "ItemSizes");

            migrationBuilder.DropIndex(
                name: "IX_ItemSizes_MaterialId",
                table: "ItemSizes");

            migrationBuilder.DropIndex(
                name: "IX_ItemSizes_ShapeId",
                table: "ItemSizes");

            migrationBuilder.DropIndex(
                name: "IX_ItemShapes_ColorId",
                table: "ItemShapes");

            migrationBuilder.DropIndex(
                name: "IX_ItemShapes_MaterialId",
                table: "ItemShapes");

            migrationBuilder.DropIndex(
                name: "IX_ItemShapes_SizeId",
                table: "ItemShapes");

            migrationBuilder.DropIndex(
                name: "IX_ItemMaterials_ColorId",
                table: "ItemMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ItemMaterials_ShapeId",
                table: "ItemMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ItemMaterials_SizeId",
                table: "ItemMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ItemColors_MaterialId",
                table: "ItemColors");

            migrationBuilder.DropIndex(
                name: "IX_ItemColors_ShapeId",
                table: "ItemColors");

            migrationBuilder.DropIndex(
                name: "IX_ItemColors_SizeId",
                table: "ItemColors");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ItemSizes");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "ItemSizes");

            migrationBuilder.DropColumn(
                name: "ShapeId",
                table: "ItemSizes");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ItemShapes");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "ItemShapes");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ItemShapes");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ItemMaterials");

            migrationBuilder.DropColumn(
                name: "ShapeId",
                table: "ItemMaterials");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ItemMaterials");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "ItemColors");

            migrationBuilder.DropColumn(
                name: "ShapeId",
                table: "ItemColors");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ItemColors");

            migrationBuilder.AlterColumn<string>(
                name: "SizeId",
                table: "ItemSizes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShapeId",
                table: "ItemShapes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialId",
                table: "ItemMaterials",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ColorId",
                table: "ItemColors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemColors_Colors_ColorId",
                table: "ItemColors",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMaterials_Materials_MaterialId",
                table: "ItemMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemShapes_Shapes_ShapeId",
                table: "ItemShapes",
                column: "ShapeId",
                principalTable: "Shapes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSizes_Sizes_SizeId",
                table: "ItemSizes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
