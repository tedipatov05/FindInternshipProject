using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class MessagesToRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomMessages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomMessages_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "cd35717d-194b-438d-9ddc-ebafaa3bcc23");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "fb62bbc2-304e-4188-9b43-e2ee2be3e2ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "c0f5e676-4243-4d52-a7d6-2d4ba5b15ba5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "3da92204-baec-4611-b31d-61db4e632264");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3508ef18-6637-4e47-a0c7-5a266bc331e5", "AQAAAAEAACcQAAAAEGW4vd5LASBJIdNVmDVlWruA+H5KwxDNyk3IVxAsM2BSE9Q7VLzVFdK/pTmhYyJOvA==", new DateTime(2024, 4, 21, 17, 58, 16, 699, DateTimeKind.Utc).AddTicks(9237), "0382f75c-bd33-428e-b019-aa3949d22726" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "814293c4-2ec4-4dbf-9b43-291f50f29dde", "AQAAAAEAACcQAAAAEAFbJeSUJ/gSAlwG31ZbevIWqIVxQed9iDnFO+4/ho+F/WDRHMWasZtF/oMBk5AeTw==", new DateTime(2024, 4, 21, 17, 58, 16, 706, DateTimeKind.Utc).AddTicks(7135), "4a2abe6e-a740-4af4-82dc-305440361f0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "ccd537ed-1b3e-4ab4-8659-2aedbee7dc59", "AQAAAAEAACcQAAAAEActHJrpymy4cnik49WTOt7Pf+DsJqEGwTxrSBz1rgdwTwVKXbTaBtlD2VW03Sq3ng==", new DateTime(2024, 4, 21, 17, 58, 16, 704, DateTimeKind.Utc).AddTicks(6217), "409ae5f9-5dc3-4284-89f3-1176fbca2019" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "fa472868-6229-4e19-a3ad-b113be0bee15", "AQAAAAEAACcQAAAAEFI5fsdq1EWy7gPVmipbrQV/1xhduC+gyIrCAStBlOY4Xq4tNS3uyKP+5xLvX8wgNg==", new DateTime(2024, 4, 21, 17, 58, 16, 705, DateTimeKind.Utc).AddTicks(7003), "115568f7-bc01-4f2b-a65d-e49c8414fb26" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomMessages_RoomId",
                table: "RoomMessages",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomMessages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "64065d84-8198-44f5-9488-c002b0ba7f8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "3137cb4a-69cb-4677-acf9-210518ad8d0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "87299b4d-30c8-46d1-8ebf-b8131de8c75b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "ff1dfc81-4293-405c-bd0c-1a18db032354");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c9c79103-84fa-40cf-a203-5399b8626e0b", "AQAAAAEAACcQAAAAEObOtOuIHiCgpb04mGpe11QqoOCblngyXrTAjtr2rl7e6FmXS8gRdhFW/nFUh+qIbw==", new DateTime(2024, 4, 17, 17, 37, 7, 82, DateTimeKind.Utc).AddTicks(7141), "388bf420-ff99-4882-8277-ba8efe405f12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "09df3dd2-82c0-4eb0-b454-184d23869835", "AQAAAAEAACcQAAAAEGyV+r8SqdwCIaFklKzIEhOhrTfK84QF4hXZxCVP7SN3TfJ60N/XCgKnSs5hvFGMYA==", new DateTime(2024, 4, 17, 17, 37, 7, 90, DateTimeKind.Utc).AddTicks(3683), "7f720843-d640-4786-91c7-f806086792fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3d1a694d-f6f2-4dcd-a389-2e402efa8a81", "AQAAAAEAACcQAAAAEK+lmVvhmK3Hf71qNHrXduIGgVpaek/0Zncvt6uIHjcPZjvIC3qlfcotHA7rrIPsEA==", new DateTime(2024, 4, 17, 17, 37, 7, 87, DateTimeKind.Utc).AddTicks(103), "d1066fc2-1579-49a9-8566-442430c90950" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "722aa9ac-f6ab-4ba7-a413-c3f3fb8024b6", "AQAAAAEAACcQAAAAEJLYKgAUNvsB10LUMLjP22erw7Hi5M7U6XZEr5BSuwSAi2xQcYiiHRyoVTSs45BhjA==", new DateTime(2024, 4, 17, 17, 37, 7, 89, DateTimeKind.Utc).AddTicks(626), "7bdf3676-9350-4665-a3c3-0b1f73430fec" });
        }
    }
}
