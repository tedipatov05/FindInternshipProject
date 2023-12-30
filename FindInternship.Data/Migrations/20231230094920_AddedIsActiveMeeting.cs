using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedIsActiveMeeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Meetings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "f20d239b-a6c3-48ea-9130-c2ec03412b69");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "c5bdfc7b-14b6-4e22-b4ce-7bffd1f2b2c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "078e7645-a613-4d7f-93a3-4dc7bf05a921");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "68da7d48-6c9d-43d1-9723-a1538d2bdc6b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3981ecb4-030e-418e-8e1f-6ea0c25f62e6", "AQAAAAEAACcQAAAAEMN1/6zADRJ5OUdc0OfhtfmAwMcZ+5ckk0GTWsj81aCDzVgP1UQJaVVrVQHBCJSgJA==", new DateTime(2023, 12, 30, 9, 49, 19, 955, DateTimeKind.Utc).AddTicks(9073), "87132bfc-5d45-42b3-aaa2-17e38bee7aa4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3c15fe88-adac-44b0-b4d3-27de1b32fa14", "AQAAAAEAACcQAAAAEBVc4ZHRjabrvM48lBP4NNkEyapp5BaNhif+kXFiMNGuF1+HA1kNd83LkQyO79SpGQ==", new DateTime(2023, 12, 30, 9, 49, 19, 959, DateTimeKind.Utc).AddTicks(4900), "8427ba0e-08fc-4f82-a8e7-992a9d8002d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "ce5602d5-2b8e-4735-b12e-f55c7a50a51b", "AQAAAAEAACcQAAAAEI9ZDh4oz892RYZRWIxqqQz6KL87c8e6wZ/03h4+m7KD/LtYdcEzRCap4GknjYKlLA==", new DateTime(2023, 12, 30, 9, 49, 19, 957, DateTimeKind.Utc).AddTicks(853), "05b02271-795c-45f2-8ca9-af135618bc5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "18ab9561-4ab1-4ae9-bfa6-359d2d27e468", "AQAAAAEAACcQAAAAEKzzwNhthgl+O6b0veow/jiW+Np27jZXmUQ1dO4FuR4vSnB7lZxyuIoBqQuV2KqVbQ==", new DateTime(2023, 12, 30, 9, 49, 19, 958, DateTimeKind.Utc).AddTicks(3021), "d5625bd9-949b-43ba-bfea-a7ca87d99dc1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Meetings");

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
    }
}
