using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedDocumentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "1a7b0cc0-3fc8-453e-ace7-adbc6ac53713");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "400da6d2-34c0-4702-8bd0-89601f16ed75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "272aa99a-f9d4-4010-8e90-e36500895f0b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "f0dfbde5-fea2-43f3-8b38-d559fa4eea2c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "ee6e2d29-1220-4893-8e22-df4f4062f7af", "AQAAAAEAACcQAAAAEI90QdimyKR+AJMEDG0zPqvL7gNEx7x0c7c91y5be7IgHGvhPVlkOJgBoeVdpYsT8Q==", new DateTime(2023, 10, 26, 19, 8, 11, 864, DateTimeKind.Utc).AddTicks(2433), "9956f464-e4da-43b6-a8c0-603479cfcdfc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2b31ae81-54a8-4091-a0ba-4b84ca678f31", "AQAAAAEAACcQAAAAEFj/CSk+GZ2iXmNjCyWLnw6D9Fyvn/EE6NV9HFVwFXcaQIq/iOIfhrb0k06JYD6GYg==", new DateTime(2023, 10, 26, 19, 8, 11, 867, DateTimeKind.Utc).AddTicks(6658), "6e4e6701-fa42-4f13-b125-106d3c47d4fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2afc433c-5abe-46f7-90b6-ce3bc3469612", "AQAAAAEAACcQAAAAEEnQ8QrfycY5pg7iTq6hbQ8t5uJfVZh7aj8nB6M0TZco1ioUq5CdwlXUYJXaxMw4Lw==", new DateTime(2023, 10, 26, 19, 8, 11, 865, DateTimeKind.Utc).AddTicks(4392), "8fa4c6c3-c7d1-47d9-b612-cd0f1fc27f02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "fcd8ae50-bbb6-4f2f-aab8-9e625f600ff6", "AQAAAAEAACcQAAAAEPrNufsaB7oYNgbP0L+pyutdO4dZ85sRrS+tad4aUKeVHZ+FfIUwxnl4+X+mmzTJLA==", new DateTime(2023, 10, 26, 19, 8, 11, 866, DateTimeKind.Utc).AddTicks(5683), "704300a8-05f6-4daa-a057-389ad78461fc" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_StudentId",
                table: "Documents",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "d9ff2999-bd07-431e-9e9f-9ae288dd1396");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "0772ea50-7a57-444f-b4e1-b7a1d92dcd31");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "6589ce6d-6912-4321-a0a3-c35235f27477");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "e57542f3-d6f8-443b-93e5-ec35b459865f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "0835a095-3393-4303-a17c-a3a0ee4a18e7", "AQAAAAEAACcQAAAAEGlPEnQNUr6kKvIdKhJCSGWj7il+T0FTgKHF3gMJFm/dLfIB+o5P0bODi9xMJbW31w==", new DateTime(2023, 10, 25, 6, 29, 59, 126, DateTimeKind.Utc).AddTicks(9859), "9782a160-fc14-472e-a572-10c798de964c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "035b6df4-9e42-4c3d-bbad-d619d47e68d5", "AQAAAAEAACcQAAAAEL55FmIAisb6oiogZk1E/ZTV9fQIk0jbcAcM3jbnjz8g8DHbwMPrpwrI2hEbQ/KwHQ==", new DateTime(2023, 10, 25, 6, 29, 59, 132, DateTimeKind.Utc).AddTicks(5415), "e573cae7-c961-4585-b45f-ad6d8d45e508" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "0bc18386-f366-4f21-9ea8-8c2e229be574", "AQAAAAEAACcQAAAAEOJogF/ZCP/tmcTgK8Gc8GxGT/Z6C68pM48AJle80mLOD/VHLshvS9SpfT368+3RFA==", new DateTime(2023, 10, 25, 6, 29, 59, 128, DateTimeKind.Utc).AddTicks(8448), "0299dbda-78b2-4895-b780-8b411be81cc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "91c7bf57-eb4a-48ab-a9ce-063d6fb938dd", "AQAAAAEAACcQAAAAEMlG5f1yMYoDyV6LnMoYyvrU5Kf7HLMb8EIGinuTWABWlKEKTNjpQiQtGkcomD0yQQ==", new DateTime(2023, 10, 25, 6, 29, 59, 130, DateTimeKind.Utc).AddTicks(6691), "93612f70-f346-469e-8c9b-177b360cb7bd" });
        }
    }
}
