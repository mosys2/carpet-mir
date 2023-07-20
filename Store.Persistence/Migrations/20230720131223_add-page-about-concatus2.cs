using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addpageaboutconcatus2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8064e260-9aa7-4ff6-aef3-e5e5bf0fe56c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "83c5c2f6-ce2c-4462-b5c6-d91cf48da44c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dbf80be1-71df-4e22-b0c2-a7fcfdefc0fb");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "6ff2bd6b-8b1a-4ae1-ab63-8fac7feadcca");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "ab221565-c426-463d-9a27-21354e1ddfd0");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "df033d83-13c0-4718-b2a7-51d0168371a8");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "15ad804c-1a15-4a3d-a326-cf297b113437");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "28cd87cd-ee33-4f0e-8776-0c9e061caf92");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "315841b7-8afb-4550-867e-d7661b868aaa");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "3abff290-814c-4bde-8313-1780fe4b76ee");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "3cfdce59-2328-42ce-b9cc-0fbc6041d349");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "6aa124cb-3f9c-4211-9b95-2bf190aba6e1");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "72264eac-d23e-415f-b0bc-86247cd9843a");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "86d3a8d5-cdfc-4d38-bb28-835065542603");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "9ad36e38-26e9-4464-b683-272c7a42d39c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "b76c46a0-81a5-4aba-9cac-146b96479156");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "c5632efd-6c89-40b0-922d-3c6b9eba3cf8");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "d45655d7-6d89-4a02-b709-49e57a2556d4");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "d9437e05-8e6e-404a-a497-f58b6ff89805");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "e6e8c8b4-7fab-4c90-93bd-c90c4f38a836");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "ee06c27d-7f48-4159-a75d-e47d348fb92c");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "72849750-e87a-4a00-bd14-8ce9381fc9aa");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "f31de1d6-d1fa-439d-98ea-6b92344634c3");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "f584deed-63c1-4c2e-8a5b-dc3181023f44");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "07c0e07d-0973-463d-85f6-8aa00384e138", new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(7878), false, "Russia", null, null },
                    { "563e931a-ecc7-4eb7-bcec-8dd56de9f106", new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8049), false, "English", null, null },
                    { "db330ece-2fd4-4893-a019-f24170c797cc", new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8022), false, "Arabic", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "459c3fef-32a4-458b-854b-3395c7fd4ca5", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "598c92cf-087b-4605-b47a-91186876f506", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "5f1d3f19-08c1-4c1d-8756-c9dfda04a6db", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "Description", "Image", "InsertTime", "IsRemoved", "LanguageId", "MetaTag", "RemoveTime", "Title", "UpdateTime", "Video" },
                values: new object[,]
                {
                    { "03fba437-cac2-4415-9884-94e4a821f41d", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9487), false, "563e931a-ecc7-4eb7-bcec-8dd56de9f106", null, null, "Social Media", null, null },
                    { "057980a3-0782-4d8c-bb39-d8ab0aeabbb1", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9428), false, "563e931a-ecc7-4eb7-bcec-8dd56de9f106", null, null, "Email", null, null },
                    { "06f6e1dd-f041-4807-954a-949b6ac94fe9", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9009), false, "07c0e07d-0973-463d-85f6-8aa00384e138", null, null, "Адрес", null, null },
                    { "35755fa7-9891-4d8d-9862-5a0894d97d64", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8876), false, "07c0e07d-0973-463d-85f6-8aa00384e138", null, null, "Телефон", null, null },
                    { "48b5a445-ad86-422b-ab04-1407d089a6b4", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8836), false, "07c0e07d-0973-463d-85f6-8aa00384e138", null, null, "Мобильный", null, null },
                    { "4ab5eb80-dc37-43ac-950d-74085b7267cc", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9041), false, "07c0e07d-0973-463d-85f6-8aa00384e138", null, null, "Социальные медиа", null, null },
                    { "5566e310-1909-47c3-8fdb-23999db3456d", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9397), false, "563e931a-ecc7-4eb7-bcec-8dd56de9f106", null, null, "Phone", null, null },
                    { "5acd7b11-9c98-4680-af53-019be43ac476", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9325), false, "db330ece-2fd4-4893-a019-f24170c797cc", null, null, "وسائل التواصل الاجتماعي", null, null },
                    { "6a1a459f-2d0e-4f86-a943-b0ebcbfc433d", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9234), false, "db330ece-2fd4-4893-a019-f24170c797cc", null, null, "عنوان", null, null },
                    { "904fe8be-bfe2-4273-b285-3d3cca91cf91", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9457), false, "563e931a-ecc7-4eb7-bcec-8dd56de9f106", null, null, "Address", null, null },
                    { "90df44b0-cf1c-4b41-ae2b-13a378596ad2", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9196), false, "db330ece-2fd4-4893-a019-f24170c797cc", null, null, "بريد إلكتروني", null, null },
                    { "a49731db-8968-44a1-bc14-6911ffef7403", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9075), false, "db330ece-2fd4-4893-a019-f24170c797cc", null, null, "متحرك", null, null },
                    { "ba45a425-1854-4028-b136-6a2ab18d4f78", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8913), false, "07c0e07d-0973-463d-85f6-8aa00384e138", null, null, "Электронная почта", null, null },
                    { "e83804c8-948c-4d42-8b52-5d55568c03a7", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9164), false, "db330ece-2fd4-4893-a019-f24170c797cc", null, null, "هاتف", null, null },
                    { "f0cc8fff-4342-4786-94cd-693f56f5a13a", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(9367), false, "563e931a-ecc7-4eb7-bcec-8dd56de9f106", null, null, "Mobile", null, null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "BaseUrl", "Description", "Icon", "InsertTime", "IsRemoved", "LanguageId", "Logo", "Logo2", "MetaTags", "RemoveTime", "ShowPerPage", "SiteName", "UpdateTime" },
                values: new object[,]
                {
                    { "54c25365-2b97-4a08-85e9-cb22d68bd01d", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8081), false, "07c0e07d-0973-463d-85f6-8aa00384e138", null, null, null, null, 12, null, null },
                    { "72a5277e-17d7-4fd9-bf83-ac2166c47430", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8117), false, "db330ece-2fd4-4893-a019-f24170c797cc", null, null, null, null, 12, null, null },
                    { "a42393fd-67dc-49f8-92ec-601e1d8e34e8", null, null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8153), false, "563e931a-ecc7-4eb7-bcec-8dd56de9f106", null, null, null, null, 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "SiteContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "18c94817-6329-4e54-b2b5-048d70b7663c", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8791), false, "563e931a-ecc7-4eb7-bcec-8dd56de9f106", null, "Social Media", null, "Social Media" },
                    { "32daa855-c55f-45dc-bcdc-1a6fd3f81d1e", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8732), false, "563e931a-ecc7-4eb7-bcec-8dd56de9f106", null, "Email", null, "Email" },
                    { "37de5f75-4a1c-4c10-aebb-b2f191b3b572", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8333), false, "07c0e07d-0973-463d-85f6-8aa00384e138", null, "Телефон", null, "Телефон" },
                    { "3fcfea32-d2f9-4aee-ad9c-98ed5ebe9213", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8370), false, "07c0e07d-0973-463d-85f6-8aa00384e138", null, "Электронная почта", null, "Электронная почта" },
                    { "4665a361-5c0a-4697-9b24-63043e658224", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8642), false, "db330ece-2fd4-4893-a019-f24170c797cc", null, "وسائل التواصل الاجتماعي", null, "وسائل التواصل الاجتماعي" },
                    { "528129da-afc7-420b-9db3-f95a7cf7da11", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8702), false, "563e931a-ecc7-4eb7-bcec-8dd56de9f106", null, "Phone", null, "Phone" },
                    { "86b43f64-6675-4c9f-a64b-e65157a7d55f", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8672), false, "563e931a-ecc7-4eb7-bcec-8dd56de9f106", null, "Mobile", null, "Mobile" },
                    { "8b294cd9-f7d5-4400-bdb4-5c01a460981b", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8283), false, "07c0e07d-0973-463d-85f6-8aa00384e138", null, "Мобильный", null, "Мобильный" },
                    { "8b7d5ea4-9486-4e3b-b126-f52e7ab2be50", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8474), false, "db330ece-2fd4-4893-a019-f24170c797cc", null, "متحرك", null, "متحرك" },
                    { "9c86310d-0eb4-43a5-a240-ca2f0d21c0df", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8436), false, "07c0e07d-0973-463d-85f6-8aa00384e138", null, "Социальные медиа", null, "Социальные медиа" },
                    { "a12b05ae-3cdc-4e6d-8f51-99cd4cd7f97a", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8761), false, "563e931a-ecc7-4eb7-bcec-8dd56de9f106", null, "Address", null, "Address" },
                    { "a36a70ae-a0fc-41ed-a5ae-431c95798b27", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8515), false, "db330ece-2fd4-4893-a019-f24170c797cc", null, "هاتف", null, "هاتف" },
                    { "b5ee1d5b-890d-4598-9f08-ff3481725e5b", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8547), false, "db330ece-2fd4-4893-a019-f24170c797cc", null, "بريد إلكتروني", null, "بريد إلكتروني" },
                    { "d42de79b-27cd-4de5-b590-22c7169f95f6", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8577), false, "db330ece-2fd4-4893-a019-f24170c797cc", null, "عنوان", null, "عنوان" },
                    { "fb615dc0-7e77-4e15-8325-753e0dbb5bf6", null, null, new DateTime(2023, 7, 20, 17, 42, 21, 589, DateTimeKind.Local).AddTicks(8400), false, "07c0e07d-0973-463d-85f6-8aa00384e138", null, "Адрес", null, "Адрес" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "03fba437-cac2-4415-9884-94e4a821f41d");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "057980a3-0782-4d8c-bb39-d8ab0aeabbb1");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "06f6e1dd-f041-4807-954a-949b6ac94fe9");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "35755fa7-9891-4d8d-9862-5a0894d97d64");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "48b5a445-ad86-422b-ab04-1407d089a6b4");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "4ab5eb80-dc37-43ac-950d-74085b7267cc");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "5566e310-1909-47c3-8fdb-23999db3456d");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "5acd7b11-9c98-4680-af53-019be43ac476");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "6a1a459f-2d0e-4f86-a943-b0ebcbfc433d");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "904fe8be-bfe2-4273-b285-3d3cca91cf91");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "90df44b0-cf1c-4b41-ae2b-13a378596ad2");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "a49731db-8968-44a1-bc14-6911ffef7403");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "ba45a425-1854-4028-b136-6a2ab18d4f78");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "e83804c8-948c-4d42-8b52-5d55568c03a7");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "f0cc8fff-4342-4786-94cd-693f56f5a13a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "459c3fef-32a4-458b-854b-3395c7fd4ca5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "598c92cf-087b-4605-b47a-91186876f506");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5f1d3f19-08c1-4c1d-8756-c9dfda04a6db");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "54c25365-2b97-4a08-85e9-cb22d68bd01d");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "72a5277e-17d7-4fd9-bf83-ac2166c47430");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "a42393fd-67dc-49f8-92ec-601e1d8e34e8");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "18c94817-6329-4e54-b2b5-048d70b7663c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "32daa855-c55f-45dc-bcdc-1a6fd3f81d1e");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "37de5f75-4a1c-4c10-aebb-b2f191b3b572");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "3fcfea32-d2f9-4aee-ad9c-98ed5ebe9213");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "4665a361-5c0a-4697-9b24-63043e658224");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "528129da-afc7-420b-9db3-f95a7cf7da11");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "86b43f64-6675-4c9f-a64b-e65157a7d55f");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "8b294cd9-f7d5-4400-bdb4-5c01a460981b");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "8b7d5ea4-9486-4e3b-b126-f52e7ab2be50");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "9c86310d-0eb4-43a5-a240-ca2f0d21c0df");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "a12b05ae-3cdc-4e6d-8f51-99cd4cd7f97a");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "a36a70ae-a0fc-41ed-a5ae-431c95798b27");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "b5ee1d5b-890d-4598-9f08-ff3481725e5b");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "d42de79b-27cd-4de5-b590-22c7169f95f6");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "fb615dc0-7e77-4e15-8325-753e0dbb5bf6");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "07c0e07d-0973-463d-85f6-8aa00384e138");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "563e931a-ecc7-4eb7-bcec-8dd56de9f106");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "db330ece-2fd4-4893-a019-f24170c797cc");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "72849750-e87a-4a00-bd14-8ce9381fc9aa", new DateTime(2023, 7, 20, 17, 34, 7, 605, DateTimeKind.Local).AddTicks(9041), false, "Russia", null, null },
                    { "f31de1d6-d1fa-439d-98ea-6b92344634c3", new DateTime(2023, 7, 20, 17, 34, 7, 605, DateTimeKind.Local).AddTicks(9988), false, "English", null, null },
                    { "f584deed-63c1-4c2e-8a5b-dc3181023f44", new DateTime(2023, 7, 20, 17, 34, 7, 605, DateTimeKind.Local).AddTicks(9937), false, "Arabic", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "8064e260-9aa7-4ff6-aef3-e5e5bf0fe56c", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "83c5c2f6-ce2c-4462-b5c6-d91cf48da44c", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "dbf80be1-71df-4e22-b0c2-a7fcfdefc0fb", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "BaseUrl", "Description", "Icon", "InsertTime", "IsRemoved", "LanguageId", "Logo", "Logo2", "MetaTags", "RemoveTime", "ShowPerPage", "SiteName", "UpdateTime" },
                values: new object[,]
                {
                    { "6ff2bd6b-8b1a-4ae1-ab63-8fac7feadcca", null, null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(70), false, "f584deed-63c1-4c2e-8a5b-dc3181023f44", null, null, null, null, 12, null, null },
                    { "ab221565-c426-463d-9a27-21354e1ddfd0", null, null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(106), false, "f31de1d6-d1fa-439d-98ea-6b92344634c3", null, null, null, null, 12, null, null },
                    { "df033d83-13c0-4718-b2a7-51d0168371a8", null, null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(26), false, "72849750-e87a-4a00-bd14-8ce9381fc9aa", null, null, null, null, 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "SiteContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "15ad804c-1a15-4a3d-a326-cf297b113437", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(544), false, "f31de1d6-d1fa-439d-98ea-6b92344634c3", null, "Mobile", null, "Mobile" },
                    { "28cd87cd-ee33-4f0e-8776-0c9e061caf92", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(417), false, "f584deed-63c1-4c2e-8a5b-dc3181023f44", null, "بريد إلكتروني", null, "بريد إلكتروني" },
                    { "315841b7-8afb-4550-867e-d7661b868aaa", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(455), false, "f584deed-63c1-4c2e-8a5b-dc3181023f44", null, "عنوان", null, "عنوان" },
                    { "3abff290-814c-4bde-8313-1780fe4b76ee", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(201), false, "72849750-e87a-4a00-bd14-8ce9381fc9aa", null, "Телефон", null, "Телефон" },
                    { "3cfdce59-2328-42ce-b9cc-0fbc6041d349", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(333), false, "f584deed-63c1-4c2e-8a5b-dc3181023f44", null, "متحرك", null, "متحرك" },
                    { "6aa124cb-3f9c-4211-9b95-2bf190aba6e1", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(512), false, "f584deed-63c1-4c2e-8a5b-dc3181023f44", null, "وسائل التواصل الاجتماعي", null, "وسائل التواصل الاجتماعي" },
                    { "72264eac-d23e-415f-b0bc-86247cd9843a", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(383), false, "f584deed-63c1-4c2e-8a5b-dc3181023f44", null, "هاتف", null, "هاتف" },
                    { "86d3a8d5-cdfc-4d38-bb28-835065542603", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(299), false, "72849750-e87a-4a00-bd14-8ce9381fc9aa", null, "Социальные медиа", null, "Социальные медиа" },
                    { "9ad36e38-26e9-4464-b683-272c7a42d39c", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(636), false, "f31de1d6-d1fa-439d-98ea-6b92344634c3", null, "Address", null, "Address" },
                    { "b76c46a0-81a5-4aba-9cac-146b96479156", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(606), false, "f31de1d6-d1fa-439d-98ea-6b92344634c3", null, "Email", null, "Email" },
                    { "c5632efd-6c89-40b0-922d-3c6b9eba3cf8", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(167), false, "72849750-e87a-4a00-bd14-8ce9381fc9aa", null, "Мобильный", null, "Мобильный" },
                    { "d45655d7-6d89-4a02-b709-49e57a2556d4", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(576), false, "f31de1d6-d1fa-439d-98ea-6b92344634c3", null, "Phone", null, "Phone" },
                    { "d9437e05-8e6e-404a-a497-f58b6ff89805", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(232), false, "72849750-e87a-4a00-bd14-8ce9381fc9aa", null, "Электронная почта", null, "Электронная почта" },
                    { "e6e8c8b4-7fab-4c90-93bd-c90c4f38a836", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(665), false, "f31de1d6-d1fa-439d-98ea-6b92344634c3", null, "Social Media", null, "Social Media" },
                    { "ee06c27d-7f48-4159-a75d-e47d348fb92c", null, null, new DateTime(2023, 7, 20, 17, 34, 7, 606, DateTimeKind.Local).AddTicks(263), false, "72849750-e87a-4a00-bd14-8ce9381fc9aa", null, "Адрес", null, "Адрес" }
                });
        }
    }
}
