using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class FixedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Companies_CompanyId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_CompanyId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Classes");

            migrationBuilder.AlterColumn<string>(
                name: "ClassId",
                table: "Meetings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CompanyInternsId",
                table: "Meetings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "7b7a0dcf-a843-4798-aa95-8c3d81d3c337");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "6b12fb2a-25bd-4086-9a34-35194351f304");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "96a9c76e-3088-4b24-bdc7-9b7a85ee159b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "5170f598-e230-4148-80ad-0e0b83aa322b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "6a74ab6c-e8b2-4ba1-835f-69f482322b8e", "AQAAAAEAACcQAAAAENkEpuBUIslRCI7lUgvGg4kbK6kkpbWjHaf1of5rMvM6zrd94AKJFF0cTrhjdQCEtA==", new DateTime(2024, 3, 28, 12, 11, 13, 747, DateTimeKind.Utc).AddTicks(2643), "a0e04772-e451-47ba-b37b-167e8b12b2ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "05191931-a7c3-465c-8e08-56bedcdde381", "AQAAAAEAACcQAAAAEGc9xsV5Q9GHNjvamyjvfKSumFlHtrgpK5iVHw3Ap280i7Nc4dV5VBtYIjiCxxLSwg==", new DateTime(2024, 3, 28, 12, 11, 13, 758, DateTimeKind.Utc).AddTicks(6041), "e543409c-ae99-419f-a7a9-41be30f95d34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "e389514b-7c62-4b44-b690-5f942a5dbad8", "AQAAAAEAACcQAAAAEHDhtQk6oIF2eBFHWWS1BkbhbMjHl5sNAq70KFTrY0mfjLum17eGhfN7cOC5hWQnZw==", new DateTime(2024, 3, 28, 12, 11, 13, 753, DateTimeKind.Utc).AddTicks(5525), "fbc3c3bc-8b10-4106-addd-b0c177c3a1c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c17e9cc4-9869-437b-b546-29ec1206a806", "AQAAAAEAACcQAAAAEHQmbF5KeRpXAxmby/hcqQnZQRnR7YMll3sDeH3RkhQm1vX30AO5w8FvPW4Gvjvi6w==", new DateTime(2024, 3, 28, 12, 11, 13, 755, DateTimeKind.Utc).AddTicks(9096), "a04084e0-6468-4038-883e-00bde9d59e79" });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_CompanyInternsId",
                table: "Meetings",
                column: "CompanyInternsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_CompanyInterns_CompanyInternsId",
                table: "Meetings",
                column: "CompanyInternsId",
                principalTable: "CompanyInterns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_CompanyInterns_CompanyInternsId",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_CompanyInternsId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "CompanyInternsId",
                table: "Meetings");

            migrationBuilder.AlterColumn<string>(
                name: "ClassId",
                table: "Meetings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Classes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "264216d1-7d0a-4dab-ad6f-ba7e351a3f0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "3afe8a1b-b965-47fb-be68-0886d615c257");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "88975b10-0392-44b8-837c-8d6e77d8ae99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "648b0ad8-fc74-4a43-a361-4911f43290d5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "4ecad5e9-5841-4966-8ef3-0e1eb4e71905", "AQAAAAEAACcQAAAAEJ55W/V1qvKfKa6ymhol9CCixnwy4cwWyoCi/nI7a3JJlbxZeEYro9d25hvyRxI7fg==", new DateTime(2024, 3, 28, 7, 29, 45, 790, DateTimeKind.Utc).AddTicks(1737), "dbf10fd7-24d2-4c93-9fdb-d967f65d971d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "8b9438d8-23f1-4a7d-9aa0-fd2682fc6089", "AQAAAAEAACcQAAAAEFEkKiuAdGVChJctmGrgR1ym7bZjpTEnHwR7oAYGJK18cGq0WDmxBDgk+8oiGY7AbA==", new DateTime(2024, 3, 28, 7, 29, 45, 795, DateTimeKind.Utc).AddTicks(4003), "e90234ee-7d52-429d-a6d3-77c1a015c1e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "a03408d4-0a06-464b-b233-5703f375d408", "AQAAAAEAACcQAAAAECZBB+rsk9u0GILLqG/ujlAjDuV73VUBuA9jQkLgvVWcZ6/xANNvNJwkZADrYI698w==", new DateTime(2024, 3, 28, 7, 29, 45, 793, DateTimeKind.Utc).AddTicks(2815), "ed9504bf-538c-43ea-8a92-cd7638d05bbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "b739b4e8-7432-42ad-8ef3-e7fc554acad2", "AQAAAAEAACcQAAAAEHBqN754vb7ZpNgL149bSVquXYPyZbRK5pEZdW1UN0Z4Fx3JpZu+9WcSrXTX/FxNdg==", new DateTime(2024, 3, 28, 7, 29, 45, 794, DateTimeKind.Utc).AddTicks(3685), "386a97ad-5492-47c3-86c0-960be142e528" });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CompanyId",
                table: "Classes",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Companies_CompanyId",
                table: "Classes",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
