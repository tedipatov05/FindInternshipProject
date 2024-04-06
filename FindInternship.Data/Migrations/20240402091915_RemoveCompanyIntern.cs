using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class RemoveCompanyIntern : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "7b7a0dcf-a843-4798-aa95-8c3d81d3c337");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "6b12fb2a-25bd-4086-9a34-35194351f304");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "96a9c76e-3088-4b24-bdc7-9b7a85ee159b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "5170f598-e230-4148-80ad-0e0b83aa322b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "6a74ab6c-e8b2-4ba1-835f-69f482322b8e", "AQAAAAEAACcQAAAAENkEpuBUIslRCI7lUgvGg4kbK6kkpbWjHaf1of5rMvM6zrd94AKJFF0cTrhjdQCEtA==", new DateTime(2024, 3, 28, 12, 11, 13, 747, DateTimeKind.Utc).AddTicks(2643), "a0e04772-e451-47ba-b37b-167e8b12b2ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "05191931-a7c3-465c-8e08-56bedcdde381", "AQAAAAEAACcQAAAAEGc9xsV5Q9GHNjvamyjvfKSumFlHtrgpK5iVHw3Ap280i7Nc4dV5VBtYIjiCxxLSwg==", new DateTime(2024, 3, 28, 12, 11, 13, 758, DateTimeKind.Utc).AddTicks(6041), "e543409c-ae99-419f-a7a9-41be30f95d34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "e389514b-7c62-4b44-b690-5f942a5dbad8", "AQAAAAEAACcQAAAAEHDhtQk6oIF2eBFHWWS1BkbhbMjHl5sNAq70KFTrY0mfjLum17eGhfN7cOC5hWQnZw==", new DateTime(2024, 3, 28, 12, 11, 13, 753, DateTimeKind.Utc).AddTicks(5525), "fbc3c3bc-8b10-4106-addd-b0c177c3a1c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c17e9cc4-9869-437b-b546-29ec1206a806", "AQAAAAEAACcQAAAAEHQmbF5KeRpXAxmby/hcqQnZQRnR7YMll3sDeH3RkhQm1vX30AO5w8FvPW4Gvjvi6w==", new DateTime(2024, 3, 28, 12, 11, 13, 755, DateTimeKind.Utc).AddTicks(9096), "a04084e0-6468-4038-883e-00bde9d59e79" });
        }
    }
}
