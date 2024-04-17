using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedPostsForBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostsPhotos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhotoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostsPhotos_Photo_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsPhotos_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "20790560-48bc-4466-8744-fa4fecab2ae5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "828f47b4-ec38-4a2a-a415-da5afdc682bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "75eb8de9-ae08-4e03-bb91-2b33a151203b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "ddcba63a-d67f-4227-9766-a2faed2d3350");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "8fd05d51-a8af-434f-a47c-93e8d5d92b93", "AQAAAAEAACcQAAAAED48cGktrlNAlJtRKNpsBy+IR1hXH/sgN0MB/ViHIsB/NABJLMkPSSGApE8syd1HlA==", new DateTime(2024, 4, 17, 17, 15, 53, 339, DateTimeKind.Utc).AddTicks(6021), "332904c3-4884-4ab3-98ad-cdb9e272db45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "6044c60b-4310-4461-b39d-0d4b73fc643d", "AQAAAAEAACcQAAAAEO/jV10vYAIYnTsRqhDewxreR2n5kcpnK/ZKSobc7arhuroRufdRygTfvQ4e8fpKsw==", new DateTime(2024, 4, 17, 17, 15, 53, 375, DateTimeKind.Utc).AddTicks(9701), "acf711aa-d3ad-4893-889e-ef25e5300fc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "aff158e3-ca0b-4e6a-80cf-b52520906302", "AQAAAAEAACcQAAAAEIQaHCHKYI+zvVIr0vfuo25ZR2rfBQrvxw4AoMbM05cNJtStX/marXevCpBnBK6qXA==", new DateTime(2024, 4, 17, 17, 15, 53, 369, DateTimeKind.Utc).AddTicks(7715), "038e0d9e-2386-45e7-9ab6-72624e72fd8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "ccb37de8-9deb-4bbe-81ea-afba979db471", "AQAAAAEAACcQAAAAEPXydXR4d8dAm+LJPsju226TOEih4e9ssAhVuJSEejZFlQ9fZox6UYP+fYJQyjyQ4A==", new DateTime(2024, 4, 17, 17, 15, 53, 372, DateTimeKind.Utc).AddTicks(6893), "2b489be3-a402-458a-a1e2-6cc5e9483231" });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PostId",
                table: "Photo",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CompanyId",
                table: "Post",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsPhotos_PhotoId",
                table: "PostsPhotos",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsPhotos_PostId",
                table: "PostsPhotos",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostsPhotos");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "45319787-3e6a-4619-bb13-1d2f3a564cc2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "d780913e-3dc8-4c69-80a8-739cac8c924a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "322ab861-ba3f-4b35-8bef-ae4edb5bbe45");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "8630643c-b020-4b53-97bb-df2f085c2fb3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "0bdc7cf1-8041-484a-a49f-6ea521825e58", "AQAAAAEAACcQAAAAECszZJdVF7Co/fj5nWorDm/UU7sRJEOLjpCde2XSREMtCdlSycTmbXgQTMQOih5j7A==", new DateTime(2024, 4, 12, 17, 4, 6, 769, DateTimeKind.Utc).AddTicks(3890), "d9e67086-5fbc-4f4e-85a7-5023861af10e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "9d28b577-ed6c-4951-833c-aec339918ab8", "AQAAAAEAACcQAAAAEKhbPhtFIY7IoEHNWwh1fb+JeFBYks6Vb/yOM1UaWTmHD7hyf+xfkgwmkdIx4N4OmA==", new DateTime(2024, 4, 12, 17, 4, 6, 775, DateTimeKind.Utc).AddTicks(9385), "0170008c-985a-4e4c-83e2-9cbed838ee0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2ac920de-6d93-44fa-a1b8-f360caacf4fd", "AQAAAAEAACcQAAAAEMDR70YEoqDZh7b8ra0EubK2bA4qf4LpKgEgBopenC4iBYXUXtOmp6hGFtPnzkGFkA==", new DateTime(2024, 4, 12, 17, 4, 6, 773, DateTimeKind.Utc).AddTicks(8074), "8c0769f9-cbf1-4748-adc6-50e855742e26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "5c38e272-9f94-44a8-a612-073632ba2d93", "AQAAAAEAACcQAAAAEPAvRHIHQVpbd/eNyx46HnupbSQc35ddYwOVsihWECsUcQ1f/Uw5uSIO/NBmbBRfyw==", new DateTime(2024, 4, 12, 17, 4, 6, 774, DateTimeKind.Utc).AddTicks(9118), "945850fb-a2bf-4002-b788-f9dc5fe8bd92" });
        }
    }
}
