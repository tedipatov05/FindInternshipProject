using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class ClassTeacherIdAllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "0dd5fa43-5e0f-4872-b554-c93fdfc46ae6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "d052a534-51ea-4894-89f4-d3f2ddc3088c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "7f679ae0-dcce-4baa-a61e-32f9c10c3e36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "495f2dad-73bd-4892-b543-a181b9e889fe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "298c4d86-2664-4ad5-aca7-2daffed22b5d", "AQAAAAEAACcQAAAAEEGGMEz3BoFCBOtYXGdY5QHgSBqilBzRzDh5AZxynTb88VvZR2pE4fsymqbMm3fUDA==", new DateTime(2023, 11, 30, 16, 35, 38, 318, DateTimeKind.Utc).AddTicks(3334), "9b93dd1a-1a18-4c00-9a1d-db241bfa7503" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c188ce4d-d300-4297-836d-25a643aebece", "AQAAAAEAACcQAAAAEK+irY/Qx8qkvJ08dKGkeUTJ0GZNvMjjkwdGU2WgJBtEAzGqp9CxUbPkL/3WLJioOQ==", new DateTime(2023, 11, 30, 16, 35, 38, 321, DateTimeKind.Utc).AddTicks(8473), "791389d9-669d-41b4-8ba4-0f30add128ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "6d7508a0-6df7-493e-84c7-2a840cc0e51e", "AQAAAAEAACcQAAAAEJXlDj3vBWhG1rWU/kaFOROMo7a7eYjujH3HfKd10uGXCxsvi0mFmEq41dEvOdgSCw==", new DateTime(2023, 11, 30, 16, 35, 38, 319, DateTimeKind.Utc).AddTicks(4529), "716a9ceb-7ca7-406b-adfc-f39401a8c850" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "987e9c69-b764-46ec-99d4-7881e65eed74", "AQAAAAEAACcQAAAAEHZ+GWcEX552nINUW57aPfrnNxT56apPldvhLBOnb+6xh0hur6B5mzgHK3dwv4pobg==", new DateTime(2023, 11, 30, 16, 35, 38, 320, DateTimeKind.Utc).AddTicks(6956), "1236bcc6-eacb-4069-b387-d1557138db42" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "e3c10f62-7b9c-4419-93d4-c07d8637d5f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "6d083515-5f80-4ef8-aa60-0a5031bfcd35");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "47b827ae-f936-49e5-8adb-657ebc12a0ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "1a5f0c71-6952-46fe-b770-eda42926edfa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "77624034-f329-40b2-a58e-d0fd373cefcc", "AQAAAAEAACcQAAAAEPvOgQqDI352aADSSTFDAvsVHj6/XcNdEaqOq8T+xyp1zrhB4YIDiGwTv3Pr8hFjBA==", new DateTime(2023, 11, 30, 8, 6, 23, 172, DateTimeKind.Utc).AddTicks(5925), "d920f9ff-86f6-4d68-9d18-729a3278c642" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "cbcacd6d-b829-455d-b3af-6187733440a5", "AQAAAAEAACcQAAAAECeODXSuscjUms/LMq8P5Am77WaVKD2xNaLGCK1zXsUnZwAxdOCdGtTdaU+hsRDTCw==", new DateTime(2023, 11, 30, 8, 6, 23, 176, DateTimeKind.Utc).AddTicks(2342), "625e7f99-0e8a-40f6-b560-1684baf2125b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "a32cfe33-5d23-46f3-b2d8-d6f87e9a8b7e", "AQAAAAEAACcQAAAAEM3VJAf3APw93vgNCPkW2tYsFaV0wawSnWhPQHUH8yJEu6hl4zvDZ7VaPST1GsedxQ==", new DateTime(2023, 11, 30, 8, 6, 23, 173, DateTimeKind.Utc).AddTicks(7193), "7103750b-eba4-4552-bb69-721f99e9f023" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "39a5c88a-294b-46bc-9fcc-78fe57ea81c9", "AQAAAAEAACcQAAAAELw/pSoOAIDZSMwPo+lykSpKD40132L9KkuebtSVI2ElhRSk7EGosuA4853UJezRbg==", new DateTime(2023, 11, 30, 8, 6, 23, 175, DateTimeKind.Utc).AddTicks(962), "9c91aef2-7fc6-4c35-b778-1930ff562331" });
        }
    }
}
