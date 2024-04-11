using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedEntitiesForLiveMeeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomId",
                table: "Meetings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Privacy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                value: "d97edc97-66d2-45fc-a459-43040b01ef80");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "908d7921-fd35-4f86-a760-0a6f1d32ce66");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "d8903531-d6f1-49f3-93cc-9259806c39b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "d7123da8-7d48-420c-a9fb-979a19aa1e5f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "6a673668-6c20-46bf-9a39-a7c0c3576f78", "AQAAAAEAACcQAAAAECelpDJSX6bmR6qqt9+PewBwwyv/9gbFwwToVF8xvM24yJIud8/EYjmjth9puRUfsw==", new DateTime(2024, 4, 11, 5, 16, 54, 654, DateTimeKind.Utc).AddTicks(6196), "e5982f74-4e85-4730-aeda-c59a72f32df3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "4dc681a1-f827-4c23-8e1b-a3258f3e6ffa", "AQAAAAEAACcQAAAAEHnvAyCNg53w/+8pXHHOUrn7FIUfKnPuvubUwQSoq5ZANsSGcDNiXdd/+E4PBnmGSA==", new DateTime(2024, 4, 11, 5, 16, 54, 674, DateTimeKind.Utc).AddTicks(7820), "adcad4a5-9874-4c53-afd7-b89517e8961f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "9c0cea2f-9e05-42f6-9318-f59658fa82ac", "AQAAAAEAACcQAAAAEBuUsEd4HNohfWMvS7Ysz3jnLOMPE/RNEP1L4Vj/dgy0SjWhcfXKWEKYSZH901ZOdw==", new DateTime(2024, 4, 11, 5, 16, 54, 672, DateTimeKind.Utc).AddTicks(5536), "d00afbb5-3163-4654-882c-0ae6be379278" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "12e04436-c371-4ef6-a1ee-45f184f10514", "AQAAAAEAACcQAAAAEDucrYVUS5Gqz+ymRxc5IRwRN4iplMMI+n6BzrAy+MOx1NTpFK8jfUJyacxkpW1UeQ==", new DateTime(2024, 4, 11, 5, 16, 54, 673, DateTimeKind.Utc).AddTicks(7033), "2e649e62-15a3-435c-bb4a-653d37b9afd1" });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_RoomId",
                table: "Meetings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_MeetingId",
                table: "Room",
                column: "MeetingId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Room_RoomId",
                table: "Meetings");

            migrationBuilder.DropTable(
                name: "RoomParticipant");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_RoomId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Meetings");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "634213d4-e1fd-4370-9557-60288d349585");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "ef9f1ade-d98c-458f-96c7-c5dc99dc159c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "d8e12fb0-f418-4162-9955-6e543a7752c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "0ea8aced-7fad-4e58-a074-1db97fd13e78");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "641af692-c6bd-4ee3-8654-ec0a46882469", "AQAAAAEAACcQAAAAEIWJoTxIZjCAf85ZKqurHMicEONSnjc9kM83e029oYGuVIq5in5qsjp1m0nN+5UwCw==", new DateTime(2024, 4, 2, 16, 0, 8, 905, DateTimeKind.Utc).AddTicks(6879), "3d0d174c-6e68-4c10-ad22-04b750d81c3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "37ca025b-126a-44f2-a189-3b2d54cedcbf", "AQAAAAEAACcQAAAAEBoOsQsVyRHyp2Unh4jDYfL9JzJT9wvZA3Xhe4uu5lvNf3kZ3O5ItHFfcj3yWcjz2g==", new DateTime(2024, 4, 2, 16, 0, 8, 920, DateTimeKind.Utc).AddTicks(6146), "e0a0491e-7e05-47b4-ab71-0b77e34b29a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "23bc2602-358e-4ae4-92c8-f1e0078df180", "AQAAAAEAACcQAAAAELAPR4MeHkO6uHK+RPXnQEp7VJHnz9VspQqasMhpqbrScnlNezAbOTGw0bxoIyx59g==", new DateTime(2024, 4, 2, 16, 0, 8, 914, DateTimeKind.Utc).AddTicks(7535), "fe8a43e9-f3a2-4914-9431-ac8715ef66f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "dce6abd1-0eb1-4c46-bc43-27beec733483", "AQAAAAEAACcQAAAAELAkNIB7vkkMGbhk7Xn2NAzCKKmdu3/8uCa8sMrc3R5of39543bTzDQxgeYSyX7/ug==", new DateTime(2024, 4, 2, 16, 0, 8, 918, DateTimeKind.Utc).AddTicks(351), "1d78045b-5fa9-4eca-92c6-ba15f6155cc5" });
        }
    }
}
