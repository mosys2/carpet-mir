using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addsortuseractivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Sliders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "SiteContactTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "SiteContactTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "SiteContactTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "SiteContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "SiteContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "SiteContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Shapes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Shapes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Shapes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Results",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Results",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Results",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Results",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "RequestPays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "RequestPays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "RequestPays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "RegisterCarpets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "RegisterCarpets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "RegisterCarpets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Rates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Rates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Rates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Provinces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Provinces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Provinces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "PageCreators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "PageCreators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "PageCreators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Newsletters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Newsletters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Newsletters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Medias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "ItemTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "ItemTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "ItemTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "ItemCategoryBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "ItemCategoryBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "ItemCategoryBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "GroupItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "GroupItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "GroupItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "GalleryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "GalleryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "GalleryItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "GalleryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Galleries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Features",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "ContactType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "ContactType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "ContactType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "CommentBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "CommentBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "CommentBlogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "CommentBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "CategoryBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "CategoryBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "CategoryBlogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "CategoryBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Category",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "BlogTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "BlogTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "BlogTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Blogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "BlogItemTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "BlogItemTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "BlogItemTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sort",
                table: "Authors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsertByUserId",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoveByUserId",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "SiteContactTypes");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "SiteContactTypes");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "SiteContactTypes");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "SiteContacts");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "SiteContacts");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "SiteContacts");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "RequestPays");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "RequestPays");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "RequestPays");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "RegisterCarpets");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "RegisterCarpets");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "RegisterCarpets");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "PageCreators");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "PageCreators");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "PageCreators");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Newsletters");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Newsletters");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Newsletters");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "ItemTags");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "ItemTags");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "ItemTags");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "ItemCategoryBlogs");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "ItemCategoryBlogs");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "ItemCategoryBlogs");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "GroupItems");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "GroupItems");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "GroupItems");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "GalleryItems");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "GalleryItems");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "GalleryItems");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "GalleryItems");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "ContactType");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "ContactType");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "ContactType");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "CommentBlogs");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "CommentBlogs");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "CommentBlogs");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "CommentBlogs");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "CategoryBlogs");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "CategoryBlogs");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "CategoryBlogs");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "CategoryBlogs");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "BlogItemTags");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "BlogItemTags");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "BlogItemTags");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "InsertByUserId",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Abouts");
        }
    }
}
