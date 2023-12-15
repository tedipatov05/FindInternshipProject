using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedEndTimeMeeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Meetings",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "a8d2b607-b215-4e3d-a267-67972e919c14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "edbdb91e-7aad-468b-93bf-1f1dccc12b39");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "67ed429f-d671-405b-9dbc-7102406b1ec4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "56badd73-fd7e-42f6-ad81-3f3a507d8b49");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "8f880526-e432-4fd1-89aa-f521c30cd9ee", "AQAAAAEAACcQAAAAEGlDrTZWrZ+hTW8Nb+ZpsS69W7v/3rKiWNal42uPyDValtzDbpw8k18wPpnEfJKlxg==", new DateTime(2023, 12, 12, 7, 35, 25, 876, DateTimeKind.Utc).AddTicks(9206), "4d4cbf59-3f34-4f91-b579-6453f444871d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "57e2b192-9fbf-4983-a8e0-b907e5a51bd9", "AQAAAAEAACcQAAAAEAia//edJZswEXCB2zf9g+K2JbiFSiWiA4qj1kgK5pyjQERelXl751Q85P0KMsztkw==", new DateTime(2023, 12, 12, 7, 35, 25, 880, DateTimeKind.Utc).AddTicks(2234), "7c0dc619-9c71-4fd0-8e56-88a2faf99ff9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "57392e78-dbeb-45df-bec8-61478f441e7f", "AQAAAAEAACcQAAAAEK4Yxicr9zyDNMRZ9aATWiiLseGv+I0JdbYhpEc6bYbPZ5VcVOGNNCSM4aXHfnffLg==", new DateTime(2023, 12, 12, 7, 35, 25, 878, DateTimeKind.Utc).AddTicks(535), "de4f2bf5-e24d-4c08-b1d5-fc027c4277a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "d833b958-d8fe-48bf-b273-5ed767ef7947", "AQAAAAEAACcQAAAAEHn6ij/LOsAD0cCffoOWgQ11Dbia/UjgiDefz9sZY3+jTJkuCoLE1xV4JnIBmXS0rQ==", new DateTime(2023, 12, 12, 7, 35, 25, 879, DateTimeKind.Utc).AddTicks(1369), "4cb192f5-8ae8-409c-b6b3-3043637d1268" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Meetings",
                newName: "Time");

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
    }
}
