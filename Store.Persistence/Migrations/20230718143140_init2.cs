using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "0eaaaddb-4773-4d79-9978-4f8591e58bfb");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "739cec23-c160-4c85-a1a6-2cac5eb25af7");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "ca6e26b8-9fc2-42b9-926c-4e6172148f0f");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "d5c8815d-61c9-45e6-9cbf-85aa2bb3a41a");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "0f73c75a-0b9f-4434-85e8-99066b10cd62");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "6a1d8f68-974b-4f1b-96d5-06aff1b09276");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "ad939236-4841-49fa-a11b-18d128990480");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "66e73773-8e7d-423e-b1a2-ecae4c1f3496");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7e9daac7-4693-4139-82f7-810b008bfdf9");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e97c80e9-f820-4d92-af35-988a0832be7d");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Blogs",
                newName: "Writer");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "WriterShow",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "5726139a-9a84-48b4-a256-a8fc6b925892", null, null, new DateTime(2023, 7, 18, 19, 1, 39, 453, DateTimeKind.Local).AddTicks(2382), false, null, "آدرس", null, "Address" },
                    { "90f97620-8752-47c9-9804-858cd5422f3d", null, null, new DateTime(2023, 7, 18, 19, 1, 39, 453, DateTimeKind.Local).AddTicks(2351), false, null, "ایمیل", null, "Email" },
                    { "956fac82-9e7e-4d89-835b-e7632587d247", null, null, new DateTime(2023, 7, 18, 19, 1, 39, 453, DateTimeKind.Local).AddTicks(2328), false, null, "تلفن", null, "Phone" },
                    { "fcea0e60-8b3b-445d-bc3c-5095788b8208", null, null, new DateTime(2023, 7, 18, 19, 1, 39, 453, DateTimeKind.Local).AddTicks(2237), false, null, "تلفن همراه", null, "Mobail" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "0e5da729-b2e8-4ee9-9406-39236cc78962", new DateTime(2023, 7, 18, 19, 1, 39, 453, DateTimeKind.Local).AddTicks(2414), false, "English", null, null },
                    { "2cdb7b74-7f67-45d8-bd35-c9a6dcdf92ec", new DateTime(2023, 7, 18, 19, 1, 39, 453, DateTimeKind.Local).AddTicks(2500), false, "Russia", null, null },
                    { "e872d52d-5733-473b-a4e0-fb782eac6a95", new DateTime(2023, 7, 18, 19, 1, 39, 453, DateTimeKind.Local).AddTicks(2443), false, "Arabic", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "6c482163-456a-48ad-b981-4a46975728d3", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "cc27eebe-3493-4748-a4f8-d5826271d100", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "d5e31b62-5042-41dd-97d3-600a43c84e1a", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "5726139a-9a84-48b4-a256-a8fc6b925892");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "90f97620-8752-47c9-9804-858cd5422f3d");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "956fac82-9e7e-4d89-835b-e7632587d247");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "fcea0e60-8b3b-445d-bc3c-5095788b8208");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "0e5da729-b2e8-4ee9-9406-39236cc78962");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "2cdb7b74-7f67-45d8-bd35-c9a6dcdf92ec");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "e872d52d-5733-473b-a4e0-fb782eac6a95");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6c482163-456a-48ad-b981-4a46975728d3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cc27eebe-3493-4748-a4f8-d5826271d100");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d5e31b62-5042-41dd-97d3-600a43c84e1a");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "WriterShow",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "Writer",
                table: "Blogs",
                newName: "Text");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "0eaaaddb-4773-4d79-9978-4f8591e58bfb", null, null, new DateTime(2023, 7, 18, 14, 23, 0, 459, DateTimeKind.Local).AddTicks(117), false, null, "تلفن", null, "Phone" },
                    { "739cec23-c160-4c85-a1a6-2cac5eb25af7", null, null, new DateTime(2023, 7, 18, 14, 23, 0, 459, DateTimeKind.Local).AddTicks(155), false, null, "ایمیل", null, "Email" },
                    { "ca6e26b8-9fc2-42b9-926c-4e6172148f0f", null, null, new DateTime(2023, 7, 18, 14, 23, 0, 459, DateTimeKind.Local).AddTicks(188), false, null, "آدرس", null, "Address" },
                    { "d5c8815d-61c9-45e6-9cbf-85aa2bb3a41a", null, null, new DateTime(2023, 7, 18, 14, 23, 0, 458, DateTimeKind.Local).AddTicks(9989), false, null, "تلفن همراه", null, "Mobail" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "0f73c75a-0b9f-4434-85e8-99066b10cd62", new DateTime(2023, 7, 18, 14, 23, 0, 459, DateTimeKind.Local).AddTicks(277), false, "Arabic", null, null },
                    { "6a1d8f68-974b-4f1b-96d5-06aff1b09276", new DateTime(2023, 7, 18, 14, 23, 0, 459, DateTimeKind.Local).AddTicks(230), false, "English", null, null },
                    { "ad939236-4841-49fa-a11b-18d128990480", new DateTime(2023, 7, 18, 14, 23, 0, 459, DateTimeKind.Local).AddTicks(349), false, "Russia", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "66e73773-8e7d-423e-b1a2-ecae4c1f3496", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "7e9daac7-4693-4139-82f7-810b008bfdf9", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "e97c80e9-f820-4d92-af35-988a0832be7d", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });
        }
    }
}
