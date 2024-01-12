using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class ChangedChatImagesUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatImages_AspNetUsers_UserId",
                table: "ChatImages");

            migrationBuilder.DropIndex(
                name: "IX_ChatImages_UserId",
                table: "ChatImages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChatImages");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ChatImages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "8626e057-3e7d-41b0-9ece-5d637bf61e17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "8d266d48-afd4-412a-aff5-8bee105ff991");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "cecf1275-92cb-48ec-a5d0-9c22806a7d5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "95234ed3-b41e-4511-8cf9-8c68bf1ba50b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "e1a55d8d-2293-4289-8e4d-d1675efc0b15", "AQAAAAEAACcQAAAAEDhDjmw7EMS0VqO8GPSCbYH31s3oCL9k1EFq2l2n77Q5jemVCOfbr+PyUUBa6fT52g==", new DateTime(2024, 1, 12, 8, 8, 31, 526, DateTimeKind.Utc).AddTicks(3106), "06f3f788-c5c0-44af-86f1-7d2bcb8b6dd0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "cbd4eb55-a082-46a2-a48f-fe0eb2638a94", "AQAAAAEAACcQAAAAEE4U2ql3fVVsGF/XRaSWXznEBw0Y9lqT7JIa4imEtKfII8eU5clWy4oPTf5+PFw/8w==", new DateTime(2024, 1, 12, 8, 8, 31, 529, DateTimeKind.Utc).AddTicks(8153), "361f0bc8-6154-4630-b501-85f9cbc14c9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "8cbe4318-9432-4c25-a6cd-9e66f3b2e00f", "AQAAAAEAACcQAAAAEO5D/ZvxEz8rCXMUSY8ZjZGjV6t+ghu3LPEq2tLRJNuCeWlASsfnOzG9jKukT7zmNg==", new DateTime(2024, 1, 12, 8, 8, 31, 527, DateTimeKind.Utc).AddTicks(5834), "7a1138cf-3473-4d22-894b-f94c1f44a8cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "03d19166-5b99-4dfb-a234-d06d139d8fc8", "AQAAAAEAACcQAAAAEDMM9CRoUeGnHxfov+2jjHlZfXGh1zZ/sEhASG4XPuIbXnuXQ9TlrTnvwpfyCq/iEg==", new DateTime(2024, 1, 12, 8, 8, 31, 528, DateTimeKind.Utc).AddTicks(6902), "14135e13-12c5-41f8-b68f-56af25309497" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatImages_UserId",
                table: "ChatImages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatImages_AspNetUsers_UserId",
                table: "ChatImages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
