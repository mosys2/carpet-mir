using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class additemcategory1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_CategoryBlogs_CategoryBlogId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CategoryBlogId",
                table: "Blogs");

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

            migrationBuilder.DropColumn(
                name: "CategoryBlogId",
                table: "Blogs");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShowAt",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "0f69b3ef-ab9d-40b4-9a7b-d9fb28df1234", null, null, new DateTime(2023, 7, 17, 18, 20, 47, 580, DateTimeKind.Local).AddTicks(5495), false, null, "تلفن همراه", null, "Mobail" },
                    { "2332d78a-fb4f-44cf-8961-59042a7d1160", null, null, new DateTime(2023, 7, 17, 18, 20, 47, 580, DateTimeKind.Local).AddTicks(5806), false, null, "ایمیل", null, "Email" },
                    { "6f4758a9-baa0-43b8-a75c-444358106a5f", null, null, new DateTime(2023, 7, 17, 18, 20, 47, 580, DateTimeKind.Local).AddTicks(5859), false, null, "آدرس", null, "Address" },
                    { "ba94a6a9-8f19-4d96-a913-8963a1f20aff", null, null, new DateTime(2023, 7, 17, 18, 20, 47, 580, DateTimeKind.Local).AddTicks(5736), false, null, "تلفن", null, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "2b6aa138-7019-4950-a9a8-300b16cc65e0", new DateTime(2023, 7, 17, 18, 20, 47, 580, DateTimeKind.Local).AddTicks(5901), false, "English", null, null },
                    { "5eb4fd61-d294-4dae-b20d-786f4b731c0f", new DateTime(2023, 7, 17, 18, 20, 47, 580, DateTimeKind.Local).AddTicks(5957), false, "Arabic", null, null },
                    { "d45632e0-27bb-4439-89c7-6099f5a39ae4", new DateTime(2023, 7, 17, 18, 20, 47, 580, DateTimeKind.Local).AddTicks(5993), false, "Russia", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "98e9d8b9-cdd2-46ee-94a1-6fdf3d0856f5", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "adaf2e62-a2ac-459f-8cb2-925249e93f3d", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "df466270-2df8-4167-9521-3d5a6fe46f7c", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "0f69b3ef-ab9d-40b4-9a7b-d9fb28df1234");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "2332d78a-fb4f-44cf-8961-59042a7d1160");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "6f4758a9-baa0-43b8-a75c-444358106a5f");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "ba94a6a9-8f19-4d96-a913-8963a1f20aff");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "2b6aa138-7019-4950-a9a8-300b16cc65e0");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "5eb4fd61-d294-4dae-b20d-786f4b731c0f");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "d45632e0-27bb-4439-89c7-6099f5a39ae4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "98e9d8b9-cdd2-46ee-94a1-6fdf3d0856f5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "adaf2e62-a2ac-459f-8cb2-925249e93f3d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "df466270-2df8-4167-9521-3d5a6fe46f7c");

            migrationBuilder.DropColumn(
                name: "ShowAt",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "CategoryBlogId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
                name: "IX_Blogs_CategoryBlogId",
                table: "Blogs",
                column: "CategoryBlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_CategoryBlogs_CategoryBlogId",
                table: "Blogs",
                column: "CategoryBlogId",
                principalTable: "CategoryBlogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
