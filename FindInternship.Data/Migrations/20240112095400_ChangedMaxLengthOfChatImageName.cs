using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class ChangedMaxLengthOfChatImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ChatImages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "8466dd21-d5c1-4e06-a458-5af71b93a4c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "2c604302-4f95-470a-8797-0ed30cd33b1f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "6b9a8882-7106-42ee-ae75-0ff67905de0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "9674be0f-9c03-41e1-8d8f-e9db268c92fe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c9df2a77-a06a-435a-96b2-762dad6809d8", "AQAAAAEAACcQAAAAEK8llZQwT2CLSpCle6SXzDnk8HhawTct6N86gaNpwM16vNQD71N2ZqcM/e/U2a6+pQ==", new DateTime(2024, 1, 12, 9, 53, 59, 599, DateTimeKind.Utc).AddTicks(1875), "102a7593-65e2-4780-a204-43d0e951634e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "24db242c-b0c3-4f0b-bb07-48fb062388d8", "AQAAAAEAACcQAAAAEErD0M2is3RtPSPF3Hh8/Cprsjou2NhRjk7kCudB8ikfGcocL3/BQWot3tzyumnxmw==", new DateTime(2024, 1, 12, 9, 53, 59, 604, DateTimeKind.Utc).AddTicks(9204), "f1d22315-895c-42a9-b7a4-3a020a79047d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2b85381a-ac12-425d-99d8-05c300509043", "AQAAAAEAACcQAAAAEPSLxhUe3p2XYr5uVAMcgoaN9IBjLnGBZZsyFDHKW7yiOF3RS0cXJsR58Qt7lWNUIw==", new DateTime(2024, 1, 12, 9, 53, 59, 601, DateTimeKind.Utc).AddTicks(1429), "c319a601-2be6-4e79-82db-ee8331b38813" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "e328a573-0601-4267-9e5e-3a86c0a8392b", "AQAAAAEAACcQAAAAEHi78AQRA09zMrMj6w+1JPAf/Is0E9lm9Rqi2ZUn7zc0AK1Aym7HP+H6tD0Qxb62Tg==", new DateTime(2024, 1, 12, 9, 53, 59, 603, DateTimeKind.Utc).AddTicks(361), "e50df607-0d26-4ad9-8e88-bdc95af89cfb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ChatImages",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "6a1599da-fa43-45c3-b991-c9272f1b15ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "55e0408a-c567-40b0-9135-c53a2e2ffd2c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "54838cbc-6269-41fc-9669-f3f70ecaf421");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "c14f3088-db34-4c19-92a2-efe74455ebf2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "417cee2c-9fe5-4d92-81d4-344a74a6a85d", "AQAAAAEAACcQAAAAEC1wJ0EhdKe08MI/tW8vGfIcbGSCd8+y3aGuh34LE6k/w0lT7Qs5Vj6m7Lx9FpOHYQ==", new DateTime(2024, 1, 12, 9, 24, 15, 513, DateTimeKind.Utc).AddTicks(6657), "ad69ab67-ad3a-4be8-949a-028cb9c5775f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "8a60c292-7720-4a1e-9370-4e4129b2c6e6", "AQAAAAEAACcQAAAAEPoV6cf8JwPiOQcP2ny3bneHkhhrODzDbeStRszkIgvljU/nmnu7XO5UucsdWqJN7g==", new DateTime(2024, 1, 12, 9, 24, 15, 517, DateTimeKind.Utc).AddTicks(937), "41118a31-1fdc-4feb-9497-ada3d117d914" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "b235cf93-90c2-41f3-9da0-19e57a08fcd3", "AQAAAAEAACcQAAAAEGdmghEQKR7K0uVJD0IrHUfeKVyWPAGwe5fvdSIvNHg4RTjfLtr0TWo6Tcz6bcwqXg==", new DateTime(2024, 1, 12, 9, 24, 15, 514, DateTimeKind.Utc).AddTicks(8110), "fe5af2c4-b6eb-4c98-8c80-e20f3af14f83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "434eb83c-dc55-4bc1-87a7-fca5e0274e75", "AQAAAAEAACcQAAAAEJ2cTUILXEwmWONd/dQK9uOGKayt+Eg2XCgTD3n+bGkFLUlcYMI9yBAZtbmJPt8k6A==", new DateTime(2024, 1, 12, 9, 24, 15, 515, DateTimeKind.Utc).AddTicks(9553), "19c99cb2-bf83-4108-9763-6e9d892fc061" });
        }
    }
}
