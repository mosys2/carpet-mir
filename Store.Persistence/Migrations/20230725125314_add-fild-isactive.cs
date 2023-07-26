using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addfildisactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "2714b3d9-bb08-46dd-8614-b0dcaee77085");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "40372ded-d182-4358-8171-006ae6a7d5f5");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "4bfb3512-7f4d-400a-a8a1-59868b447ae9");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6687f3cb-46a5-41f5-ab35-c9ef9ec67eb4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "862a6d28-5a3a-4b7b-a22a-143e2ef90a5b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "efb705bf-18c2-4735-abe8-4a4a5198395e");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "2ba91747-2c1d-4e1e-868d-fc20833081d5");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "35156ace-97f3-4188-b0f4-0280ca36f2e3");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "548a7a47-048c-498e-b672-787d19ddadde");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "019277c1-9836-4bb0-a1b7-dffdd6ef501b");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "09b91a86-bc1f-4ccc-8010-39d784b2de31");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "0dfff172-537b-4e0c-be31-fa7ef25b4824");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "166302d0-00e4-40c2-8644-bd14dfce8caa");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "3bca19b9-8c48-4edb-aacc-25c215871371");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "4a64fb11-dec1-4603-9fcf-90f3fbd0e7e8");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "55dd052c-ad33-4e55-b628-67f021aadd0c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "57719c05-9c04-4b72-96f2-9ba2a95ba6f9");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "57816dc3-6a20-47a2-a247-2aa7060db9b5");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "88852c3a-a8a3-4c96-b2fe-baa2956e857b");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "8bbef717-696d-421a-9e42-aac759a2b188");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "993a8c77-26de-4b29-8c49-22caa7a0eb8e");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "b38a70af-aebd-43c8-bfaa-c6668c25897c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "d5bb882b-b1f3-4caa-aa97-35bcbafa828c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "da41e7db-687b-4b8c-82cb-ff4064b2582d");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "3dcdbbbe-00a1-4ebc-9f81-a5a10cbef17b");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "9766f6a7-dd1b-47b3-b9fb-e4ae7a824878");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "b1a35fce-3f6a-4730-a342-bc39a1054bb8");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SiteContacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Culture", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "295ed833-3063-4154-88b1-a8f178cacc89", "ru-RU", new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2273), false, "Russia", null, null },
                    { "5e8486a8-4937-4d77-9200-4fa297559a72", "en-US", new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2431), false, "English", null, null },
                    { "f3fb4dd0-5079-4166-bf75-70c620fd7ca3", "ar-SA", new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2378), false, "Arabic", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "5a3afdac-053e-41bc-a271-31c18793cfff", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "97f7bf62-9053-4e17-bd4a-425d3023325f", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "cb4c075b-eef7-400e-aad4-4f157b0f7ae7", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "Description", "Image", "InsertTime", "IsRemoved", "LanguageId", "MetaTag", "RemoveTime", "Title", "UpdateTime", "Video" },
                values: new object[,]
                {
                    { "3eb3af43-6daf-4f51-8e4e-51eca2b6ff1c", null, null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(3338), false, "5e8486a8-4937-4d77-9200-4fa297559a72", null, null, null, null, null },
                    { "956eb376-a148-4c6f-968b-cefcb511185b", null, null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(3250), false, "295ed833-3063-4154-88b1-a8f178cacc89", null, null, null, null, null },
                    { "fd94d321-60e5-4960-a02b-9770be4bf757", null, null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(3290), false, "f3fb4dd0-5079-4166-bf75-70c620fd7ca3", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "BaseUrl", "Description", "Icon", "InsertTime", "IsRemoved", "LanguageId", "Logo", "Logo2", "Menu", "MetaTags", "RemoveTime", "ShowPerPage", "SiteName", "UpdateTime" },
                values: new object[,]
                {
                    { "36913c6f-5429-4770-89a3-6fe987151eff", null, null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2465), false, "295ed833-3063-4154-88b1-a8f178cacc89", null, null, null, null, null, 12, null, null },
                    { "84cddb4b-7f72-4da5-805c-d3504ad51f42", null, null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2549), false, "5e8486a8-4937-4d77-9200-4fa297559a72", null, null, null, null, null, 12, null, null },
                    { "acb66a18-ba43-4d68-928b-c524d0775086", null, null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2499), false, "f3fb4dd0-5079-4166-bf75-70c620fd7ca3", null, null, null, null, null, 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "SiteContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "2c2e6e5f-1d0c-48cb-b0d1-94482d35eeb2", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2881), false, "f3fb4dd0-5079-4166-bf75-70c620fd7ca3", null, "بريد إلكتروني", null, "بريد إلكتروني" },
                    { "2f50e5eb-5fbc-4658-9751-5a1d341bd7a1", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2603), false, "295ed833-3063-4154-88b1-a8f178cacc89", null, "Мобильный", null, "Мобильный" },
                    { "4c86d0b0-3ec4-455e-9202-7b7cfd94668f", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2842), false, "f3fb4dd0-5079-4166-bf75-70c620fd7ca3", null, "هاتف", null, "هاتف" },
                    { "63ba2f63-f713-432b-b769-8294f10cf764", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(3173), false, "5e8486a8-4937-4d77-9200-4fa297559a72", null, "Address", null, "Address" },
                    { "801016b4-ad62-4e84-b62e-c379edc33aae", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2774), false, "295ed833-3063-4154-88b1-a8f178cacc89", null, "Социальные медиа", null, "Социальные медиа" },
                    { "8436a0c8-ac33-4928-baf5-872cc1a53b2a", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2972), false, "f3fb4dd0-5079-4166-bf75-70c620fd7ca3", null, "وسائل التواصل الاجتماعي", null, "وسائل التواصل الاجتماعي" },
                    { "8e708a31-2999-490a-a0ed-0cc110e72d84", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2915), false, "f3fb4dd0-5079-4166-bf75-70c620fd7ca3", null, "عنوان", null, "عنوان" },
                    { "b57836a4-ae1d-4705-b766-13293e7ed70b", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2809), false, "f3fb4dd0-5079-4166-bf75-70c620fd7ca3", null, "متحرك", null, "متحرك" },
                    { "b6d71d1e-02f4-4d40-80ac-43bb03076218", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(3144), false, "5e8486a8-4937-4d77-9200-4fa297559a72", null, "Email", null, "Email" },
                    { "bbb24a68-8597-4d76-b61e-e1a83e4be04c", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2738), false, "295ed833-3063-4154-88b1-a8f178cacc89", null, "Адрес", null, "Адрес" },
                    { "c45260b1-b9e2-41fc-b456-8173b4623b23", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2710), false, "295ed833-3063-4154-88b1-a8f178cacc89", null, "Электронная почта", null, "Электронная почта" },
                    { "cf9a0543-5c9b-4e2c-bfc8-33df1cf46e59", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(2677), false, "295ed833-3063-4154-88b1-a8f178cacc89", null, "Телефон", null, "Телефон" },
                    { "d46e3302-e251-4a21-b204-c746b01e4985", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(3007), false, "5e8486a8-4937-4d77-9200-4fa297559a72", null, "Mobile", null, "Mobile" },
                    { "d56b00dc-7399-440a-bc9a-3cd4e1ce5e7c", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(3200), false, "5e8486a8-4937-4d77-9200-4fa297559a72", null, "Social Media", null, "Social Media" },
                    { "ec0f57ab-35fc-4edd-a3df-e39a997b665f", null, null, new DateTime(2023, 7, 25, 17, 23, 12, 137, DateTimeKind.Local).AddTicks(3111), false, "5e8486a8-4937-4d77-9200-4fa297559a72", null, "Phone", null, "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "3eb3af43-6daf-4f51-8e4e-51eca2b6ff1c");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "956eb376-a148-4c6f-968b-cefcb511185b");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "fd94d321-60e5-4960-a02b-9770be4bf757");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5a3afdac-053e-41bc-a271-31c18793cfff");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "97f7bf62-9053-4e17-bd4a-425d3023325f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cb4c075b-eef7-400e-aad4-4f157b0f7ae7");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "36913c6f-5429-4770-89a3-6fe987151eff");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "84cddb4b-7f72-4da5-805c-d3504ad51f42");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "acb66a18-ba43-4d68-928b-c524d0775086");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "2c2e6e5f-1d0c-48cb-b0d1-94482d35eeb2");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "2f50e5eb-5fbc-4658-9751-5a1d341bd7a1");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "4c86d0b0-3ec4-455e-9202-7b7cfd94668f");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "63ba2f63-f713-432b-b769-8294f10cf764");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "801016b4-ad62-4e84-b62e-c379edc33aae");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "8436a0c8-ac33-4928-baf5-872cc1a53b2a");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "8e708a31-2999-490a-a0ed-0cc110e72d84");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "b57836a4-ae1d-4705-b766-13293e7ed70b");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "b6d71d1e-02f4-4d40-80ac-43bb03076218");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "bbb24a68-8597-4d76-b61e-e1a83e4be04c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "c45260b1-b9e2-41fc-b456-8173b4623b23");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "cf9a0543-5c9b-4e2c-bfc8-33df1cf46e59");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "d46e3302-e251-4a21-b204-c746b01e4985");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "d56b00dc-7399-440a-bc9a-3cd4e1ce5e7c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "ec0f57ab-35fc-4edd-a3df-e39a997b665f");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "295ed833-3063-4154-88b1-a8f178cacc89");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "5e8486a8-4937-4d77-9200-4fa297559a72");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "f3fb4dd0-5079-4166-bf75-70c620fd7ca3");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SiteContacts");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Culture", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "3dcdbbbe-00a1-4ebc-9f81-a5a10cbef17b", "ar-SA", new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(6610), false, "Arabic", null, null },
                    { "9766f6a7-dd1b-47b3-b9fb-e4ae7a824878", "en-US", new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(6679), false, "English", null, null },
                    { "b1a35fce-3f6a-4730-a342-bc39a1054bb8", "ru-RU", new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(6498), false, "Russia", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "6687f3cb-46a5-41f5-ab35-c9ef9ec67eb4", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "862a6d28-5a3a-4b7b-a22a-143e2ef90a5b", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "efb705bf-18c2-4735-abe8-4a4a5198395e", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "Description", "Image", "InsertTime", "IsRemoved", "LanguageId", "MetaTag", "RemoveTime", "Title", "UpdateTime", "Video" },
                values: new object[,]
                {
                    { "2714b3d9-bb08-46dd-8614-b0dcaee77085", null, null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7755), false, "3dcdbbbe-00a1-4ebc-9f81-a5a10cbef17b", null, null, null, null, null },
                    { "40372ded-d182-4358-8171-006ae6a7d5f5", null, null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7692), false, "b1a35fce-3f6a-4730-a342-bc39a1054bb8", null, null, null, null, null },
                    { "4bfb3512-7f4d-400a-a8a1-59868b447ae9", null, null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7785), false, "9766f6a7-dd1b-47b3-b9fb-e4ae7a824878", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "BaseUrl", "Description", "Icon", "InsertTime", "IsRemoved", "LanguageId", "Logo", "Logo2", "Menu", "MetaTags", "RemoveTime", "ShowPerPage", "SiteName", "UpdateTime" },
                values: new object[,]
                {
                    { "2ba91747-2c1d-4e1e-868d-fc20833081d5", null, null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(6799), false, "9766f6a7-dd1b-47b3-b9fb-e4ae7a824878", null, null, null, null, null, 12, null, null },
                    { "35156ace-97f3-4188-b0f4-0280ca36f2e3", null, null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(6764), false, "3dcdbbbe-00a1-4ebc-9f81-a5a10cbef17b", null, null, null, null, null, 12, null, null },
                    { "548a7a47-048c-498e-b672-787d19ddadde", null, null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(6724), false, "b1a35fce-3f6a-4730-a342-bc39a1054bb8", null, null, null, null, null, 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "SiteContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "019277c1-9836-4bb0-a1b7-dffdd6ef501b", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7585), false, "9766f6a7-dd1b-47b3-b9fb-e4ae7a824878", null, "Address", null, "Address" },
                    { "09b91a86-bc1f-4ccc-8010-39d784b2de31", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7494), false, "9766f6a7-dd1b-47b3-b9fb-e4ae7a824878", null, "Mobile", null, "Mobile" },
                    { "0dfff172-537b-4e0c-be31-fa7ef25b4824", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(6992), false, "b1a35fce-3f6a-4730-a342-bc39a1054bb8", null, "Телефон", null, "Телефон" },
                    { "166302d0-00e4-40c2-8644-bd14dfce8caa", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7130), false, "b1a35fce-3f6a-4730-a342-bc39a1054bb8", null, "Социальные медиа", null, "Социальные медиа" },
                    { "3bca19b9-8c48-4edb-aacc-25c215871371", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7243), false, "3dcdbbbe-00a1-4ebc-9f81-a5a10cbef17b", null, "بريد إلكتروني", null, "بريد إلكتروني" },
                    { "4a64fb11-dec1-4603-9fcf-90f3fbd0e7e8", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7530), false, "9766f6a7-dd1b-47b3-b9fb-e4ae7a824878", null, "Phone", null, "Phone" },
                    { "55dd052c-ad33-4e55-b628-67f021aadd0c", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7213), false, "3dcdbbbe-00a1-4ebc-9f81-a5a10cbef17b", null, "هاتف", null, "هاتف" },
                    { "57719c05-9c04-4b72-96f2-9ba2a95ba6f9", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(6853), false, "b1a35fce-3f6a-4730-a342-bc39a1054bb8", null, "Мобильный", null, "Мобильный" },
                    { "57816dc3-6a20-47a2-a247-2aa7060db9b5", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7174), false, "3dcdbbbe-00a1-4ebc-9f81-a5a10cbef17b", null, "متحرك", null, "متحرك" },
                    { "88852c3a-a8a3-4c96-b2fe-baa2956e857b", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7086), false, "b1a35fce-3f6a-4730-a342-bc39a1054bb8", null, "Адрес", null, "Адрес" },
                    { "8bbef717-696d-421a-9e42-aac759a2b188", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7424), false, "3dcdbbbe-00a1-4ebc-9f81-a5a10cbef17b", null, "وسائل التواصل الاجتماعي", null, "وسائل التواصل الاجتماعي" },
                    { "993a8c77-26de-4b29-8c49-22caa7a0eb8e", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7559), false, "9766f6a7-dd1b-47b3-b9fb-e4ae7a824878", null, "Email", null, "Email" },
                    { "b38a70af-aebd-43c8-bfaa-c6668c25897c", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7611), false, "9766f6a7-dd1b-47b3-b9fb-e4ae7a824878", null, "Social Media", null, "Social Media" },
                    { "d5bb882b-b1f3-4caa-aa97-35bcbafa828c", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7052), false, "b1a35fce-3f6a-4730-a342-bc39a1054bb8", null, "Электронная почта", null, "Электронная почта" },
                    { "da41e7db-687b-4b8c-82cb-ff4064b2582d", null, null, new DateTime(2023, 7, 25, 13, 22, 24, 651, DateTimeKind.Local).AddTicks(7271), false, "3dcdbbbe-00a1-4ebc-9f81-a5a10cbef17b", null, "عنوان", null, "عنوان" }
                });
        }
    }
}
