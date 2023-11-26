using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedColumsIsApproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "b0a0544a-7827-469b-9c19-19f501a3ecc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "f126e787-8774-44e8-b4c5-4767a5e0d936");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "55c07874-9672-4ccc-8899-6ad8e3281270");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "a1185846-dd3a-4fbe-9a02-65ffd4f07490");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "f806ca08-9a71-47c7-8169-8c1e3dffed96", "AQAAAAEAACcQAAAAENDeJ9aLIxOkK8iU3xkwQvr0mD2y0YYD403UZs5xpu3RoEl1oeTLY0BTRKjfv5PqUQ==", new DateTime(2023, 11, 26, 19, 36, 58, 512, DateTimeKind.Utc).AddTicks(2900), "8cd2fc7e-2c07-4581-aa4c-0b2ee7deaf15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "7366750a-a4bc-4bc3-862b-7edf04fa96f4", "AQAAAAEAACcQAAAAEAZzk4SbWmXhGT2J8zxjZBog++z+N6sbkpVTYha1FRvch3XebtPEwG593EB/Rf5nOg==", new DateTime(2023, 11, 26, 19, 36, 58, 515, DateTimeKind.Utc).AddTicks(7488), "77b236f5-bf65-4b41-a1ea-809572d5ae8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "8710ee4f-0bdb-4d76-9753-e4b8aedf3fe7", "AQAAAAEAACcQAAAAEIKMKo4smKUZ4JE1yjRbDvrwUQOJbCdIaw1qaCxGnGs+hi6m1JgScjHMMjNu8VjC7A==", new DateTime(2023, 11, 26, 19, 36, 58, 513, DateTimeKind.Utc).AddTicks(4524), "c730b79e-dc55-4e13-8815-f450854a9d1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePictureUrl", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "48d55220-fbca-405b-8953-4a03ae79e6d8", "AQAAAAEAACcQAAAAEJNvwPcpVlp0CSQYjnkMgx0yAVo1RfwAJq31pmk/OFRRmKsi23etgGoR86ATsxxqng==", "https://res.cloudinary.com/ddriqreo7/image/upload/v1699781438/projectImages/pblz1onyuacbk2ds4g8n.png", new DateTime(2023, 11, 26, 19, 36, 58, 514, DateTimeKind.Utc).AddTicks(5792), "80841032-77ff-499b-b680-da3ee9da644a" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "e309dc7e-dad7-42cc-b83b-febb316cc49e",
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "2644afb5-f916-4b3f-b451-9ff86c881de3",
                column: "IsApproved",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "37823b69-02f1-452e-a35a-0e01f0d49859");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "8e42d16d-6590-45cc-8b77-a37790bf81c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "e61fa67c-4b08-45a3-bc84-3eea8a2a670b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "494564ec-4ba1-4680-978c-8616086b5b52");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "683d8a4d-b0d4-4271-9c99-c2a474729c09", "AQAAAAEAACcQAAAAEAhFSJ/NwE/xMjZ4DDjwxDbOBY4yK6AxNAvJKxyFhE+ZMwOxT1ycL7ksP9wsQwkb0Q==", new DateTime(2023, 11, 9, 6, 58, 9, 547, DateTimeKind.Utc).AddTicks(3949), "555a5573-9819-4bde-9e2c-afb5f7a5cc9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "386f5e6c-c206-4d69-8c55-e649ca24fdd1", "AQAAAAEAACcQAAAAEE0d5MG96yl1D+6F8A4ao2eKNjv175LaDq/2M/yLKaQ9kS4y4E+xKAStW6FfOiA+VQ==", new DateTime(2023, 11, 9, 6, 58, 9, 550, DateTimeKind.Utc).AddTicks(8658), "3cfe5cf5-b941-484f-8821-5e102583978b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "31f9a865-71f9-4711-887d-62d336160841", "AQAAAAEAACcQAAAAEKqRzqxPcA55zHwJUvAoiF141sJzuOkUKgqmkuVWviMxeRgI/mQMO/CP77Z5QCrGAg==", new DateTime(2023, 11, 9, 6, 58, 9, 548, DateTimeKind.Utc).AddTicks(5778), "df27ba18-6ef2-44f5-b0a8-3dd24da90e1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePictureUrl", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "67ec84fa-2258-434e-bdab-4f7b5299eaf4", "AQAAAAEAACcQAAAAEDOyT8+62lFb8G3aU1+/KHm8n9N+c9JnYc0H+wxNyKyMjq9K2U2+PKTgUGPc5YR9mw==", "https://res.cloudinary.com/ddriqreo7/image/upload/v1699129335/projectImages/d1bplska8t4sv6rlkkoa.png", new DateTime(2023, 11, 9, 6, 58, 9, 549, DateTimeKind.Utc).AddTicks(7381), "6f16af2e-6358-49a4-aa69-44062ea4f651" });
        }
    }
}
