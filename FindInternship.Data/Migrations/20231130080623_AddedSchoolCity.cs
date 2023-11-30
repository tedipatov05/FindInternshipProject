using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedSchoolCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1,
                column: "City",
                value: "Казанлък");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Schools");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "54e4f00e-5db1-4fa3-bed7-ac00652c28db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "61e89a6f-7844-4c84-9b3b-1ab3d9847d2a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "c464d2e6-ed8b-496f-989c-8da5b769a3f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "70dbccb0-a039-4bfc-a871-ce72b1488138");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c38b5411-25aa-4847-ab0b-9d239cc53375", "AQAAAAEAACcQAAAAEBhsP/akpk3wdbQIFBHNEolBA53BGNZYmUUhqY3rC0B0dw6yIGi6iuTSaaUH+OjE4g==", new DateTime(2023, 11, 30, 6, 8, 58, 790, DateTimeKind.Utc).AddTicks(5080), "bd01fbe3-0b46-4b89-9da6-a718927155d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "af1054dd-916c-42a4-a918-d0701fc6538f", "AQAAAAEAACcQAAAAEKBXdcvlPNJGqt0sYLRpC39PFtaPU+R7P/s3z6oFSvTQwxV9mOXvCKd9VAN+6/iQAA==", new DateTime(2023, 11, 30, 6, 8, 58, 793, DateTimeKind.Utc).AddTicks(9142), "bd84c83a-bc20-4e03-acc8-cc302dee42fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3de50f6b-04ec-4162-b7e6-f0824ef21e10", "AQAAAAEAACcQAAAAEI4+zboKiJb1fga7tUSPRqKF0u49PlrVsQV3uMzmYL5/4quzFbygRC9B5vMyNtDT0A==", new DateTime(2023, 11, 30, 6, 8, 58, 791, DateTimeKind.Utc).AddTicks(6484), "0254e647-fdbb-4f0b-873d-3dc8c9d6adad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "e4f508e2-45ea-486b-ae13-92c490c78844", "AQAAAAEAACcQAAAAEE6MepnMfmAZvU+7bxS4fjYjBqz91f7WVutrZq5UBwGLXmarnnOkex78Ap/szPW6Cw==", new DateTime(2023, 11, 30, 6, 8, 58, 792, DateTimeKind.Utc).AddTicks(7999), "fc0c35fc-b1c6-4e7f-9016-2ec0aa450c7b" });
        }
    }
}
