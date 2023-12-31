using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedLectorsToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lectors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectors_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "20ec695e-50af-447b-844f-68dcb80ae42b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "d2ff790a-4824-4786-a69f-7017c296389a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "e3a888aa-8672-45a2-b1c2-2f7ab75a4a47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "c2bb937c-78ef-464e-9410-487bbd49075b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "ac6b1bcf-2386-4509-a3a8-e4387fd5d02a", "AQAAAAEAACcQAAAAEGFoOC4tnOYaEwED8BcRW29eXv/9pgPUp+f0PbYqLBQtGKiP/l6tMHA6dX1mSDlMnQ==", new DateTime(2023, 12, 31, 10, 12, 46, 566, DateTimeKind.Utc).AddTicks(4627), "78a56c8e-9771-429d-a354-d6e755c31904" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "be10f2fe-9b3a-4d3f-89f6-8106cdd46ee6", "AQAAAAEAACcQAAAAEDw/51D0p5UkB5J1o29I6UWj19lKfwdg+c3TM+tX3n4SM+FpCZcE3s5/ygAS+BKU0Q==", new DateTime(2023, 12, 31, 10, 12, 46, 570, DateTimeKind.Utc).AddTicks(9650), "24103a0f-efe7-42f3-9b48-dd03fed1d92b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "731b9fd0-9b9a-4bf9-b24f-ddd586dbf509", "AQAAAAEAACcQAAAAEKPP9jKl7o2KHdbI/b2ZeMPYd8nQ+BAum7GsGmFMlJPojBRTAafKahNceuS3PdcY1g==", new DateTime(2023, 12, 31, 10, 12, 46, 567, DateTimeKind.Utc).AddTicks(9542), "a36814cb-4d7f-453e-ba31-e024f5c45f1e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "30b7c224-bed0-4ea2-be63-966d1d79838d", "AQAAAAEAACcQAAAAEDE8XJsrYman9Su4W6mVnFM/OAjlf6vnSnwndTW5+ca5rMFJDjGxJjBCXydKGhT5fA==", new DateTime(2023, 12, 31, 10, 12, 46, 569, DateTimeKind.Utc).AddTicks(4796), "5e7a5a00-c426-4602-a248-771bfceab27f" });

            migrationBuilder.CreateIndex(
                name: "IX_Lectors_CompanyId",
                table: "Lectors",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lectors");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "f20d239b-a6c3-48ea-9130-c2ec03412b69");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "c5bdfc7b-14b6-4e22-b4ce-7bffd1f2b2c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "078e7645-a613-4d7f-93a3-4dc7bf05a921");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "68da7d48-6c9d-43d1-9723-a1538d2bdc6b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3981ecb4-030e-418e-8e1f-6ea0c25f62e6", "AQAAAAEAACcQAAAAEMN1/6zADRJ5OUdc0OfhtfmAwMcZ+5ckk0GTWsj81aCDzVgP1UQJaVVrVQHBCJSgJA==", new DateTime(2023, 12, 30, 9, 49, 19, 955, DateTimeKind.Utc).AddTicks(9073), "87132bfc-5d45-42b3-aaa2-17e38bee7aa4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3c15fe88-adac-44b0-b4d3-27de1b32fa14", "AQAAAAEAACcQAAAAEBVc4ZHRjabrvM48lBP4NNkEyapp5BaNhif+kXFiMNGuF1+HA1kNd83LkQyO79SpGQ==", new DateTime(2023, 12, 30, 9, 49, 19, 959, DateTimeKind.Utc).AddTicks(4900), "8427ba0e-08fc-4f82-a8e7-992a9d8002d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "ce5602d5-2b8e-4735-b12e-f55c7a50a51b", "AQAAAAEAACcQAAAAEI9ZDh4oz892RYZRWIxqqQz6KL87c8e6wZ/03h4+m7KD/LtYdcEzRCap4GknjYKlLA==", new DateTime(2023, 12, 30, 9, 49, 19, 957, DateTimeKind.Utc).AddTicks(853), "05b02271-795c-45f2-8ca9-af135618bc5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "18ab9561-4ab1-4ae9-bfa6-359d2d27e468", "AQAAAAEAACcQAAAAEKzzwNhthgl+O6b0veow/jiW+Np27jZXmUQ1dO4FuR4vSnB7lZxyuIoBqQuV2KqVbQ==", new DateTime(2023, 12, 30, 9, 49, 19, 958, DateTimeKind.Utc).AddTicks(3021), "d5625bd9-949b-43ba-bfea-a7ca87d99dc1" });
        }
    }
}
