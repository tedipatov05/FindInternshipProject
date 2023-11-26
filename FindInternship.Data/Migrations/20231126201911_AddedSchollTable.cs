using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedSchollTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "School",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "82255442-353a-45dc-80dc-67f47d54394a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "f9196e23-9b40-4619-8306-3b40c3503502");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "df12dc0f-61c7-44c2-8641-bb61bb56999f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "202bbc64-3c60-4bdc-b390-5525694a01f7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "8e84bb06-f247-473e-82f4-f62c8b373108", "AQAAAAEAACcQAAAAEB8toDSL0mVsgStXf+xHVXSL3ZNjbVZDoW+UVFQ1CiiWM+zA6htR2bUTfZp0ruJJMA==", new DateTime(2023, 11, 26, 20, 19, 10, 744, DateTimeKind.Utc).AddTicks(7634), "89fdf57d-31f3-43d0-873e-9ef37bbf9cca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c872c845-5ec4-4115-9219-14e633df5c1f", "AQAAAAEAACcQAAAAECenka6yEFHkyVtA5ICQlY75VnoapsIXHqCuDJNS+KUpgidkBPLvGKFLSfv9W7KtLA==", new DateTime(2023, 11, 26, 20, 19, 10, 748, DateTimeKind.Utc).AddTicks(1615), "9c01cbc4-1635-4747-b710-09894460bf2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2f4f4c0d-6dd8-42dc-8e0c-ddceb0ad25af", "AQAAAAEAACcQAAAAEFmPM8LyvyiuN01xPZuThqP0veg5Yv1r/lynxJj7VSTbiUHot8utwOM578/LNwMcFA==", new DateTime(2023, 11, 26, 20, 19, 10, 745, DateTimeKind.Utc).AddTicks(9054), "5f0bd2f7-d5a9-4974-99a2-c51e33fcc843" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2ccaa248-bfac-4e0c-954d-db57e81e299a", "AQAAAAEAACcQAAAAEHrS4HnXgJH7wWSIHOdTpjClwNxvzph9frknDfTzTbQ97ucCd2yhLboEKx+uTY2k8Q==", new DateTime(2023, 11, 26, 20, 19, 10, 747, DateTimeKind.Utc).AddTicks(276), "853a2b8f-a793-4473-94fc-d40d17298474" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "ППМГ Никола Обрешков" });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: "0edc45cb-b2f1-48a2-8f6b-17910e09a147",
                column: "SchoolId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SchoolId",
                table: "Classes",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Schools_SchoolId",
                table: "Classes",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Schools_SchoolId",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Classes_SchoolId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "Classes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "48d55220-fbca-405b-8953-4a03ae79e6d8", "AQAAAAEAACcQAAAAEJNvwPcpVlp0CSQYjnkMgx0yAVo1RfwAJq31pmk/OFRRmKsi23etgGoR86ATsxxqng==", new DateTime(2023, 11, 26, 19, 36, 58, 514, DateTimeKind.Utc).AddTicks(5792), "80841032-77ff-499b-b680-da3ee9da644a" });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: "0edc45cb-b2f1-48a2-8f6b-17910e09a147",
                column: "School",
                value: "ППМГ Никола Обрешков");
        }
    }
}
