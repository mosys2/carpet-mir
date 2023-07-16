using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class languagechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "0d5fc568-fb03-402a-a384-85332c53a7c5");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "3ebb6a32-479c-4a2d-905b-f13f148de4f8");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "b71206cd-31a5-4130-92b5-f7bd9faa4983");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "bf81a3af-e295-4ff6-9cd2-dd533200d51f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "973a8797-afd2-49c9-b3f1-64edec035d22");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c65a494e-600c-4e0e-8907-5c4b9543888f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cac816b6-a690-48a5-8de9-41407dbbebb4");

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "24e6864e-37e8-4746-8edf-03241a7e48ad", null, null, new DateTime(2023, 7, 16, 11, 42, 1, 814, DateTimeKind.Local).AddTicks(768), false, null, "آدرس", null, "Address" },
                    { "793b68df-c829-4787-b3dd-7cf8ecc8cf6b", null, null, new DateTime(2023, 7, 16, 11, 42, 1, 814, DateTimeKind.Local).AddTicks(695), false, null, "ایمیل", null, "Email" },
                    { "b13008bb-6d7e-4b6e-ba9e-18946d8effaa", null, null, new DateTime(2023, 7, 16, 11, 42, 1, 814, DateTimeKind.Local).AddTicks(652), false, null, "تلفن", null, "Phone" },
                    { "b4cecae4-0d2d-4731-8b48-d25fbae7ef2c", null, null, new DateTime(2023, 7, 16, 11, 42, 1, 814, DateTimeKind.Local).AddTicks(533), false, null, "تلفن همراه", null, "Mobail" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Direction", "InsertTime", "IsDefault", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "2d0abfe4-90e0-45d2-8962-8d13230e9eac", "Rtl", new DateTime(2023, 7, 16, 11, 42, 1, 814, DateTimeKind.Local).AddTicks(888), false, false, "Arabic", null, null },
                    { "d3939489-2bbc-4392-a577-004d92926386", "Ltr", new DateTime(2023, 7, 16, 11, 42, 1, 814, DateTimeKind.Local).AddTicks(828), true, false, "English", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "394b7aca-f297-45d3-8a35-e93eb969c1fb", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "5f762323-120d-4bba-b890-5df9183cb92c", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "8c5fde86-a773-4e26-b324-7be417fc356e", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "24e6864e-37e8-4746-8edf-03241a7e48ad");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "793b68df-c829-4787-b3dd-7cf8ecc8cf6b");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "b13008bb-6d7e-4b6e-ba9e-18946d8effaa");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "b4cecae4-0d2d-4731-8b48-d25fbae7ef2c");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "2d0abfe4-90e0-45d2-8962-8d13230e9eac");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "d3939489-2bbc-4392-a577-004d92926386");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "394b7aca-f297-45d3-8a35-e93eb969c1fb");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5f762323-120d-4bba-b890-5df9183cb92c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8c5fde86-a773-4e26-b324-7be417fc356e");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Languages");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "0d5fc568-fb03-402a-a384-85332c53a7c5", null, null, new DateTime(2023, 7, 16, 11, 19, 32, 88, DateTimeKind.Local).AddTicks(1994), false, null, "آدرس", null, "Address" },
                    { "3ebb6a32-479c-4a2d-905b-f13f148de4f8", null, null, new DateTime(2023, 7, 16, 11, 19, 32, 88, DateTimeKind.Local).AddTicks(1835), false, null, "تلفن همراه", null, "Mobail" },
                    { "b71206cd-31a5-4130-92b5-f7bd9faa4983", null, null, new DateTime(2023, 7, 16, 11, 19, 32, 88, DateTimeKind.Local).AddTicks(1973), false, null, "ایمیل", null, "Email" },
                    { "bf81a3af-e295-4ff6-9cd2-dd533200d51f", null, null, new DateTime(2023, 7, 16, 11, 19, 32, 88, DateTimeKind.Local).AddTicks(1934), false, null, "تلفن", null, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "973a8797-afd2-49c9-b3f1-64edec035d22", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "c65a494e-600c-4e0e-8907-5c4b9543888f", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "cac816b6-a690-48a5-8de9-41407dbbebb4", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });
        }
    }
}
