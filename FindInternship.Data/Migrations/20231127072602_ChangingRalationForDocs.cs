using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class ChangingRalationForDocs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Students_StudentId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Documents",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_StudentId",
                table: "Documents",
                newName: "IX_Documents_ClassId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Classes_ClassId",
                table: "Documents",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Classes_ClassId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Documents",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_ClassId",
                table: "Documents",
                newName: "IX_Documents_StudentId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "82255442-353a-45dc-80dc-67f47d54394a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "f9196e23-9b40-4619-8306-3b40c3503502");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "df12dc0f-61c7-44c2-8641-bb61bb56999f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "202bbc64-3c60-4bdc-b390-5525694a01f7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "8e84bb06-f247-473e-82f4-f62c8b373108", "AQAAAAEAACcQAAAAEB8toDSL0mVsgStXf+xHVXSL3ZNjbVZDoW+UVFQ1CiiWM+zA6htR2bUTfZp0ruJJMA==", new DateTime(2023, 11, 26, 20, 19, 10, 744, DateTimeKind.Utc).AddTicks(7634), "89fdf57d-31f3-43d0-873e-9ef37bbf9cca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c872c845-5ec4-4115-9219-14e633df5c1f", "AQAAAAEAACcQAAAAECenka6yEFHkyVtA5ICQlY75VnoapsIXHqCuDJNS+KUpgidkBPLvGKFLSfv9W7KtLA==", new DateTime(2023, 11, 26, 20, 19, 10, 748, DateTimeKind.Utc).AddTicks(1615), "9c01cbc4-1635-4747-b710-09894460bf2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2f4f4c0d-6dd8-42dc-8e0c-ddceb0ad25af", "AQAAAAEAACcQAAAAEFmPM8LyvyiuN01xPZuThqP0veg5Yv1r/lynxJj7VSTbiUHot8utwOM578/LNwMcFA==", new DateTime(2023, 11, 26, 20, 19, 10, 745, DateTimeKind.Utc).AddTicks(9054), "5f0bd2f7-d5a9-4974-99a2-c51e33fcc843" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2ccaa248-bfac-4e0c-954d-db57e81e299a", "AQAAAAEAACcQAAAAEHrS4HnXgJH7wWSIHOdTpjClwNxvzph9frknDfTzTbQ97ucCd2yhLboEKx+uTY2k8Q==", new DateTime(2023, 11, 26, 20, 19, 10, 747, DateTimeKind.Utc).AddTicks(276), "853a2b8f-a793-4473-94fc-d40d17298474" });

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Students_StudentId",
                table: "Documents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
