using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class NewRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInterns_Companies_CompanyId",
                table: "CompanyInterns");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInterns_Teachers_TeacherId",
                table: "CompanyInterns");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInterns_Companies_CompanyId",
                table: "CompanyInterns",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInterns_Teachers_TeacherId",
                table: "CompanyInterns",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInterns_Companies_CompanyId",
                table: "CompanyInterns");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInterns_Teachers_TeacherId",
                table: "CompanyInterns");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "bc4f4fca-7384-4a14-9425-38d9cd31d754");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "3d16f6a8-15c3-4480-bdcf-7d658e1deb0b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "99967a0f-e0d1-4728-8830-50920561cd0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "9820a525-e63a-404e-be7e-d0316e0921df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "794507d1-bc41-4a46-8fc6-a566ea7796c4", "AQAAAAEAACcQAAAAECBhMV5GcpUjWTs3OW3rGkkJR6bKfmMGbC/diDO+FCMGfj1jAbtDeZJZ1tRfLIC7Uw==", new DateTime(2024, 3, 28, 7, 18, 33, 543, DateTimeKind.Utc).AddTicks(7295), "3ae7b34c-334e-4072-9cd1-bd560edecc7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c9d3c7e5-408f-4b71-9aa2-9d05737c6b64", "AQAAAAEAACcQAAAAEAa3M3fYyP0gco2onWM5hF3X8n5Weisi4W9qlS3a2+oOvZd9GjQUmWb/tszzgprEJQ==", new DateTime(2024, 3, 28, 7, 18, 33, 549, DateTimeKind.Utc).AddTicks(3807), "ad5df29c-646a-41a8-90d8-cbb275bbc397" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "fe68397a-d92d-49e8-a457-406a1c5e6b31", "AQAAAAEAACcQAAAAELLCYP2T+Q9v4xFDas6PY1WKV5KPnBei13KGjUkFEG8uTXSfjvMfciSiYSwVgLa2iQ==", new DateTime(2024, 3, 28, 7, 18, 33, 547, DateTimeKind.Utc).AddTicks(3189), "6f3ed6c0-db81-45a6-a929-2b644530c9b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "5c44ece1-6ec2-404f-b1bf-059c14bc9c1e", "AQAAAAEAACcQAAAAEEeK3C6ZD88SeE0WTjFvm8XT5fnK1i5znWBTkS/Vo42U47obsgc2omesKadd9Wvc9g==", new DateTime(2024, 3, 28, 7, 18, 33, 548, DateTimeKind.Utc).AddTicks(3644), "da408f8e-1be2-4b0b-9c4d-049213623f3a" });

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInterns_Companies_CompanyId",
                table: "CompanyInterns",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInterns_Teachers_TeacherId",
                table: "CompanyInterns",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
