using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class createmodelblog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Languages_LanguageId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Languages_LanguageId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Languages_LanguageId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Languages_LanguageId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Languages_LanguageId",
                table: "Tags");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "6fc130cc-09f9-4582-bcd0-929f841850e7");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "c67bec6e-8e25-4a35-95a6-6f86bdebe036");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "e7be8213-8266-4753-8783-f32b4bbd25c0");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "e8931eae-1d52-4654-b6af-5b9302ea2fcd");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "4c3166d9-39c5-4c7e-b8d2-08be69d694a1");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "a1c7c221-a03a-4faf-b304-853957d8df76");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "b802db67-6bd0-4c18-aeb4-919707c53acc");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6233b0c8-b85a-4158-aa0e-b80b1d2bf3d7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b31278ec-fd4e-49f2-b082-a4eb632ec06a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f2186b4f-b48e-4ae7-94f1-617675239893");

            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "UserAddresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "AllowComment",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CommentBlogId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CategoryBlogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentBlogCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryBlogs_CategoryBlogs_ParentBlogCategoryId",
                        column: x => x.ParentBlogCategoryId,
                        principalTable: "CategoryBlogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryBlogs_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    View = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryBlogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_CategoryBlogs_CategoryBlogId",
                        column: x => x.CategoryBlogId,
                        principalTable: "CategoryBlogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentBlogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentCommentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Seen = table.Column<bool>(type: "bit", nullable: false),
                    BlogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentBlogs_CommentBlogs_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "CommentBlogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentBlogs_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "2f89d2c9-8703-4b76-85d7-921803aebd38", null, null, new DateTime(2023, 7, 17, 14, 31, 11, 210, DateTimeKind.Local).AddTicks(5249), false, null, "ایمیل", null, "Email" },
                    { "849a3bef-e8c5-49e4-afbf-c8decf1fd454", null, null, new DateTime(2023, 7, 17, 14, 31, 11, 210, DateTimeKind.Local).AddTicks(5280), false, null, "آدرس", null, "Address" },
                    { "ba23c7c3-2fbe-43d7-966a-5c83a3ef3e8d", null, null, new DateTime(2023, 7, 17, 14, 31, 11, 210, DateTimeKind.Local).AddTicks(5215), false, null, "تلفن", null, "Phone" },
                    { "e67252fd-78c0-4cc4-80fa-4da7f87d153f", null, null, new DateTime(2023, 7, 17, 14, 31, 11, 210, DateTimeKind.Local).AddTicks(5106), false, null, "تلفن همراه", null, "Mobail" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "1836f8d0-d187-4385-8f76-a12d10d806de", new DateTime(2023, 7, 17, 14, 31, 11, 210, DateTimeKind.Local).AddTicks(5317), false, "English", null, null },
                    { "a9ad5a54-ae09-42aa-a32f-c5282012bcb6", new DateTime(2023, 7, 17, 14, 31, 11, 210, DateTimeKind.Local).AddTicks(5469), false, "Russia", null, null },
                    { "f910b5f1-21eb-408d-8ffd-c890c1d0ef57", new DateTime(2023, 7, 17, 14, 31, 11, 210, DateTimeKind.Local).AddTicks(5361), false, "Arabic", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "949d0708-ef33-40b4-880e-7e03fcbeecf0", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "aa991955-c184-44ff-9fad-1cbdc855b701", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "f897d76b-10c0-4c51-81c9-386bd2c07a85", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_LanguageId",
                table: "UserAddresses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentBlogId",
                table: "Comments",
                column: "CommentBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryBlogId",
                table: "Blogs",
                column: "CategoryBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_LanguageId",
                table: "Blogs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBlogs_LanguageId",
                table: "CategoryBlogs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBlogs_ParentBlogCategoryId",
                table: "CategoryBlogs",
                column: "ParentBlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentBlogs_BlogId",
                table: "CommentBlogs",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentBlogs_LanguageId",
                table: "CommentBlogs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentBlogs_ParentCommentId",
                table: "CommentBlogs",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Languages_LanguageId",
                table: "Brands",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Languages_LanguageId",
                table: "Category",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CommentBlogs_CommentBlogId",
                table: "Comments",
                column: "CommentBlogId",
                principalTable: "CommentBlogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Languages_LanguageId",
                table: "Comments",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Languages_LanguageId",
                table: "Features",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Languages_LanguageId",
                table: "Tags",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Languages_LanguageId",
                table: "UserAddresses",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Languages_LanguageId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Languages_LanguageId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CommentBlogs_CommentBlogId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Languages_LanguageId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Languages_LanguageId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Languages_LanguageId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_Languages_LanguageId",
                table: "UserAddresses");

            migrationBuilder.DropTable(
                name: "CommentBlogs");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "CategoryBlogs");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_LanguageId",
                table: "UserAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentBlogId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "2f89d2c9-8703-4b76-85d7-921803aebd38");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "849a3bef-e8c5-49e4-afbf-c8decf1fd454");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "ba23c7c3-2fbe-43d7-966a-5c83a3ef3e8d");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "e67252fd-78c0-4cc4-80fa-4da7f87d153f");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "1836f8d0-d187-4385-8f76-a12d10d806de");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "a9ad5a54-ae09-42aa-a32f-c5282012bcb6");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "f910b5f1-21eb-408d-8ffd-c890c1d0ef57");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "949d0708-ef33-40b4-880e-7e03fcbeecf0");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "aa991955-c184-44ff-9fad-1cbdc855b701");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f897d76b-10c0-4c51-81c9-386bd2c07a85");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "AllowComment",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CommentBlogId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Seen",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "6fc130cc-09f9-4582-bcd0-929f841850e7", null, null, new DateTime(2023, 7, 16, 16, 41, 7, 929, DateTimeKind.Local).AddTicks(7793), false, null, "تلفن", null, "Phone" },
                    { "c67bec6e-8e25-4a35-95a6-6f86bdebe036", null, null, new DateTime(2023, 7, 16, 16, 41, 7, 929, DateTimeKind.Local).AddTicks(7585), false, null, "تلفن همراه", null, "Mobail" },
                    { "e7be8213-8266-4753-8783-f32b4bbd25c0", null, null, new DateTime(2023, 7, 16, 16, 41, 7, 929, DateTimeKind.Local).AddTicks(8018), false, null, "آدرس", null, "Address" },
                    { "e8931eae-1d52-4654-b6af-5b9302ea2fcd", null, null, new DateTime(2023, 7, 16, 16, 41, 7, 929, DateTimeKind.Local).AddTicks(7903), false, null, "ایمیل", null, "Email" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "4c3166d9-39c5-4c7e-b8d2-08be69d694a1", new DateTime(2023, 7, 16, 16, 41, 7, 929, DateTimeKind.Local).AddTicks(8417), false, "Russia", null, null },
                    { "a1c7c221-a03a-4faf-b304-853957d8df76", new DateTime(2023, 7, 16, 16, 41, 7, 929, DateTimeKind.Local).AddTicks(8293), false, "Arabic", null, null },
                    { "b802db67-6bd0-4c18-aeb4-919707c53acc", new DateTime(2023, 7, 16, 16, 41, 7, 929, DateTimeKind.Local).AddTicks(8158), false, "English", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "6233b0c8-b85a-4158-aa0e-b80b1d2bf3d7", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "b31278ec-fd4e-49f2-b082-a4eb632ec06a", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "f2186b4f-b48e-4ae7-94f1-617675239893", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Languages_LanguageId",
                table: "Brands",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Languages_LanguageId",
                table: "Category",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Languages_LanguageId",
                table: "Comments",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Languages_LanguageId",
                table: "Features",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Languages_LanguageId",
                table: "Tags",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
