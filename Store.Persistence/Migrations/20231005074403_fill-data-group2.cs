using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class filldatagroup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GroupItems",
                columns: new[] { "Id", "GroupId", "GroupType", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime" },
                values: new object[] { "81f7d3ec-5534-40c5-9223-ecaa878cacad", null, 6, new DateTime(2023, 10, 5, 11, 14, 1, 998, DateTimeKind.Local).AddTicks(7997), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "DownloadCatalouge", null });

            migrationBuilder.InsertData(
                table: "GroupItems",
                columns: new[] { "Id", "GroupId", "GroupType", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime" },
                values: new object[] { "c1adcec3-c1e2-4caa-9d29-e3264fd24476", null, 6, new DateTime(2023, 10, 5, 11, 14, 1, 998, DateTimeKind.Local).AddTicks(8473), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "DownloadCatalouge", null });

            migrationBuilder.InsertData(
                table: "GroupItems",
                columns: new[] { "Id", "GroupId", "GroupType", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime" },
                values: new object[] { "c77a3912-ae00-4908-8aa7-959b63c30137", null, 6, new DateTime(2023, 10, 5, 11, 14, 1, 998, DateTimeKind.Local).AddTicks(8389), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "DownloadCatalouge", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "81f7d3ec-5534-40c5-9223-ecaa878cacad");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "c1adcec3-c1e2-4caa-9d29-e3264fd24476");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "c77a3912-ae00-4908-8aa7-959b63c30137");
        }
    }
}
