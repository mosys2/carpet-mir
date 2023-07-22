using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addpageaboutconcatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "031b169f-71c3-40af-bc3c-742375a1804f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "516eb53c-6fd7-4762-9b3e-7792327e902b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "eefbe13c-4c6a-469f-b28b-62eb725f561a");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "2f357590-108a-44e0-a535-cf65884617cc");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "8455c858-66ab-4143-929f-f00b99019aa7");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "b46e15a3-84b9-4237-a6c5-dbea25e1ba8c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "1e0109e4-e543-45e1-b47e-a573f6ba7a6c");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "2099b8a7-1516-481b-8817-ecb8531e0ed7");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "400890c7-bd86-41c2-8b3c-fd3df5d9d879");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "450fc988-33a2-49d1-a513-e2f5d346dabe");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "4e103ff8-2d77-40b3-8ef0-263825857ac5");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "6eb010f0-a7a5-4dad-a902-8fc1418b9d6a");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "717cc42d-fdf3-4081-8ff0-d70284069fd2");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "8e958c5c-5fd3-466d-9c92-327b7e99f2a0");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "91de683d-595a-4c5a-9b6a-01425d1a36b3");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "a3ab8b6e-434e-4670-82e0-260d6db3a4e0");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "cbb95bd2-4f30-45cc-9b9e-b7d409e7334d");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "d6ee6a02-3670-4acc-8ace-8fb9a499d6ea");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "dd229165-a118-4c62-8fe8-36665f64c2ba");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "ec6dd685-ae46-44cb-a4ff-4296a25e8603");

            migrationBuilder.DeleteData(
                table: "SiteContactTypes",
                keyColumn: "Id",
                keyValue: "f4632b25-964a-4f6b-add3-c2e9f08999ae");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "1e7327e7-afd0-4138-98c6-7f928968cd8d");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "2ccc5d91-1ea0-415e-9c5e-62a14749499b");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "f6af8a1c-d6d4-4130-bf2b-45af434cc9e0");

            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abouts_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seen = table.Column<bool>(type: "bit", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactUs_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PageCreators",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageCreators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageCreators_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_LanguageId",
                table: "Abouts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_LanguageId",
                table: "ContactUs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageCreators_LanguageId",
                table: "PageCreators",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "PageCreators");

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
                    { "1e7327e7-afd0-4138-98c6-7f928968cd8d", new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(1344), false, "Russia", null, null },
                    { "2ccc5d91-1ea0-415e-9c5e-62a14749499b", new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(1621), false, "Arabic", null, null },
                    { "f6af8a1c-d6d4-4130-bf2b-45af434cc9e0", new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(1709), false, "English", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "031b169f-71c3-40af-bc3c-742375a1804f", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "516eb53c-6fd7-4762-9b3e-7792327e902b", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "eefbe13c-4c6a-469f-b28b-62eb725f561a", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "BaseUrl", "Description", "Icon", "InsertTime", "IsRemoved", "LanguageId", "Logo", "Logo2", "MetaTags", "RemoveTime", "ShowPerPage", "SiteName", "UpdateTime" },
                values: new object[,]
                {
                    { "2f357590-108a-44e0-a535-cf65884617cc", null, null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2028), false, "f6af8a1c-d6d4-4130-bf2b-45af434cc9e0", null, null, null, null, 12, null, null },
                    { "8455c858-66ab-4143-929f-f00b99019aa7", null, null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(1793), false, "1e7327e7-afd0-4138-98c6-7f928968cd8d", null, null, null, null, 12, null, null },
                    { "b46e15a3-84b9-4237-a6c5-dbea25e1ba8c", null, null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(1923), false, "2ccc5d91-1ea0-415e-9c5e-62a14749499b", null, null, null, null, 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "SiteContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "LanguageId", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "1e0109e4-e543-45e1-b47e-a573f6ba7a6c", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2225), false, "1e7327e7-afd0-4138-98c6-7f928968cd8d", null, "Телефон", null, "Телефон" },
                    { "2099b8a7-1516-481b-8817-ecb8531e0ed7", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2626), false, "2ccc5d91-1ea0-415e-9c5e-62a14749499b", null, "بريد إلكتروني", null, "بريد إلكتروني" },
                    { "400890c7-bd86-41c2-8b3c-fd3df5d9d879", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2407), false, "1e7327e7-afd0-4138-98c6-7f928968cd8d", null, "Адрес", null, "Адрес" },
                    { "450fc988-33a2-49d1-a513-e2f5d346dabe", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(3357), false, "f6af8a1c-d6d4-4130-bf2b-45af434cc9e0", null, "Address", null, "Address" },
                    { "4e103ff8-2d77-40b3-8ef0-263825857ac5", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2126), false, "1e7327e7-afd0-4138-98c6-7f928968cd8d", null, "Мобильный", null, "Мобильный" },
                    { "6eb010f0-a7a5-4dad-a902-8fc1418b9d6a", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2742), false, "2ccc5d91-1ea0-415e-9c5e-62a14749499b", null, "عنوان", null, "عنوان" },
                    { "717cc42d-fdf3-4081-8ff0-d70284069fd2", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2598), false, "2ccc5d91-1ea0-415e-9c5e-62a14749499b", null, "هاتف", null, "هاتف" },
                    { "8e958c5c-5fd3-466d-9c92-327b7e99f2a0", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2984), false, "f6af8a1c-d6d4-4130-bf2b-45af434cc9e0", null, "Mobile", null, "Mobile" },
                    { "91de683d-595a-4c5a-9b6a-01425d1a36b3", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2503), false, "1e7327e7-afd0-4138-98c6-7f928968cd8d", null, "Социальные медиа", null, "Социальные медиа" },
                    { "a3ab8b6e-434e-4670-82e0-260d6db3a4e0", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(3454), false, "f6af8a1c-d6d4-4130-bf2b-45af434cc9e0", null, "Social Media", null, "Social Media" },
                    { "cbb95bd2-4f30-45cc-9b9e-b7d409e7334d", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(3075), false, "f6af8a1c-d6d4-4130-bf2b-45af434cc9e0", null, "Phone", null, "Phone" },
                    { "d6ee6a02-3670-4acc-8ace-8fb9a499d6ea", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2320), false, "1e7327e7-afd0-4138-98c6-7f928968cd8d", null, "Электронная почта", null, "Электронная почта" },
                    { "dd229165-a118-4c62-8fe8-36665f64c2ba", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2566), false, "2ccc5d91-1ea0-415e-9c5e-62a14749499b", null, "متحرك", null, "متحرك" },
                    { "ec6dd685-ae46-44cb-a4ff-4296a25e8603", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(2882), false, "2ccc5d91-1ea0-415e-9c5e-62a14749499b", null, "وسائل التواصل الاجتماعي", null, "وسائل التواصل الاجتماعي" },
                    { "f4632b25-964a-4f6b-add3-c2e9f08999ae", null, null, new DateTime(2023, 7, 20, 16, 59, 44, 846, DateTimeKind.Local).AddTicks(3168), false, "f6af8a1c-d6d4-4130-bf2b-45af434cc9e0", null, "Email", null, "Email" }
                });
        }
    }
}
