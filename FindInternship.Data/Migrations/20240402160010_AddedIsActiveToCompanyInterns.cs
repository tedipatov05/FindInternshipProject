using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedIsActiveToCompanyInterns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CompanyInterns",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CompanyInterns");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "7eeb39b2-a523-4beb-83ef-e1a32520beba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "2868f798-8934-4fd9-a46c-431d8f0df442");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "b8bb0073-b885-4305-98c0-4667b028e0b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "8945612f-942d-48d0-bed2-077d0c986806");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "a4a00b13-e347-4452-82bd-751d8a85fbf2", "AQAAAAEAACcQAAAAEI480jZQ1Gu+a1c2M9qqJ26zJXTqjMquW++e5wy6uyHW1Kgow9i3NkowsKWIslhLKg==", new DateTime(2024, 4, 2, 9, 19, 14, 406, DateTimeKind.Utc).AddTicks(3871), "ec3a570f-2fec-4591-89bd-60dd4bc2d9ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "b8c4fe1a-0814-4a6e-9ee9-e5fae5bc601a", "AQAAAAEAACcQAAAAEGa4vgt+m1OsOLnlHHK8VXwEVmKMdBnz6vER+3kjc3UqINzUBa6lKdD8f86yeKH8lA==", new DateTime(2024, 4, 2, 9, 19, 14, 417, DateTimeKind.Utc).AddTicks(9371), "33a9e57e-6be3-43fd-9d67-173d56314175" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "f4a667ac-d7d8-4b86-a1e0-8b0ee5fcc2ed", "AQAAAAEAACcQAAAAEExjy7boYhkouZn1LaSzr7HDY3pmRwDZrZ8LcsdLQhu7pn00HzcQRMZKhI5p/kgd/w==", new DateTime(2024, 4, 2, 9, 19, 14, 413, DateTimeKind.Utc).AddTicks(433), "1882afb3-6962-4d09-b5ef-6e41c9d061b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "07d48e6f-faea-4175-809d-21e6d89f0a68", "AQAAAAEAACcQAAAAEPhLsjFjp+Mdo7NmIcfdK85jcEZLHh79TaGNYTAxpnVgLnHgq2Ax4eCFpNfTH4UoUg==", new DateTime(2024, 4, 2, 9, 19, 14, 415, DateTimeKind.Utc).AddTicks(4297), "7be99170-c967-4755-88e0-4072414eb3d9" });
        }
    }
}
