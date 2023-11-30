using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedIsApprovedProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Companies");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "ConcurrencyStamp", "IsApproved", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c38b5411-25aa-4847-ab0b-9d239cc53375", true, "AQAAAAEAACcQAAAAEBhsP/akpk3wdbQIFBHNEolBA53BGNZYmUUhqY3rC0B0dw6yIGi6iuTSaaUH+OjE4g==", new DateTime(2023, 11, 30, 6, 8, 58, 790, DateTimeKind.Utc).AddTicks(5080), "bd01fbe3-0b46-4b89-9da6-a718927155d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "IsApproved", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "af1054dd-916c-42a4-a918-d0701fc6538f", true, "AQAAAAEAACcQAAAAEKBXdcvlPNJGqt0sYLRpC39PFtaPU+R7P/s3z6oFSvTQwxV9mOXvCKd9VAN+6/iQAA==", new DateTime(2023, 11, 30, 6, 8, 58, 793, DateTimeKind.Utc).AddTicks(9142), "bd84c83a-bc20-4e03-acc8-cc302dee42fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "IsApproved", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3de50f6b-04ec-4162-b7e6-f0824ef21e10", true, "AQAAAAEAACcQAAAAEI4+zboKiJb1fga7tUSPRqKF0u49PlrVsQV3uMzmYL5/4quzFbygRC9B5vMyNtDT0A==", new DateTime(2023, 11, 30, 6, 8, 58, 791, DateTimeKind.Utc).AddTicks(6484), "0254e647-fdbb-4f0b-873d-3dc8c9d6adad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "IsApproved", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "e4f508e2-45ea-486b-ae13-92c490c78844", true, "AQAAAAEAACcQAAAAEE6MepnMfmAZvU+7bxS4fjYjBqz91f7WVutrZq5UBwGLXmarnnOkex78Ap/szPW6Cw==", new DateTime(2023, 11, 30, 6, 8, 58, 792, DateTimeKind.Utc).AddTicks(7999), "fc0c35fc-b1c6-4e7f-9016-2ec0aa450c7b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "eada4d58-fdf7-4a39-be0a-c2574da71e83");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "10e36db2-607e-4886-a769-fc523a3b93c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "3f94cf08-2063-4eb9-884a-34ffaa157288");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "d3578a19-3c8b-4ef7-b8ae-408afbc6f8cf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "9dea2c70-4827-43a9-898e-13d39c91870d", "AQAAAAEAACcQAAAAEI90OGCKrCvB5PldwxRPhi0yFuh9keQTeP6flItm/SlX3zjHHgmHHS1k3x/kmrrdhQ==", new DateTime(2023, 11, 27, 7, 26, 1, 635, DateTimeKind.Utc).AddTicks(9854), "b7dfd114-2c0c-4745-913a-1fd58bf4b39e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "6153695b-d0be-4ea1-8e1c-15c940c2624d", "AQAAAAEAACcQAAAAEM/J+RtekcmCMmmzWafqohVmGOsMmLKS1BH8vLtkV3JYqR5RVW4x3NEDI4aQc9GMNA==", new DateTime(2023, 11, 27, 7, 26, 1, 639, DateTimeKind.Utc).AddTicks(3468), "1be2bc69-7208-4adf-8159-aa8029d17c31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2baf8cbe-0361-45ea-8626-ac8d9efb00f3", "AQAAAAEAACcQAAAAEDNR9sd7s6Xe+iwD8x9EoCzyvufqhxHeZ/E/LgTYiwnTz30uyd54hD8f/hyGdXgu3Q==", new DateTime(2023, 11, 27, 7, 26, 1, 637, DateTimeKind.Utc).AddTicks(1156), "127bf2f4-4055-4b05-81fb-e0feb1dc1a91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3bd4f050-7e93-4561-83b8-2504cf3fae9b", "AQAAAAEAACcQAAAAENaR58ui8417j60tQYspi40cWQhDX7Bu+rk4+nn3rfY2fy7ggKT/gB/HXhb9kQ5GcQ==", new DateTime(2023, 11, 27, 7, 26, 1, 638, DateTimeKind.Utc).AddTicks(2436), "e8669261-f43f-49ee-abb2-18c554ab1b3a" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "e309dc7e-dad7-42cc-b83b-febb316cc49e",
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "2644afb5-f916-4b3f-b451-9ff86c881de3",
                column: "IsApproved",
                value: true);
        }
    }
}
