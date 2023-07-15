using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addslider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "2607a141-9ce5-421e-9cd1-b88ebaa5f48a");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "36e58623-05fe-4a47-ae79-ad939747ae79");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "92557661-8711-42ce-ab8b-b251b64843e5");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "c564076d-35b4-4d69-bbf3-537178d60fba");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0a2373a6-6f08-4bd5-9eb1-5f3ab8842d97");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e5523332-f4f4-48d1-b7da-ffafc21330be");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f5f4d688-b28c-4d77-a2b0-93355ed29882");

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "0615c83e-9e37-4909-b8e5-82f2a943755b", null, null, new DateTime(2023, 7, 12, 14, 10, 6, 803, DateTimeKind.Local).AddTicks(3088), false, null, "ایمیل", null, "Email" },
                    { "49f3e9a8-6256-4b5a-9516-0d6aa68935ee", null, null, new DateTime(2023, 7, 12, 14, 10, 6, 803, DateTimeKind.Local).AddTicks(2898), false, null, "تلفن همراه", null, "Mobail" },
                    { "ac608fe0-4c6d-4090-8129-698887e0ce1c", null, null, new DateTime(2023, 7, 12, 14, 10, 6, 803, DateTimeKind.Local).AddTicks(3051), false, null, "تلفن", null, "Phone" },
                    { "af78fd61-e2fb-4199-a12b-e48ce4e3a825", null, null, new DateTime(2023, 7, 12, 14, 10, 6, 803, DateTimeKind.Local).AddTicks(3121), false, null, "آدرس", null, "Address" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "63cb3139-72a2-4a1b-ac64-c12165f0ee1b", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "cc75e12e-b951-444b-9e6e-163f2e33c97e", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "f9e5d6c8-84bb-451c-b9e0-fcc9e308063c", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "0615c83e-9e37-4909-b8e5-82f2a943755b");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "49f3e9a8-6256-4b5a-9516-0d6aa68935ee");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "ac608fe0-4c6d-4090-8129-698887e0ce1c");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "af78fd61-e2fb-4199-a12b-e48ce4e3a825");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "63cb3139-72a2-4a1b-ac64-c12165f0ee1b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cc75e12e-b951-444b-9e6e-163f2e33c97e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f9e5d6c8-84bb-451c-b9e0-fcc9e308063c");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "2607a141-9ce5-421e-9cd1-b88ebaa5f48a", null, null, new DateTime(2023, 7, 12, 10, 36, 52, 968, DateTimeKind.Local).AddTicks(8238), false, null, "آدرس", null, "Address" },
                    { "36e58623-05fe-4a47-ae79-ad939747ae79", null, null, new DateTime(2023, 7, 12, 10, 36, 52, 968, DateTimeKind.Local).AddTicks(8125), false, null, "تلفن همراه", null, "Mobail" },
                    { "92557661-8711-42ce-ab8b-b251b64843e5", null, null, new DateTime(2023, 7, 12, 10, 36, 52, 968, DateTimeKind.Local).AddTicks(8221), false, null, "ایمیل", null, "Email" },
                    { "c564076d-35b4-4d69-bbf3-537178d60fba", null, null, new DateTime(2023, 7, 12, 10, 36, 52, 968, DateTimeKind.Local).AddTicks(8201), false, null, "تلفن", null, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "0a2373a6-6f08-4bd5-9eb1-5f3ab8842d97", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "e5523332-f4f4-48d1-b7da-ffafc21330be", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "f5f4d688-b28c-4d77-a2b0-93355ed29882", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null }
                });
        }
    }
}
