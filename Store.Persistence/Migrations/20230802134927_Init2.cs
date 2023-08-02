using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Culture", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "29ea9de0-f5b4-4d43-a2e5-e77e80762ac1", "en-US", new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(4695), false, "English", null, null },
                    { "b7856e44-c551-4ae4-b3ba-fefa07af091a", "ru-RU", new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(4523), false, "Russia", null, null },
                    { "d760f861-7947-44e3-970e-64eb0d22d526", "ar-SA", new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(4667), false, "Arabic", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "9d99121b-9556-4150-bdcb-919c7896b03a", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "f88838af-3103-4c32-b3ba-c872eab6200b", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "fc0d4492-4ad6-45e7-a58a-0de96bc7f73a", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "Description", "Image", "InsertTime", "IsRemoved", "LanguageId", "MetaTag", "RemoveTime", "Title", "UpdateTime", "Video" },
                values: new object[,]
                {
                    { "8aa8331d-c855-4c50-98b2-03ce8725996e", null, null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5712), false, "d760f861-7947-44e3-970e-64eb0d22d526", null, null, null, null, null },
                    { "a79349f8-82df-4578-9ebb-71140e2a8d87", null, null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5544), false, "b7856e44-c551-4ae4-b3ba-fefa07af091a", null, null, null, null, null },
                    { "cc8e08ff-b73d-4051-9ffc-0e78db312404", null, null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5742), false, "29ea9de0-f5b4-4d43-a2e5-e77e80762ac1", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "BaseUrl", "Description", "Icon", "InsertTime", "IsRemoved", "LanguageId", "Logo", "Logo2", "Menu", "MetaTags", "RemoveTime", "ShowPerPage", "SiteName", "UpdateTime" },
                values: new object[,]
                {
                    { "2ac7a4b2-f951-495c-a70a-0737bc89e700", null, null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(4791), false, "d760f861-7947-44e3-970e-64eb0d22d526", null, null, null, null, null, 12, null, null },
                    { "53ebdaa8-6e6d-4d05-942a-d697775721b4", null, null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(4824), false, "29ea9de0-f5b4-4d43-a2e5-e77e80762ac1", null, null, null, null, null, 12, null, null },
                    { "beeca9e9-d188-4b34-baf9-142b233f7a90", null, null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(4735), false, "b7856e44-c551-4ae4-b3ba-fefa07af091a", null, null, null, null, null, 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "SiteContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "0278e76d-f310-4191-8c7d-3c0229b1c740", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5036), false, "b7856e44-c551-4ae4-b3ba-fefa07af091a", null, "Адрес", null, "Address" },
                    { "1ccfce53-9e7f-4c11-9ff4-4c1468a61537", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5072), false, "b7856e44-c551-4ae4-b3ba-fefa07af091a", null, "Социальные медиа", null, "Social Media" },
                    { "28bd4e47-1a29-458a-a59c-303e604df20a", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5351), false, "29ea9de0-f5b4-4d43-a2e5-e77e80762ac1", null, "Mobile", null, "Mobile" },
                    { "54fe28ba-e469-47e4-9011-dae9619a1373", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(4904), false, "b7856e44-c551-4ae4-b3ba-fefa07af091a", null, "Телефон", null, "Phone" },
                    { "675093fd-0ea3-4891-8917-0595b234363d", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5377), false, "29ea9de0-f5b4-4d43-a2e5-e77e80762ac1", null, "Phone", null, "Phone" },
                    { "75913aa6-efda-419f-a2af-52cc00f88803", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5204), false, "d760f861-7947-44e3-970e-64eb0d22d526", null, "بريد إلكتروني", null, "Email" },
                    { "8ccdcaac-9aac-4659-9162-b481b4fcd386", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5468), false, "29ea9de0-f5b4-4d43-a2e5-e77e80762ac1", null, "Social Media", null, "Social Media" },
                    { "9ea13337-d199-4fc8-aeef-1efd9c873506", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5149), false, "d760f861-7947-44e3-970e-64eb0d22d526", null, "متحرك", null, "Mobile" },
                    { "b2bcdb1f-6aa9-44eb-9213-58f340b6cfda", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5266), false, "d760f861-7947-44e3-970e-64eb0d22d526", null, "عنوان", null, "Address" },
                    { "bc99ca16-d6c9-4926-ae11-8eb98206a8ae", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5412), false, "29ea9de0-f5b4-4d43-a2e5-e77e80762ac1", null, "Email", null, "Email" },
                    { "c94c2e91-e347-4697-bc1c-065354e75fae", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5440), false, "29ea9de0-f5b4-4d43-a2e5-e77e80762ac1", null, "Address", null, "Address" },
                    { "d1c6678f-23c5-4a00-b2e4-2fba1030c6b4", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5006), false, "b7856e44-c551-4ae4-b3ba-fefa07af091a", null, "Электронная почта", null, "Email" },
                    { "dbfc0627-6f99-47ea-952a-f235c06a78e7", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5498), false, "29ea9de0-f5b4-4d43-a2e5-e77e80762ac1", null, "карта", null, "Social Media" },
                    { "e8b97e52-19b7-4d99-aacd-d41bc0593d25", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5323), false, "d760f861-7947-44e3-970e-64eb0d22d526", null, "карта", null, "Social Media" },
                    { "e9b3cb1e-709a-4264-bfb7-087796bd12fd", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5177), false, "d760f861-7947-44e3-970e-64eb0d22d526", null, "هاتف", null, "Phone" },
                    { "ec6ed098-94d8-4a09-9774-feabf564476c", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5107), false, "b7856e44-c551-4ae4-b3ba-fefa07af091a", null, "карта", null, "Social Media" },
                    { "f6a8cb82-a553-44c0-a1fd-4b13eabb5866", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(4867), false, "b7856e44-c551-4ae4-b3ba-fefa07af091a", null, "Мобильный", null, "Mobile" },
                    { "f836657c-5022-4477-934a-3a4ebd5b5b3c", null, null, new DateTime(2023, 8, 2, 18, 19, 25, 650, DateTimeKind.Local).AddTicks(5294), false, "d760f861-7947-44e3-970e-64eb0d22d526", null, "وسائل التواصل الاجتماعي", null, "Social Media" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "8aa8331d-c855-4c50-98b2-03ce8725996e");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "a79349f8-82df-4578-9ebb-71140e2a8d87");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "cc8e08ff-b73d-4051-9ffc-0e78db312404");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9d99121b-9556-4150-bdcb-919c7896b03a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f88838af-3103-4c32-b3ba-c872eab6200b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fc0d4492-4ad6-45e7-a58a-0de96bc7f73a");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "2ac7a4b2-f951-495c-a70a-0737bc89e700");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "53ebdaa8-6e6d-4d05-942a-d697775721b4");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "beeca9e9-d188-4b34-baf9-142b233f7a90");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "0278e76d-f310-4191-8c7d-3c0229b1c740");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "1ccfce53-9e7f-4c11-9ff4-4c1468a61537");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "28bd4e47-1a29-458a-a59c-303e604df20a");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "54fe28ba-e469-47e4-9011-dae9619a1373");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "675093fd-0ea3-4891-8917-0595b234363d");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "75913aa6-efda-419f-a2af-52cc00f88803");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "8ccdcaac-9aac-4659-9162-b481b4fcd386");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "9ea13337-d199-4fc8-aeef-1efd9c873506");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "b2bcdb1f-6aa9-44eb-9213-58f340b6cfda");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "bc99ca16-d6c9-4926-ae11-8eb98206a8ae");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "c94c2e91-e347-4697-bc1c-065354e75fae");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "d1c6678f-23c5-4a00-b2e4-2fba1030c6b4");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "dbfc0627-6f99-47ea-952a-f235c06a78e7");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "e8b97e52-19b7-4d99-aacd-d41bc0593d25");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "e9b3cb1e-709a-4264-bfb7-087796bd12fd");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "ec6ed098-94d8-4a09-9774-feabf564476c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "f6a8cb82-a553-44c0-a1fd-4b13eabb5866");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "f836657c-5022-4477-934a-3a4ebd5b5b3c");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "29ea9de0-f5b4-4d43-a2e5-e77e80762ac1");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "b7856e44-c551-4ae4-b3ba-fefa07af091a");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "d760f861-7947-44e3-970e-64eb0d22d526");
        }
    }
}
