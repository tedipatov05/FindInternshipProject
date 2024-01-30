using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AllowNullStudentClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ClassId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "6ee9d282-81ba-4447-a06e-49e5e8c2e31e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "89a0eb94-2fd8-4f21-9e4b-2edf1eddb024");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "6d4af5ec-d574-4048-ba4d-62c378b8c2c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "467e7be4-fd35-492f-b0e6-745227576366");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "6bfd3fab-0600-40ad-8ffc-03c697ae227c", "AQAAAAEAACcQAAAAEEVB27dFAb8a/MEu3d+UEraKq6CXBDVLgolEt0MayBce1fanzlbgV9Rmpci+GbdCWQ==", new DateTime(2024, 1, 30, 7, 17, 17, 678, DateTimeKind.Utc).AddTicks(9554), "b40a650a-f9c8-41c3-b69e-c2514b709442" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "a6890958-b261-4f83-8936-4d820b2ed276", "AQAAAAEAACcQAAAAEDokZlKSkEuHEDUI1XPf7dKYDybCSnsSL+WWyZKTs7lEbZstMtKkiE05hWgXtvuM8Q==", new DateTime(2024, 1, 30, 7, 17, 17, 687, DateTimeKind.Utc).AddTicks(3350), "13e4c84a-c177-44ce-8c2a-f61dbae47b0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "83f0e08f-02c1-4752-9a7e-9f69153bcab1", "AQAAAAEAACcQAAAAEDd6lIMztduYkr7JIXb8cwDfA/Pq57STbiKvGIZGOpnrLG04swUWgcDWBxNsyLP1+Q==", new DateTime(2024, 1, 30, 7, 17, 17, 683, DateTimeKind.Utc).AddTicks(8416), "7c05fee6-763d-4bcd-b021-5e6e6b75b6af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "36705ad6-c8f3-469c-8d56-ff1ca643b981", "AQAAAAEAACcQAAAAEHY49zSB0Zx3cwZaDMC3lwNKvluAw34FSzG+YsykAZQEaWwKWNkoayNLd/4DTv1zpA==", new DateTime(2024, 1, 30, 7, 17, 17, 685, DateTimeKind.Utc).AddTicks(6757), "0bc14c1e-a48d-4721-b535-c25372a19bb2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ClassId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "3d12493f-ac77-4b1d-884e-4b2d642d33d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "7d10d50b-e4a7-4a70-b481-f6301fbe413f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "ea16504a-e96f-47e5-9ced-e48cee7a1bf0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "8b46398f-603e-4b57-a0bf-71177aa82739");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "0ff00eb9-bb98-4b6e-935a-efee95bf2e41", "AQAAAAEAACcQAAAAEIzPmP9LnCxnMffKhC3Y6OmoQsbRsm8iSmgd2mM5xsvZ+QMswtc79XwYi6BLSkp6Kw==", new DateTime(2024, 1, 30, 7, 11, 41, 390, DateTimeKind.Utc).AddTicks(2424), "a5640933-24af-42c0-bfdc-090f9aeb3da2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3d75131f-d834-4c4d-ae84-463849a0b653", "AQAAAAEAACcQAAAAEFON4R4DC34ZVLPbh+Bh8B2wVV13QM56qhnd0OV+splybuGj0BobSdV9bdgFsOAiyw==", new DateTime(2024, 1, 30, 7, 11, 41, 398, DateTimeKind.Utc).AddTicks(3729), "7e78b325-eca6-400e-bedd-83ce46d01f96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "ed0491d8-fb2c-4e25-a668-75f375ac970b", "AQAAAAEAACcQAAAAEB8mUNeo3paZMBGjFHNNYxBimduxxeXiPFQC3WtqdWwjZ17ir1CRq8+72do/3yQv7Q==", new DateTime(2024, 1, 30, 7, 11, 41, 395, DateTimeKind.Utc).AddTicks(401), "aa125fd5-dd9a-4b26-868e-61ecb7fd0fe4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "97f2df7b-2467-4333-88f0-c579b931d64f", "AQAAAAEAACcQAAAAEPcssBUnJLrkhgWW5BwIGihEJBJCFkTbzsrJqfzZkGs3nMLwdS4dY7aCuIIO2VBCAw==", new DateTime(2024, 1, 30, 7, 11, 41, 396, DateTimeKind.Utc).AddTicks(7299), "d5cde73e-35d6-4ca9-915d-e65129578bad" });
        }
    }
}
