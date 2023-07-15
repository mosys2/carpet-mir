using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addresult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "04ba7c97-f1a3-4cd5-a513-488ea2602ca3", null, null, new DateTime(2023, 7, 12, 17, 34, 16, 230, DateTimeKind.Local).AddTicks(4024), false, null, "تلفن همراه", null, "Mobail" },
                    { "332f993d-281b-4af7-ab4a-a00cec1e7960", null, null, new DateTime(2023, 7, 12, 17, 34, 16, 230, DateTimeKind.Local).AddTicks(4210), false, null, "آدرس", null, "Address" },
                    { "628d2c3d-ba45-4c21-a196-726d6b762501", null, null, new DateTime(2023, 7, 12, 17, 34, 16, 230, DateTimeKind.Local).AddTicks(4180), false, null, "ایمیل", null, "Email" },
                    { "7d344d08-926c-49f4-b0f5-bc617e9df525", null, null, new DateTime(2023, 7, 12, 17, 34, 16, 230, DateTimeKind.Local).AddTicks(4145), false, null, "تلفن", null, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "0fd7c43b-42da-43fa-9cd4-b6b0191ce496", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "47f328de-76c7-4470-bd38-00ae79c0afb5", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "c1a188a2-59b9-44bf-8e32-c94633132232", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "04ba7c97-f1a3-4cd5-a513-488ea2602ca3");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "332f993d-281b-4af7-ab4a-a00cec1e7960");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "628d2c3d-ba45-4c21-a196-726d6b762501");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "7d344d08-926c-49f4-b0f5-bc617e9df525");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0fd7c43b-42da-43fa-9cd4-b6b0191ce496");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "47f328de-76c7-4470-bd38-00ae79c0afb5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c1a188a2-59b9-44bf-8e32-c94633132232");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sliders");

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
    }
}
