using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedEntityToDbContest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Post_PostId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Companies_CompanyId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsPhotos_Photo_PhotoId",
                table: "PostsPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsPhotos_Post_PostId",
                table: "PostsPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostsPhotos",
                table: "PostsPhotos");

            migrationBuilder.DropIndex(
                name: "IX_PostsPhotos_PostId",
                table: "PostsPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_PostId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostsPhotos");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Photo");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "Photos");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CompanyId",
                table: "Posts",
                newName: "IX_Posts_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "Posts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostsPhotos",
                table: "PostsPhotos",
                columns: new[] { "PostId", "PhotoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "64065d84-8198-44f5-9488-c002b0ba7f8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "3137cb4a-69cb-4677-acf9-210518ad8d0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "87299b4d-30c8-46d1-8ebf-b8131de8c75b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "ff1dfc81-4293-405c-bd0c-1a18db032354");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c9c79103-84fa-40cf-a203-5399b8626e0b", "AQAAAAEAACcQAAAAEObOtOuIHiCgpb04mGpe11QqoOCblngyXrTAjtr2rl7e6FmXS8gRdhFW/nFUh+qIbw==", new DateTime(2024, 4, 17, 17, 37, 7, 82, DateTimeKind.Utc).AddTicks(7141), "388bf420-ff99-4882-8277-ba8efe405f12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "09df3dd2-82c0-4eb0-b454-184d23869835", "AQAAAAEAACcQAAAAEGyV+r8SqdwCIaFklKzIEhOhrTfK84QF4hXZxCVP7SN3TfJ60N/XCgKnSs5hvFGMYA==", new DateTime(2024, 4, 17, 17, 37, 7, 90, DateTimeKind.Utc).AddTicks(3683), "7f720843-d640-4786-91c7-f806086792fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3d1a694d-f6f2-4dcd-a389-2e402efa8a81", "AQAAAAEAACcQAAAAEK+lmVvhmK3Hf71qNHrXduIGgVpaek/0Zncvt6uIHjcPZjvIC3qlfcotHA7rrIPsEA==", new DateTime(2024, 4, 17, 17, 37, 7, 87, DateTimeKind.Utc).AddTicks(103), "d1066fc2-1579-49a9-8566-442430c90950" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "722aa9ac-f6ab-4ba7-a413-c3f3fb8024b6", "AQAAAAEAACcQAAAAEJLYKgAUNvsB10LUMLjP22erw7Hi5M7U6XZEr5BSuwSAi2xQcYiiHRyoVTSs45BhjA==", new DateTime(2024, 4, 17, 17, 37, 7, 89, DateTimeKind.Utc).AddTicks(626), "7bdf3676-9350-4665-a3c3-0b1f73430fec" });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Companies_CompanyId",
                table: "Posts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostsPhotos_Photos_PhotoId",
                table: "PostsPhotos",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostsPhotos_Posts_PostId",
                table: "PostsPhotos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Companies_CompanyId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsPhotos_Photos_PhotoId",
                table: "PostsPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsPhotos_Posts_PostId",
                table: "PostsPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostsPhotos",
                table: "PostsPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "Photo");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CompanyId",
                table: "Post",
                newName: "IX_Post_CompanyId");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "PostsPhotos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "PostId",
                table: "Photo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostsPhotos",
                table: "PostsPhotos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "Id");

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
                name: "IX_PostsPhotos_PostId",
                table: "PostsPhotos",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PostId",
                table: "Photo",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Post_PostId",
                table: "Photo",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Companies_CompanyId",
                table: "Post",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostsPhotos_Photo_PhotoId",
                table: "PostsPhotos",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostsPhotos_Post_PostId",
                table: "PostsPhotos",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
