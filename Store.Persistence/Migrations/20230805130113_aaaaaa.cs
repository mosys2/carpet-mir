using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class aaaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.InsertData(
                table: "SiteContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "1ae59d6a-e8e0-4763-8cf0-2083e931db94", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(620), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "Social Media", null, "Social Media" },
                    { "240408f2-a4da-4f2e-a8be-c459dbaf3c7e", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(425), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "خريطة", null, "Map" },
                    { "2b4c7ea3-e1b0-4c6b-8a3b-143c2268b2ae", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(167), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "Социальные медиа", null, "Social Media" },
                    { "351995c3-f7f7-4f85-ab08-c4d88b29c463", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 149, DateTimeKind.Local).AddTicks(9804), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "Мобильный", null, "Mobile" },
                    { "4beded56-81cc-4f43-9949-3d669dfd5aeb", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(313), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "بريد إلكتروني", null, "Email" },
                    { "4d1012e0-595d-4891-9b26-1028297303c3", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(456), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "Mobile", null, "Mobile" },
                    { "52bac0b3-2a9e-47fe-b3ee-b03e85404790", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(7), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "Телефон", null, "Phone" },
                    { "6206ce9f-4f35-40e7-980c-5eb9def2e988", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(248), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "متحرك", null, "Mobile" },
                    { "74e3501b-49ca-4a75-affc-c4439d517710", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(787), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "Map", null, "Map" },
                    { "8278dd13-05af-409d-98f1-8344a871aced", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(48), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "Электронная почта", null, "Email" },
                    { "834ab53f-53ac-41f2-a36c-e2af71f4a560", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(91), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "Адрес", null, "Address" },
                    { "848928c0-caf4-4643-bf91-86586a8c4bf0", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(390), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "وسائل التواصل الاجتماعي", null, "Social Media" },
                    { "9430db01-99f5-4dc1-a7e7-86eaa3dbda92", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(347), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "عنوان", null, "Address" },
                    { "a1e750c3-eca4-4baf-b886-06001e0b30c2", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(589), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "Address", null, "Address" },
                    { "a9910c2c-fd3c-43fd-bcc0-c1cadfd32692", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(278), false, "ec32e8bb-181e-4ba9-bd10-f19c4ac7c527", null, "هاتف", null, "Phone" },
                    { "afb35a73-c401-4c97-b507-2a384d3aeefd", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(522), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "Email", null, "Email" },
                    { "c95b2332-3093-4278-b973-54297732b372", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(488), false, "f263b149-2a7d-4db2-b060-e4e6b47e6d4e", null, "Phone", null, "Phone" },
                    { "d4fb5f54-be94-4a5d-ab57-d548a2add89b", null, null, new DateTime(2023, 8, 5, 17, 31, 11, 150, DateTimeKind.Local).AddTicks(210), false, "44b1f21e-c8ea-41a4-ae54-5c16a055eda8", null, "карта", null, "Map" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
