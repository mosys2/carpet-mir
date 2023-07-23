using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addculture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "278f43b4-a5b6-455a-b117-c97d9d830ed5");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "666e911d-0be2-4989-9fe0-7d597083ca34");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "a378e05f-036f-4a7d-83d7-4fb6d53d5731");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "61c1973f-7de3-44ba-a4aa-c97fe3cfce61");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6b35b4cc-2030-4305-bf4a-6c735b63c4fb");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e5050d7f-d4ae-47f2-83f1-a8f6cea8e1d1");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "48e1be24-0fe7-469c-a215-416c696d14e0");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "9fd984e0-3b4a-474e-a16b-784114bc5872");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "f17c2da4-9269-4ef6-8c4f-9f77b98beb30");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "168c2aa7-c4eb-411b-b43a-4b7180a39cbe");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "1e8d57b3-14f7-47da-b315-3e46d195a646");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "2065c13e-29fb-4210-8614-05a2b5f620c4");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "25f1f41d-f43a-4b3f-b14a-c05a173c7e36");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "3d759d66-e47a-40e4-952e-623e43c43508");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "3d7b76f5-bbfd-4386-8581-5ef424044147");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "4832cde4-976b-4db9-be93-505dd4956e4d");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "4a67a250-bfce-46a7-b856-faec98e9127e");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "68c5799b-145c-4192-93a4-f25717f57568");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "7954d844-8d2c-4c38-b6a9-05a7316cd3a5");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "b954ec0c-15b4-43d1-b5bc-e5be8448b025");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "badd082a-90e2-4141-a195-1e9823139dcd");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "bb836b87-2f7b-43f3-9ecc-b6cb44e76df1");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "bda03c23-76ef-45fe-9ca7-144942f599f3");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "fb23c6ba-7e4b-4008-acb0-0093bffd0b6e");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "40129229-3253-4f73-aedc-840de63060d8");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "730d7a76-d4e3-4c7f-803f-d7bef0421d17");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "c627abcf-17be-41e5-82d1-0bc29223849c");

            migrationBuilder.AddColumn<string>(
                name: "Culture",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Culture", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "12f8c336-d186-4d49-a3dc-22ccc716b534", "ru-RU", new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7212), false, "Russia", null, null },
                    { "4aadcde3-02f0-41ec-9ed4-69730d877d17", "en-US", new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7386), false, "English", null, null },
                    { "791779f3-b06b-495a-b5cf-e0307d0d27d0", "ar-SA", new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7347), false, "Arabic", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "6e6e7dc4-5d77-479d-8f89-fc90bdd51698", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "ae6c9850-8dc5-4a97-8bd9-714c31d5cec9", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "c2ca735a-d41b-4265-b5b1-e5ead554a24e", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "Description", "Image", "InsertTime", "IsRemoved", "LanguageId", "MetaTag", "RemoveTime", "Title", "UpdateTime", "Video" },
                values: new object[,]
                {
                    { "121c0cb4-e9a9-4359-86bb-bb703edbc476", null, null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(8640), false, "4aadcde3-02f0-41ec-9ed4-69730d877d17", null, null, null, null, null },
                    { "762cb37b-20e1-484d-bc70-de6a91d6dc89", null, null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(8438), false, "12f8c336-d186-4d49-a3dc-22ccc716b534", null, null, null, null, null },
                    { "f987eee0-4ff7-4f8d-a372-5e1750a8c9ab", null, null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(8511), false, "791779f3-b06b-495a-b5cf-e0307d0d27d0", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "BaseUrl", "Description", "Icon", "InsertTime", "IsRemoved", "LanguageId", "Logo", "Logo2", "Menu", "MetaTags", "RemoveTime", "ShowPerPage", "SiteName", "UpdateTime" },
                values: new object[,]
                {
                    { "c24c0f71-f025-4123-b489-b41cdbe77da4", null, null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7461), false, "791779f3-b06b-495a-b5cf-e0307d0d27d0", null, null, null, null, null, 12, null, null },
                    { "f6b5e9bd-ea10-4ccc-bb05-ba3cae7b1f9e", null, null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7508), false, "4aadcde3-02f0-41ec-9ed4-69730d877d17", null, null, null, null, null, 12, null, null },
                    { "ff71dc79-dbd2-4f0f-8aa6-bdacdebb0927", null, null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7425), false, "12f8c336-d186-4d49-a3dc-22ccc716b534", null, null, null, null, null, 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "SiteContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "05a16f04-9791-4936-ae3e-6d24543bf86a", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7875), false, "791779f3-b06b-495a-b5cf-e0307d0d27d0", null, "هاتف", null, "هاتف" },
                    { "07ddafe7-8147-4ca1-83d2-0b7d7194881e", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(8359), false, "4aadcde3-02f0-41ec-9ed4-69730d877d17", null, "Social Media", null, "Social Media" },
                    { "1bb96329-16be-4f18-b215-1f08fe11e72a", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7597), false, "12f8c336-d186-4d49-a3dc-22ccc716b534", null, "Телефон", null, "Телефон" },
                    { "3dae7ef2-4d97-4572-96c0-ead647bbdcd2", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7668), false, "12f8c336-d186-4d49-a3dc-22ccc716b534", null, "Адрес", null, "Адрес" },
                    { "475dd385-c47c-4905-9cd2-5bed7021bd92", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7554), false, "12f8c336-d186-4d49-a3dc-22ccc716b534", null, "Мобильный", null, "Мобильный" },
                    { "4834b23d-7ced-431b-bbd5-e0d514df72eb", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7914), false, "791779f3-b06b-495a-b5cf-e0307d0d27d0", null, "بريد إلكتروني", null, "بريد إلكتروني" },
                    { "512d0b68-49e7-4949-99a3-f5f904d22441", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7788), false, "12f8c336-d186-4d49-a3dc-22ccc716b534", null, "Социальные медиа", null, "Социальные медиа" },
                    { "70c6120a-cc9e-4c37-9125-f59ddeca77ae", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7963), false, "791779f3-b06b-495a-b5cf-e0307d0d27d0", null, "عنوان", null, "عنوان" },
                    { "7528c48a-2277-4a8b-bc24-6865fdefea99", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(8189), false, "4aadcde3-02f0-41ec-9ed4-69730d877d17", null, "Phone", null, "Phone" },
                    { "924d19f7-be64-40d1-b4da-03efdaaafb78", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7839), false, "791779f3-b06b-495a-b5cf-e0307d0d27d0", null, "متحرك", null, "متحرك" },
                    { "b424388b-e2ed-4dba-afe7-9b513f12ab65", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(8127), false, "4aadcde3-02f0-41ec-9ed4-69730d877d17", null, "Mobile", null, "Mobile" },
                    { "bd84c4fa-2e4c-4928-882f-ff043b14825b", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(8308), false, "4aadcde3-02f0-41ec-9ed4-69730d877d17", null, "Address", null, "Address" },
                    { "be5d7113-37b3-4e35-8c2f-3d54ff5d0510", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(8250), false, "4aadcde3-02f0-41ec-9ed4-69730d877d17", null, "Email", null, "Email" },
                    { "e9edf163-15b7-4ac8-a7a2-c55476c39a69", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(7633), false, "12f8c336-d186-4d49-a3dc-22ccc716b534", null, "Электронная почта", null, "Электронная почта" },
                    { "eda7a155-ddd8-4c3e-8dee-e17cdd3bfb13", null, null, new DateTime(2023, 7, 23, 17, 42, 48, 526, DateTimeKind.Local).AddTicks(8066), false, "791779f3-b06b-495a-b5cf-e0307d0d27d0", null, "وسائل التواصل الاجتماعي", null, "وسائل التواصل الاجتماعي" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "121c0cb4-e9a9-4359-86bb-bb703edbc476");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "762cb37b-20e1-484d-bc70-de6a91d6dc89");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "f987eee0-4ff7-4f8d-a372-5e1750a8c9ab");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6e6e7dc4-5d77-479d-8f89-fc90bdd51698");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ae6c9850-8dc5-4a97-8bd9-714c31d5cec9");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c2ca735a-d41b-4265-b5b1-e5ead554a24e");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "c24c0f71-f025-4123-b489-b41cdbe77da4");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "f6b5e9bd-ea10-4ccc-bb05-ba3cae7b1f9e");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "ff71dc79-dbd2-4f0f-8aa6-bdacdebb0927");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "05a16f04-9791-4936-ae3e-6d24543bf86a");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "07ddafe7-8147-4ca1-83d2-0b7d7194881e");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "1bb96329-16be-4f18-b215-1f08fe11e72a");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "3dae7ef2-4d97-4572-96c0-ead647bbdcd2");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "475dd385-c47c-4905-9cd2-5bed7021bd92");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "4834b23d-7ced-431b-bbd5-e0d514df72eb");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "512d0b68-49e7-4949-99a3-f5f904d22441");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "70c6120a-cc9e-4c37-9125-f59ddeca77ae");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "7528c48a-2277-4a8b-bc24-6865fdefea99");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "924d19f7-be64-40d1-b4da-03efdaaafb78");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "b424388b-e2ed-4dba-afe7-9b513f12ab65");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "bd84c4fa-2e4c-4928-882f-ff043b14825b");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "be5d7113-37b3-4e35-8c2f-3d54ff5d0510");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "e9edf163-15b7-4ac8-a7a2-c55476c39a69");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "eda7a155-ddd8-4c3e-8dee-e17cdd3bfb13");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "12f8c336-d186-4d49-a3dc-22ccc716b534");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "4aadcde3-02f0-41ec-9ed4-69730d877d17");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "791779f3-b06b-495a-b5cf-e0307d0d27d0");

            migrationBuilder.DropColumn(
                name: "Culture",
                table: "Languages");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "40129229-3253-4f73-aedc-840de63060d8", new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(2833), false, "Arabic", null, null },
                    { "730d7a76-d4e3-4c7f-803f-d7bef0421d17", new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(2746), false, "Russia", null, null },
                    { "c627abcf-17be-41e5-82d1-0bc29223849c", new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(2850), false, "English", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "61c1973f-7de3-44ba-a4aa-c97fe3cfce61", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "6b35b4cc-2030-4305-bf4a-6c735b63c4fb", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "e5050d7f-d4ae-47f2-83f1-a8f6cea8e1d1", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "Description", "Image", "InsertTime", "IsRemoved", "LanguageId", "MetaTag", "RemoveTime", "Title", "UpdateTime", "Video" },
                values: new object[,]
                {
                    { "278f43b4-a5b6-455a-b117-c97d9d830ed5", null, null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3588), false, "c627abcf-17be-41e5-82d1-0bc29223849c", null, null, null, null, null },
                    { "666e911d-0be2-4989-9fe0-7d597083ca34", null, null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3566), false, "40129229-3253-4f73-aedc-840de63060d8", null, null, null, null, null },
                    { "a378e05f-036f-4a7d-83d7-4fb6d53d5731", null, null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3537), false, "730d7a76-d4e3-4c7f-803f-d7bef0421d17", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "BaseUrl", "Description", "Icon", "InsertTime", "IsRemoved", "LanguageId", "Logo", "Logo2", "Menu", "MetaTags", "RemoveTime", "ShowPerPage", "SiteName", "UpdateTime" },
                values: new object[,]
                {
                    { "48e1be24-0fe7-469c-a215-416c696d14e0", null, null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3023), false, "40129229-3253-4f73-aedc-840de63060d8", null, null, null, null, null, 12, null, null },
                    { "9fd984e0-3b4a-474e-a16b-784114bc5872", null, null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(2953), false, "730d7a76-d4e3-4c7f-803f-d7bef0421d17", null, null, null, null, null, 12, null, null },
                    { "f17c2da4-9269-4ef6-8c4f-9f77b98beb30", null, null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3052), false, "c627abcf-17be-41e5-82d1-0bc29223849c", null, null, null, null, null, 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "SiteContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "168c2aa7-c4eb-411b-b43a-4b7180a39cbe", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3275), false, "40129229-3253-4f73-aedc-840de63060d8", null, "هاتف", null, "هاتف" },
                    { "1e8d57b3-14f7-47da-b315-3e46d195a646", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3482), false, "c627abcf-17be-41e5-82d1-0bc29223849c", null, "Address", null, "Address" },
                    { "2065c13e-29fb-4210-8614-05a2b5f620c4", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3152), false, "730d7a76-d4e3-4c7f-803f-d7bef0421d17", null, "Адрес", null, "Адрес" },
                    { "25f1f41d-f43a-4b3f-b14a-c05a173c7e36", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3463), false, "c627abcf-17be-41e5-82d1-0bc29223849c", null, "Email", null, "Email" },
                    { "3d759d66-e47a-40e4-952e-623e43c43508", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3506), false, "c627abcf-17be-41e5-82d1-0bc29223849c", null, "Social Media", null, "Social Media" },
                    { "3d7b76f5-bbfd-4386-8581-5ef424044147", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3198), false, "40129229-3253-4f73-aedc-840de63060d8", null, "متحرك", null, "متحرك" },
                    { "4832cde4-976b-4db9-be93-505dd4956e4d", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3177), false, "730d7a76-d4e3-4c7f-803f-d7bef0421d17", null, "Социальные медиа", null, "Социальные медиа" },
                    { "4a67a250-bfce-46a7-b856-faec98e9127e", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3132), false, "730d7a76-d4e3-4c7f-803f-d7bef0421d17", null, "Электронная почта", null, "Электронная почта" },
                    { "68c5799b-145c-4192-93a4-f25717f57568", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3320), false, "40129229-3253-4f73-aedc-840de63060d8", null, "عنوان", null, "عنوان" },
                    { "7954d844-8d2c-4c38-b6a9-05a7316cd3a5", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3112), false, "730d7a76-d4e3-4c7f-803f-d7bef0421d17", null, "Телефон", null, "Телефон" },
                    { "b954ec0c-15b4-43d1-b5bc-e5be8448b025", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3403), false, "40129229-3253-4f73-aedc-840de63060d8", null, "وسائل التواصل الاجتماعي", null, "وسائل التواصل الاجتماعي" },
                    { "badd082a-90e2-4141-a195-1e9823139dcd", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3299), false, "40129229-3253-4f73-aedc-840de63060d8", null, "بريد إلكتروني", null, "بريد إلكتروني" },
                    { "bb836b87-2f7b-43f3-9ecc-b6cb44e76df1", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3088), false, "730d7a76-d4e3-4c7f-803f-d7bef0421d17", null, "Мобильный", null, "Мобильный" },
                    { "bda03c23-76ef-45fe-9ca7-144942f599f3", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3442), false, "c627abcf-17be-41e5-82d1-0bc29223849c", null, "Phone", null, "Phone" },
                    { "fb23c6ba-7e4b-4008-acb0-0093bffd0b6e", null, null, new DateTime(2023, 7, 23, 13, 32, 6, 223, DateTimeKind.Local).AddTicks(3422), false, "c627abcf-17be-41e5-82d1-0bc29223849c", null, "Mobile", null, "Mobile" }
                });
        }
    }
}
