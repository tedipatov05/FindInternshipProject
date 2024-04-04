using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class ChnagedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Classes_ClassId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Documents",
                newName: "RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_ClassId",
                table: "Documents",
                newName: "IX_Documents_RequestId");

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
                name: "FK_Documents_Requests_RequestId",
                table: "Documents",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Requests_RequestId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Documents",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_RequestId",
                table: "Documents",
                newName: "IX_Documents_ClassId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "6f249264-4ef2-496b-ac0d-971b0710c68a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "690b3336-c6b0-4abd-995c-e196d45bc507");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "f3c9a9e4-b29b-49a0-a35a-972f2e64de8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "745ed2cb-ec3d-45f3-85ca-8f6bff57bd43");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "6a8a70cc-c6bf-4e9b-808c-09c15692fdc3", "AQAAAAEAACcQAAAAEIRA/0dWQnMIho06SKagl6eEVvs8YR8Sv7ty4Iz3cQLGP/plYSz7UhuUTzXe4EiHpw==", new DateTime(2024, 3, 28, 6, 32, 37, 74, DateTimeKind.Utc).AddTicks(8419), "052267ca-e98b-46a9-9780-eb594afb88d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "96177a96-94b7-43ad-8f6a-a8ebfcc15dfc", "AQAAAAEAACcQAAAAECk8ixrhYubxMbT+KsVJVhjXmK6o+aNakcDWoYebz7HC8vS2DblYLgwxBGBW9+sIoQ==", new DateTime(2024, 3, 28, 6, 32, 37, 80, DateTimeKind.Utc).AddTicks(80), "0910c396-b7e7-4df2-bb43-b03b2fdb8fff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "050e4325-37b4-4e79-a4b3-c73f186c0ee9", "AQAAAAEAACcQAAAAEOlNm3osuxpQ3kqvnGSulMBlViIPNi0h3avn2doyEhg3sjfViofOwZKPJj8bb2/sOg==", new DateTime(2024, 3, 28, 6, 32, 37, 77, DateTimeKind.Utc).AddTicks(9106), "b1d308d5-e478-4f75-b2d6-8540a8f08a96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "01f3dab9-ffc4-40a6-bf1e-dfd95f51e04c", "AQAAAAEAACcQAAAAEO/IKJoWN0MPB+q1OISurttV0QwDN4VgI66JdRwCu2OO1nZcdIrlTE/98VvVDlVXJA==", new DateTime(2024, 3, 28, 6, 32, 37, 78, DateTimeKind.Utc).AddTicks(9594), "fc191dd6-8215-4b18-b9d2-60e908d293e0" });

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Classes_ClassId",
                table: "Documents",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }
    }
}
