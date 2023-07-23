using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addmenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "896e9640-8047-4b82-afcc-efeb9a6bca3d");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "8bae89b9-edd7-4771-b622-8d539ad57567");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "d87b981d-50a4-4db7-b57a-d0a2e1feea80");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "101419d3-dac4-4f2e-96c5-ee986d5953ae");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8023b2cf-9729-4999-b462-5c7838883161");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8e9cab92-ac0e-447c-89a0-c3d01087a1b1");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "32bc8b1f-3b31-4848-ab16-9f72632eecab");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "a0c767a3-85b8-485a-a544-4fdd1687ecb8");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "c8872121-2dbf-48c3-a03c-35362ee4158e");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "2598428c-60c5-44ea-9985-9937ff4ef126");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "42aac82f-438a-4c7d-bdde-cfc562ee553c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "4b6df9c9-e2e2-471a-98af-f6e0edc32b6c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "652408a1-a52e-48fa-8bcb-38c5e04b3bca");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "66459abd-d1c8-4479-9a16-9c96b4252f2c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "6dc1d1b2-2825-469c-bd23-c8994de9e78c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "7a1d4cfc-a694-43a0-be41-12c41999188f");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "9dd6c13e-8247-4a99-a21d-fcba62818d1d");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "a858de36-f221-458e-a16a-4de8ad0d6b9d");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "d2bfc7f5-d746-46c2-9678-6a6ed9d75e45");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "d3e7a687-bf71-4963-944c-7e57d1168de3");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "dfc2cd60-6c6a-40a8-8b85-a7277e76ec0f");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "e632bb0c-7029-4a8f-b564-e99fe13ac315");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "ed037ad8-cdb3-4db4-b782-9b2159694f3a");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "f83b8e27-e344-4491-9060-4c50b7c0342c");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "1124368b-7ea3-46fc-9e1c-9e7ed9ea4695");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "31883b63-f188-4570-ab01-fc83bd57a505");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "de73e340-0cf8-44f3-8918-9a850a067125");

            migrationBuilder.AddColumn<string>(
                name: "Menu",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Menu",
                table: "Settings");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "1124368b-7ea3-46fc-9e1c-9e7ed9ea4695", new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5244), false, "Arabic", null, null },
                    { "31883b63-f188-4570-ab01-fc83bd57a505", new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5089), false, "Russia", null, null },
                    { "de73e340-0cf8-44f3-8918-9a850a067125", new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5518), false, "English", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "101419d3-dac4-4f2e-96c5-ee986d5953ae", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "8023b2cf-9729-4999-b462-5c7838883161", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "8e9cab92-ac0e-447c-89a0-c3d01087a1b1", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "Description", "Image", "InsertTime", "IsRemoved", "LanguageId", "MetaTag", "RemoveTime", "Title", "UpdateTime", "Video" },
                values: new object[,]
                {
                    { "896e9640-8047-4b82-afcc-efeb9a6bca3d", null, null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(6230), false, "1124368b-7ea3-46fc-9e1c-9e7ed9ea4695", null, null, null, null, null },
                    { "8bae89b9-edd7-4771-b622-8d539ad57567", null, null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(6249), false, "de73e340-0cf8-44f3-8918-9a850a067125", null, null, null, null, null },
                    { "d87b981d-50a4-4db7-b57a-d0a2e1feea80", null, null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(6206), false, "31883b63-f188-4570-ab01-fc83bd57a505", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "BaseUrl", "Description", "Icon", "InsertTime", "IsRemoved", "LanguageId", "Logo", "Logo2", "MetaTags", "RemoveTime", "ShowPerPage", "SiteName", "UpdateTime" },
                values: new object[,]
                {
                    { "32bc8b1f-3b31-4848-ab16-9f72632eecab", null, null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5562), false, "31883b63-f188-4570-ab01-fc83bd57a505", null, null, null, null, 12, null, null },
                    { "a0c767a3-85b8-485a-a544-4fdd1687ecb8", null, null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5594), false, "1124368b-7ea3-46fc-9e1c-9e7ed9ea4695", null, null, null, null, 12, null, null },
                    { "c8872121-2dbf-48c3-a03c-35362ee4158e", null, null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5620), false, "de73e340-0cf8-44f3-8918-9a850a067125", null, null, null, null, 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "SiteContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "2598428c-60c5-44ea-9985-9937ff4ef126", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(6044), false, "de73e340-0cf8-44f3-8918-9a850a067125", null, "Phone", null, "Phone" },
                    { "42aac82f-438a-4c7d-bdde-cfc562ee553c", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5931), false, "1124368b-7ea3-46fc-9e1c-9e7ed9ea4695", null, "هاتف", null, "هاتف" },
                    { "4b6df9c9-e2e2-471a-98af-f6e0edc32b6c", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5969), false, "1124368b-7ea3-46fc-9e1c-9e7ed9ea4695", null, "عنوان", null, "عنوان" },
                    { "652408a1-a52e-48fa-8bcb-38c5e04b3bca", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5885), false, "31883b63-f188-4570-ab01-fc83bd57a505", null, "Социальные медиа", null, "Социальные медиа" },
                    { "66459abd-d1c8-4479-9a16-9c96b4252f2c", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5652), false, "31883b63-f188-4570-ab01-fc83bd57a505", null, "Мобильный", null, "Мобильный" },
                    { "6dc1d1b2-2825-469c-bd23-c8994de9e78c", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5951), false, "1124368b-7ea3-46fc-9e1c-9e7ed9ea4695", null, "بريد إلكتروني", null, "بريد إلكتروني" },
                    { "7a1d4cfc-a694-43a0-be41-12c41999188f", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(6007), false, "1124368b-7ea3-46fc-9e1c-9e7ed9ea4695", null, "وسائل التواصل الاجتماعي", null, "وسائل التواصل الاجتماعي" },
                    { "9dd6c13e-8247-4a99-a21d-fcba62818d1d", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5856), false, "31883b63-f188-4570-ab01-fc83bd57a505", null, "Адрес", null, "Адрес" },
                    { "a858de36-f221-458e-a16a-4de8ad0d6b9d", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5837), false, "31883b63-f188-4570-ab01-fc83bd57a505", null, "Электронная почта", null, "Электронная почта" },
                    { "d2bfc7f5-d746-46c2-9678-6a6ed9d75e45", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5816), false, "31883b63-f188-4570-ab01-fc83bd57a505", null, "Телефон", null, "Телефон" },
                    { "d3e7a687-bf71-4963-944c-7e57d1168de3", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(6155), false, "de73e340-0cf8-44f3-8918-9a850a067125", null, "Address", null, "Address" },
                    { "dfc2cd60-6c6a-40a8-8b85-a7277e76ec0f", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(6135), false, "de73e340-0cf8-44f3-8918-9a850a067125", null, "Email", null, "Email" },
                    { "e632bb0c-7029-4a8f-b564-e99fe13ac315", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(5908), false, "1124368b-7ea3-46fc-9e1c-9e7ed9ea4695", null, "متحرك", null, "متحرك" },
                    { "ed037ad8-cdb3-4db4-b782-9b2159694f3a", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(6026), false, "de73e340-0cf8-44f3-8918-9a850a067125", null, "Mobile", null, "Mobile" },
                    { "f83b8e27-e344-4491-9060-4c50b7c0342c", null, null, new DateTime(2023, 7, 22, 12, 39, 36, 125, DateTimeKind.Local).AddTicks(6173), false, "de73e340-0cf8-44f3-8918-9a850a067125", null, "Social Media", null, "Social Media" }
                });
        }
    }
}
