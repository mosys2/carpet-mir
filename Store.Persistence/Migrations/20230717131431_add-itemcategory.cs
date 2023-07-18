using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class additemcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryBlogs_CategoryBlogs_ParentBlogCategoryId",
                table: "CategoryBlogs");

            migrationBuilder.DropIndex(
                name: "IX_CategoryBlogs_ParentBlogCategoryId",
                table: "CategoryBlogs");

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
                name: "ParentBlogCategoryId",
                table: "CategoryBlogs");

            migrationBuilder.CreateTable(
                name: "ItemCategoryBlogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BlogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryBlogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategoryBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCategoryBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCategoryBlogs_CategoryBlogs_CategoryBlogId",
                        column: x => x.CategoryBlogId,
                        principalTable: "CategoryBlogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "1ebaee7b-6eff-4e10-af69-e705ddef9d57", null, null, new DateTime(2023, 7, 17, 17, 44, 30, 444, DateTimeKind.Local).AddTicks(7770), false, null, "تلفن همراه", null, "Mobail" },
                    { "80e697a6-a521-470f-8713-55e7e00c62d4", null, null, new DateTime(2023, 7, 17, 17, 44, 30, 444, DateTimeKind.Local).AddTicks(8000), false, null, "ایمیل", null, "Email" },
                    { "a3035651-dc53-4b35-a4fd-73c1b4152aca", null, null, new DateTime(2023, 7, 17, 17, 44, 30, 444, DateTimeKind.Local).AddTicks(8184), false, null, "آدرس", null, "Address" },
                    { "f5b08ca1-3f75-456c-8a48-688f9354ace4", null, null, new DateTime(2023, 7, 17, 17, 44, 30, 444, DateTimeKind.Local).AddTicks(7907), false, null, "تلفن", null, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "18d22a8c-18d0-4a54-a194-8217d975ae06", new DateTime(2023, 7, 17, 17, 44, 30, 444, DateTimeKind.Local).AddTicks(8253), false, "English", null, null },
                    { "5643a153-7298-4e90-85ca-114941d8eb5d", new DateTime(2023, 7, 17, 17, 44, 30, 444, DateTimeKind.Local).AddTicks(8336), false, "Russia", null, null },
                    { "7a852d94-246c-4a74-8249-3e269ec9b704", new DateTime(2023, 7, 17, 17, 44, 30, 444, DateTimeKind.Local).AddTicks(8301), false, "Arabic", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "31cff2e7-3c4e-4c34-bf09-d1c5e038a98d", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "5fa2331b-cd92-4cc7-935d-a38ea830fa45", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "c7746355-b2b0-4888-8f40-2846e1b1473f", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategoryBlogs_BlogId",
                table: "ItemCategoryBlogs",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategoryBlogs_CategoryBlogId",
                table: "ItemCategoryBlogs",
                column: "CategoryBlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCategoryBlogs");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "1ebaee7b-6eff-4e10-af69-e705ddef9d57");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "80e697a6-a521-470f-8713-55e7e00c62d4");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "a3035651-dc53-4b35-a4fd-73c1b4152aca");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "f5b08ca1-3f75-456c-8a48-688f9354ace4");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "18d22a8c-18d0-4a54-a194-8217d975ae06");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "5643a153-7298-4e90-85ca-114941d8eb5d");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "7a852d94-246c-4a74-8249-3e269ec9b704");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "31cff2e7-3c4e-4c34-bf09-d1c5e038a98d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5fa2331b-cd92-4cc7-935d-a38ea830fa45");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c7746355-b2b0-4888-8f40-2846e1b1473f");

            migrationBuilder.AddColumn<string>(
                name: "ParentBlogCategoryId",
                table: "CategoryBlogs",
                type: "nvarchar(450)",
                nullable: true);

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
                name: "IX_CategoryBlogs_ParentBlogCategoryId",
                table: "CategoryBlogs",
                column: "ParentBlogCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryBlogs_CategoryBlogs_ParentBlogCategoryId",
                table: "CategoryBlogs",
                column: "ParentBlogCategoryId",
                principalTable: "CategoryBlogs",
                principalColumn: "Id");
        }
    }
}
