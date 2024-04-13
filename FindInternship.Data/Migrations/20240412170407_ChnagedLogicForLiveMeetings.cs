using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class ChnagedLogicForLiveMeetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Room_RoomId",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Meetings_MeetingId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "RoomParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameIndex(
                name: "IX_Room_MeetingId",
                table: "Rooms",
                newName: "IX_Rooms_MeetingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "45319787-3e6a-4619-bb13-1d2f3a564cc2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "d780913e-3dc8-4c69-80a8-739cac8c924a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "322ab861-ba3f-4b35-8bef-ae4edb5bbe45");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "8630643c-b020-4b53-97bb-df2f085c2fb3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "0bdc7cf1-8041-484a-a49f-6ea521825e58", "AQAAAAEAACcQAAAAECszZJdVF7Co/fj5nWorDm/UU7sRJEOLjpCde2XSREMtCdlSycTmbXgQTMQOih5j7A==", new DateTime(2024, 4, 12, 17, 4, 6, 769, DateTimeKind.Utc).AddTicks(3890), "d9e67086-5fbc-4f4e-85a7-5023861af10e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "9d28b577-ed6c-4951-833c-aec339918ab8", "AQAAAAEAACcQAAAAEKhbPhtFIY7IoEHNWwh1fb+JeFBYks6Vb/yOM1UaWTmHD7hyf+xfkgwmkdIx4N4OmA==", new DateTime(2024, 4, 12, 17, 4, 6, 775, DateTimeKind.Utc).AddTicks(9385), "0170008c-985a-4e4c-83e2-9cbed838ee0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2ac920de-6d93-44fa-a1b8-f360caacf4fd", "AQAAAAEAACcQAAAAEMDR70YEoqDZh7b8ra0EubK2bA4qf4LpKgEgBopenC4iBYXUXtOmp6hGFtPnzkGFkA==", new DateTime(2024, 4, 12, 17, 4, 6, 773, DateTimeKind.Utc).AddTicks(8074), "8c0769f9-cbf1-4748-adc6-50e855742e26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "5c38e272-9f94-44a8-a612-073632ba2d93", "AQAAAAEAACcQAAAAEPAvRHIHQVpbd/eNyx46HnupbSQc35ddYwOVsihWECsUcQ1f/Uw5uSIO/NBmbBRfyw==", new DateTime(2024, 4, 12, 17, 4, 6, 774, DateTimeKind.Utc).AddTicks(9118), "945850fb-a2bf-4002-b788-f9dc5fe8bd92" });

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Rooms_RoomId",
                table: "Meetings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Meetings_MeetingId",
                table: "Rooms",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Rooms_RoomId",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Meetings_MeetingId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_MeetingId",
                table: "Room",
                newName: "IX_Room_MeetingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RoomParticipant",
                columns: table => new
                {
                    RoomId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomParticipant", x => new { x.RoomId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RoomParticipant_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomParticipant_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "9af3f575-8941-406d-be0d-1558d975347c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "009a2155-0ae9-4f98-af4b-7c37d223bea6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "d9fe3c83-287d-4162-9f15-0af0b4cc57d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "a8f5ad7a-d51f-402c-abf6-e27c52dd5f39");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "18377906-db5b-44da-b8ad-e0adf61da8fe", "AQAAAAEAACcQAAAAEBxP5tPsTdfpp9MkHawWyv4rM57DTyNQb1I3CUbfPl3/X4f98bY+dWSCcM+Xyvi9FA==", new DateTime(2024, 4, 11, 6, 55, 8, 426, DateTimeKind.Utc).AddTicks(4081), "2b864c23-cdef-4616-8618-82be55bb26cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "d5c30cbc-4864-4403-aaa1-4a5c38f5d1c9", "AQAAAAEAACcQAAAAEGLA7ZIcha/xJxDtjKTO7q5rCWIUy9m7lWFlF2cEKQx5GdcBtBvHrYbCncz2lOj4pg==", new DateTime(2024, 4, 11, 6, 55, 8, 431, DateTimeKind.Utc).AddTicks(6536), "ac7a2987-882f-47d3-9bb4-89694b66576f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "9e3f208e-bed7-4749-831f-68f51f82a3cc", "AQAAAAEAACcQAAAAEHMTi5RtANpc1r3NTHUjtKRdFhvquKF9mpM7ZgqNQQAwvmruZl0xuW44XpBMAqKjzg==", new DateTime(2024, 4, 11, 6, 55, 8, 429, DateTimeKind.Utc).AddTicks(6103), "06cd3b26-04e4-42c4-8d8e-83924a0dca94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "7008b62e-ccc8-4ad2-be44-e92e2fe1b7e7", "AQAAAAEAACcQAAAAEDSJ060wJ428X7uLZ9+6fkoKI4Vx1G/9vHrtKwmWtqBmVqivqM/mUCEfxLCoHxo3ZQ==", new DateTime(2024, 4, 11, 6, 55, 8, 430, DateTimeKind.Utc).AddTicks(6946), "59e16f00-5e6d-4c95-b5cd-2b0acfd5319d" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomParticipant_UserId",
                table: "RoomParticipant",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Room_RoomId",
                table: "Meetings",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Meetings_MeetingId",
                table: "Room",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
