using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class SeedCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "df9161b4-02aa-4ee4-91d4-65639441c55d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "85b4694a-991d-4706-af09-0effd9dabb75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "ce173442-4e38-4fe4-8f63-3bf69248a7ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "f659557f-72ac-49b5-aa02-7ce616292f68");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "0cb3180d-3aff-48f1-bbed-d6aca2dc5351", "AQAAAAEAACcQAAAAEH7pKfEM/KJ9otSntPtyiWK+jWwMWqScifnO4x5TK2UtuWwTG/gHJnqXTp1fK9NoYw==", new DateTime(2023, 10, 19, 5, 8, 51, 895, DateTimeKind.Utc).AddTicks(7162), "46b7e5b2-8ef4-42e1-9496-a75027d22aec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "dbe341f0-500b-4fb7-808c-1af1c020c24c", "AQAAAAEAACcQAAAAEJnxpOvrvdFXflupQfLZaai5VCGZMBVO5d0gbeUHX6B1bttnR2X69wldlt3UrXTSdw==", new DateTime(2023, 10, 19, 5, 8, 51, 902, DateTimeKind.Utc).AddTicks(3863), "5099f518-1901-46a6-84c9-83a3e5eb8264" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "b2748d8c-7715-46c2-aa8f-eb09afa77ee9", "AQAAAAEAACcQAAAAEFc3OJ1vTM7/Es2QGvhZRM2wIrA8+wHbrtPKukLsmRtl10g2SgodNLX2RzAAF8tYeg==", new DateTime(2023, 10, 19, 5, 8, 51, 897, DateTimeKind.Utc).AddTicks(6099), "3f597d26-2fb4-4724-bb12-e9e38061410b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "19f02fa4-79fa-4801-81e5-d6c2708add45", "AQAAAAEAACcQAAAAEM1/wwb13MCQfGWW8DU8UCGN6ABc5JMxddcElL4VgaMaNf1OMfMKZPba5jvXek6Y7A==", new DateTime(2023, 10, 19, 5, 8, 51, 899, DateTimeKind.Utc).AddTicks(9584), "2bb0a89e-9191-4035-9462-0633442721c5" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Services", "UserId" },
                values: new object[] { "e309dc7e-dad7-42cc-b83b-febb316cc49e", "Това е нова компания, която се занимава с изработката и поддържането на уеб приложения разработени за клиенти.", "Изработка на уеб приложение, поддържане на сървъри", "cb5ee792-90f6-4e50-8af1-da2f99d9f892" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "e309dc7e-dad7-42cc-b83b-febb316cc49e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "4cc2c52b-bb2d-4849-8c46-dffc3115a4d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "9a72560f-7706-4eb5-aec7-e153dc096e53");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "38464e66-aa35-4894-8e38-dedc66d879da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "6940e04e-9e3d-4cf7-ae41-7aadbbec445f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "639386f6-47c2-4f16-a39d-b71e33e985b0", "AQAAAAEAACcQAAAAEMc3lK6YBPZfqVBwziiN0WOV+sI2tej9x7tHoYgNHtq8rKE/KPO27ExzEj8CDWhmVA==", new DateTime(2023, 10, 18, 15, 37, 51, 40, DateTimeKind.Utc).AddTicks(4290), "847f8423-5042-43cc-a6c6-62f4b099ec30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "d7f9de51-c12b-4258-9e91-a55dadff2ebc", "AQAAAAEAACcQAAAAEKH4tEQjFZ6jFnleCj4JitjNfNMoU3svB2BZQzT9Eg73OuKG4L3LxjLLvc1y0ShahA==", new DateTime(2023, 10, 18, 15, 37, 51, 43, DateTimeKind.Utc).AddTicks(8154), "bc32f0b8-5dca-452c-9543-417119c38d72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "bf9b01c8-454d-4331-855c-6567ab437f35", "AQAAAAEAACcQAAAAEHDJyXrMyGPgFafqLklGAHdXS/zKJlN3pwsrq64nxh4BTmTwEbOszevbWDfZdM7eBg==", new DateTime(2023, 10, 18, 15, 37, 51, 41, DateTimeKind.Utc).AddTicks(5401), "51a33fe7-ffa9-4e2a-b633-c24fde6acaf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "e661243f-134a-4135-bd12-5d13547039d7", "AQAAAAEAACcQAAAAEK9ZGzYQfuxl55XLNuuw4EIVMSC+8npYLtESJlSkbkSB1uU1beRYChjtEAPxCVKQvQ==", new DateTime(2023, 10, 18, 15, 37, 51, 42, DateTimeKind.Utc).AddTicks(7196), "60bf63f2-225d-4135-acb7-7f10e5b98d8c" });
        }
    }
}
