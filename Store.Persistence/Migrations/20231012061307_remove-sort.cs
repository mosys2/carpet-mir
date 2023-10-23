using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class removesort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "GroupItems",
            //    keyColumn: "Id",
            //    keyValue: "1297de94-7d0f-4018-a618-f0a6b95afad8");

            //migrationBuilder.DeleteData(
            //    table: "GroupItems",
            //    keyColumn: "Id",
            //    keyValue: "76c08023-9974-4b0d-a8e8-79b1c2307e75");

            //migrationBuilder.DeleteData(
            //    table: "GroupItems",
            //    keyColumn: "Id",
            //    keyValue: "d079408c-9a73-4966-98f1-55d49cec5e16");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "SiteContactTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "SiteContacts");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "RequestPays");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "RegisterCarpets");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "PageCreators");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Newsletters");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "ItemTags");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "ItemCategoryBlogs");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "GroupItems");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "GalleryItems");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "ContactType");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "CommentBlogs");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "CategoryBlogs");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "BlogItemTags");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Abouts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "UserAddresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Sliders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Sizes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "SiteContactTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "SiteContacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Shapes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Settings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Results",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "RequestPays",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "RegisterCarpets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Rates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Provinces",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "PageCreators",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Newsletters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Medias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Materials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Languages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "ItemTags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "ItemCategoryBlogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Groups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "GroupItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "GalleryItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Galleries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Features",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "ContactUs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "ContactType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Contacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "CommentBlogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Colors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "CategoryBlogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Carts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "CartItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "BlogTags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Blogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "BlogItemTags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Authors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Abouts",
                type: "datetime2",
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "GroupItems",
            //    columns: new[] { "Id", "GroupId", "GroupType", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Sort", "Title", "UpdateTime" },
            //    values: new object[] { "1297de94-7d0f-4018-a618-f0a6b95afad8", null, 6, new DateTime(2023, 10, 11, 16, 37, 4, 920, DateTimeKind.Local).AddTicks(4408), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, null, "DownloadCatalouge", null });

            //migrationBuilder.InsertData(
            //    table: "GroupItems",
            //    columns: new[] { "Id", "GroupId", "GroupType", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Sort", "Title", "UpdateTime" },
            //    values: new object[] { "76c08023-9974-4b0d-a8e8-79b1c2307e75", null, 6, new DateTime(2023, 10, 11, 16, 37, 4, 920, DateTimeKind.Local).AddTicks(4321), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, null, "DownloadCatalouge", null });

            //migrationBuilder.InsertData(
            //    table: "GroupItems",
            //    columns: new[] { "Id", "GroupId", "GroupType", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Sort", "Title", "UpdateTime" },
            //    values: new object[] { "d079408c-9a73-4966-98f1-55d49cec5e16", null, 6, new DateTime(2023, 10, 11, 16, 37, 4, 920, DateTimeKind.Local).AddTicks(4398), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, null, "DownloadCatalouge", null });
        }
    }
}
