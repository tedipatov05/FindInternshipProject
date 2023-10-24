using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class SeedAbilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "AbilityText" },
                values: new object[,]
                {
                    { 1, "C" },
                    { 2, "CScharp" },
                    { 3, "ASPNET" },
                    { 4, "JS" },
                    { 5, "NodeJs" },
                    { 6, "Python" },
                    { 7, "EntityFramework" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "f61ffdba-968c-4d4b-ad40-cbcb714fd093");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "669207f6-8546-4c14-ab8c-d3b95bc68108");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "85698992-b178-4fda-ad4d-87dcb06217f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "6fc29f07-ec4c-451e-bac3-92378fffe098");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "4b5c7274-14f3-4258-8b02-97cf109cf381", "AQAAAAEAACcQAAAAEGl82fNkK8LK8HJ6NcFnBFsU7l/qs/th0ZrNrmsqyOGSE+S1gHdBClS+EH9qlV9b0Q==", new DateTime(2023, 10, 24, 18, 27, 44, 536, DateTimeKind.Utc).AddTicks(4138), "4b84f696-a662-4b7d-ade7-c3832b8ed1f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "961c55de-65ad-423b-97d4-87c7ed9e8690", "AQAAAAEAACcQAAAAEBKc+wmWwb6pDpMeOiKWH+B2QcEcgWxiDgAr67WHJczU48IdTA1RjAMOjn509kIQJw==", new DateTime(2023, 10, 24, 18, 27, 44, 540, DateTimeKind.Utc).AddTicks(2619), "0bb44724-23b5-42f0-95b0-f9a1601a901e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "9723773b-5ecc-4f1f-9b1f-f7a27f73eb77", "AQAAAAEAACcQAAAAEAVDpzEhcenTPE+s14hnuR7tYCn1E6ljKDErJe3V/xZQ/34TL1593buWx54R6AdzZw==", new DateTime(2023, 10, 24, 18, 27, 44, 537, DateTimeKind.Utc).AddTicks(6040), "373fdfbc-a7e2-4fba-854a-071c7aa5e9ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "f610d6a9-77b7-412c-9ff6-e938ec82396f", "AQAAAAEAACcQAAAAEJaIh1Qb1CsVn5tlrVq40StR7pgDj81SUkOkXvAex1/LPq/UVz5pWWsO9qdahtiueA==", new DateTime(2023, 10, 24, 18, 27, 44, 538, DateTimeKind.Utc).AddTicks(9644), "e15d3d5c-f797-4065-8baa-bca963452710" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 7);

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
        }
    }
}
