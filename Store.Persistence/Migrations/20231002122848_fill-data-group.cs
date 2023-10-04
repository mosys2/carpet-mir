using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class filldatagroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GroupItems",
                columns: new[] { "Id", "GroupId", "GroupType", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime" },
                values: new object[,]
                {
                    { "08eb200a-38e0-4c78-b189-fb5e2dfb8900", null, 3, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8417), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "Designing", null },
                    { "12ad50f3-fe8d-4798-a5e4-e94c1b3956ac", null, 4, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8447), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "Contract", null },
                    { "57151a3f-e9e3-4a6f-9312-029dff9df3a1", null, 1, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8362), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "OrderRequestForm", null },
                    { "5892e316-29f5-4446-ae1c-c76942484092", null, 4, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8296), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "Contract", null },
                    { "6f02cf86-efd6-4f50-a710-7a9a99c64071", null, 2, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8216), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "RequestReview", null },
                    { "7a025c8c-a3fc-417b-96dd-dd752fc2ee95", null, 2, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8029), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "RequestReview", null },
                    { "969a9857-6b9b-448f-990d-ab45e5000b34", null, 5, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8327), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "CarpetManufacturing", null },
                    { "a53b7f03-1e85-4b1d-bcdf-275e60b9e398", null, 3, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8245), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "Designing", null },
                    { "aa33b785-6f00-41f6-80df-78e27c403024", null, 1, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8182), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "OrderRequestForm", null },
                    { "abfd9515-515c-47c9-8686-0c4dcbd807c8", null, 1, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(7695), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "OrderRequestForm", null },
                    { "b5b3e251-aad6-44d8-805c-9d0d7cf27893", null, 5, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8473), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "CarpetManufacturing", null },
                    { "e35aedcb-1ba6-400c-9af0-bcc91ceca198", null, 3, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8073), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "Designing", null },
                    { "efb1b952-674e-4835-bda2-8f162aec196f", null, 5, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8147), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "CarpetManufacturing", null },
                    { "f1a4e109-c6b6-4281-8db3-20a05127a9cd", null, 4, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8106), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "Contract", null },
                    { "ff4f3584-95f4-40af-9c41-7cddeb79dd20", null, 2, new DateTime(2023, 10, 2, 15, 58, 46, 186, DateTimeKind.Local).AddTicks(8389), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "RequestReview", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "08eb200a-38e0-4c78-b189-fb5e2dfb8900");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "12ad50f3-fe8d-4798-a5e4-e94c1b3956ac");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "57151a3f-e9e3-4a6f-9312-029dff9df3a1");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "5892e316-29f5-4446-ae1c-c76942484092");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "6f02cf86-efd6-4f50-a710-7a9a99c64071");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "7a025c8c-a3fc-417b-96dd-dd752fc2ee95");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "969a9857-6b9b-448f-990d-ab45e5000b34");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "a53b7f03-1e85-4b1d-bcdf-275e60b9e398");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "aa33b785-6f00-41f6-80df-78e27c403024");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "abfd9515-515c-47c9-8686-0c4dcbd807c8");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "b5b3e251-aad6-44d8-805c-9d0d7cf27893");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "e35aedcb-1ba6-400c-9af0-bcc91ceca198");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "efb1b952-674e-4835-bda2-8f162aec196f");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "f1a4e109-c6b6-4281-8db3-20a05127a9cd");

            migrationBuilder.DeleteData(
                table: "GroupItems",
                keyColumn: "Id",
                keyValue: "ff4f3584-95f4-40af-9c41-7cddeb79dd20");
        }
    }
}
