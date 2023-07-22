using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class editpage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "530bd333-7218-4eb0-b8f2-0dde63c8c8fd");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "6ecf4aba-fcf1-4b5a-94e6-1c698ae1f70d");

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: "8fc27dc0-43a2-4e0d-ac34-1347c13e28df");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0337f3df-2fea-45f3-a217-1cd28a5c237c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6a20fc88-22ec-49e8-bf82-e0acdec79099");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d3301b2c-fb4c-42d7-8a49-794a447d87c7");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "007ed270-86d6-4939-8839-d45ab5dc1923");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "22cf99e7-5fec-42c7-86b3-bdfb660fecc5");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "b6c274c6-54e4-4050-bb16-0efb98baf897");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "0f2d0961-12a7-4b59-8d63-95d6c8ac3774");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "27159095-b598-444d-97d7-06ba038f2068");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "4b5463cf-9082-444b-bc7f-fb12782b931f");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "4e623f60-d2f3-4e97-84fa-b5457b016c3a");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "5431493a-657b-434a-b066-5a46449e34f1");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "6221f3b6-fdad-4486-89d5-62d4c2f8d365");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "7ad4f41f-9c4f-42ac-bbca-fa37d29f194b");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "7ec50361-12f2-4025-81f6-b3c162e75325");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "99b2a14d-1444-4988-b9e3-3c50fe385b0c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "b44ace4c-b363-4863-b09c-14ccdbd4bb08");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "bf4e6130-1c2d-4aa9-8fa3-f3825bf65cc6");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "cb259d72-29b0-47ec-8478-5a1ebcbfd663");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "d742359e-0221-4500-94aa-ea0f56991995");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "e23c70be-dbad-4eab-aadb-82d2f761f7b3");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "e5654680-354a-4079-8d3d-8286c1cd1024");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "280214c0-28fc-4b29-bc48-48f5806a244f");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "3442f491-a06b-4b52-bb0c-2b88d80c1673");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "fc4595e5-c48e-49e4-a743-30bda9e4c545");

            migrationBuilder.RenameColumn(
                name: "MetaTag",
                table: "PageCreators",
                newName: "Slug");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PageCreators",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MetaTagDescription",
                table: "PageCreators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTagKeyWords",
                table: "PageCreators",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PageCreators");

            migrationBuilder.DropColumn(
                name: "MetaTagDescription",
                table: "PageCreators");

            migrationBuilder.DropColumn(
                name: "MetaTagKeyWords",
                table: "PageCreators");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "PageCreators",
                newName: "MetaTag");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "280214c0-28fc-4b29-bc48-48f5806a244f", new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4176), false, "Arabic", null, null },
                    { "3442f491-a06b-4b52-bb0c-2b88d80c1673", new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4034), false, "Russia", null, null },
                    { "fc4595e5-c48e-49e4-a743-30bda9e4c545", new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4205), false, "English", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "0337f3df-2fea-45f3-a217-1cd28a5c237c", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "6a20fc88-22ec-49e8-bf82-e0acdec79099", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "d3301b2c-fb4c-42d7-8a49-794a447d87c7", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "Description", "Image", "InsertTime", "IsRemoved", "LanguageId", "MetaTag", "RemoveTime", "Title", "UpdateTime", "Video" },
                values: new object[,]
                {
                    { "530bd333-7218-4eb0-b8f2-0dde63c8c8fd", null, null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4991), false, "3442f491-a06b-4b52-bb0c-2b88d80c1673", null, null, null, null, null },
                    { "6ecf4aba-fcf1-4b5a-94e6-1c698ae1f70d", null, null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(5032), false, "280214c0-28fc-4b29-bc48-48f5806a244f", null, null, null, null, null },
                    { "8fc27dc0-43a2-4e0d-ac34-1347c13e28df", null, null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(5060), false, "fc4595e5-c48e-49e4-a743-30bda9e4c545", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "BaseUrl", "Description", "Icon", "InsertTime", "IsRemoved", "LanguageId", "Logo", "Logo2", "MetaTags", "RemoveTime", "ShowPerPage", "SiteName", "UpdateTime" },
                values: new object[,]
                {
                    { "007ed270-86d6-4939-8839-d45ab5dc1923", null, null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4283), false, "280214c0-28fc-4b29-bc48-48f5806a244f", null, null, null, null, 12, null, null },
                    { "22cf99e7-5fec-42c7-86b3-bdfb660fecc5", null, null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4237), false, "3442f491-a06b-4b52-bb0c-2b88d80c1673", null, null, null, null, 12, null, null },
                    { "b6c274c6-54e4-4050-bb16-0efb98baf897", null, null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4316), false, "fc4595e5-c48e-49e4-a743-30bda9e4c545", null, null, null, null, 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "SiteContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "0f2d0961-12a7-4b59-8d63-95d6c8ac3774", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4828), false, "fc4595e5-c48e-49e4-a743-30bda9e4c545", null, "Mobile", null, "Mobile" },
                    { "27159095-b598-444d-97d7-06ba038f2068", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4943), false, "fc4595e5-c48e-49e4-a743-30bda9e4c545", null, "Social Media", null, "Social Media" },
                    { "4b5463cf-9082-444b-bc7f-fb12782b931f", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4735), false, "280214c0-28fc-4b29-bc48-48f5806a244f", null, "عنوان", null, "عنوان" },
                    { "4e623f60-d2f3-4e97-84fa-b5457b016c3a", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4798), false, "280214c0-28fc-4b29-bc48-48f5806a244f", null, "وسائل التواصل الاجتماعي", null, "وسائل التواصل الاجتماعي" },
                    { "5431493a-657b-434a-b066-5a46449e34f1", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4460), false, "3442f491-a06b-4b52-bb0c-2b88d80c1673", null, "Адрес", null, "Адрес" },
                    { "6221f3b6-fdad-4486-89d5-62d4c2f8d365", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4852), false, "fc4595e5-c48e-49e4-a743-30bda9e4c545", null, "Phone", null, "Phone" },
                    { "7ad4f41f-9c4f-42ac-bbca-fa37d29f194b", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4493), false, "3442f491-a06b-4b52-bb0c-2b88d80c1673", null, "Социальные медиа", null, "Социальные медиа" },
                    { "7ec50361-12f2-4025-81f6-b3c162e75325", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4369), false, "3442f491-a06b-4b52-bb0c-2b88d80c1673", null, "Мобильный", null, "Мобильный" },
                    { "99b2a14d-1444-4988-b9e3-3c50fe385b0c", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4432), false, "3442f491-a06b-4b52-bb0c-2b88d80c1673", null, "Электронная почта", null, "Электронная почта" },
                    { "b44ace4c-b363-4863-b09c-14ccdbd4bb08", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4530), false, "280214c0-28fc-4b29-bc48-48f5806a244f", null, "متحرك", null, "متحرك" },
                    { "bf4e6130-1c2d-4aa9-8fa3-f3825bf65cc6", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4909), false, "fc4595e5-c48e-49e4-a743-30bda9e4c545", null, "Address", null, "Address" },
                    { "cb259d72-29b0-47ec-8478-5a1ebcbfd663", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4403), false, "3442f491-a06b-4b52-bb0c-2b88d80c1673", null, "Телефон", null, "Телефон" },
                    { "d742359e-0221-4500-94aa-ea0f56991995", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4601), false, "280214c0-28fc-4b29-bc48-48f5806a244f", null, "بريد إلكتروني", null, "بريد إلكتروني" },
                    { "e23c70be-dbad-4eab-aadb-82d2f761f7b3", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4880), false, "fc4595e5-c48e-49e4-a743-30bda9e4c545", null, "Email", null, "Email" },
                    { "e5654680-354a-4079-8d3d-8286c1cd1024", null, null, new DateTime(2023, 7, 20, 18, 15, 46, 89, DateTimeKind.Local).AddTicks(4573), false, "280214c0-28fc-4b29-bc48-48f5806a244f", null, "هاتف", null, "هاتف" }
                });
        }
    }
}
