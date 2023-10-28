using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class EditedUserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "82b3efbc-6ddc-4b90-b383-0418e742e3f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "83a33fba-c7e8-4bfe-9153-c23b08a82518");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "dfc7a0ce-ad57-48bc-905e-633789c7b497");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "76653a53-c441-454f-8350-dcb72754ba24");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "7c8554bc-a5a8-4bfd-a746-f0cfd9c031e0", "AQAAAAEAACcQAAAAEFX55FFIYimaDEdoLSKW+29a4/WWeO2mI8PpxyR4KN/S3S5ZhXveY6n04c/Q6BnPng==", new DateTime(2023, 10, 28, 13, 27, 31, 452, DateTimeKind.Utc).AddTicks(4641), "35acee89-2f3d-419a-8a48-cddff345a121" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "5ede2695-da00-4be6-95af-2f2898ac787a", "AQAAAAEAACcQAAAAEIVmy2pFBnUN5BouNEVkbsx2q5P9th+7Ov6IADfNKSCXZTHQrHhn13eFyb2SJbXyIA==", new DateTime(2023, 10, 28, 13, 27, 31, 455, DateTimeKind.Utc).AddTicks(8595), "b44fd215-41cc-4b5e-b550-bac9d62b2dec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "223a0955-893a-43c2-b5ff-2f72a7c3e6ce", "georgidimitrov@abv.bg", "AQAAAAEAACcQAAAAECwZBxAISfMvFgMZ5bgkz8PW/KFMB7w40gEeaWOCcG97++cyezFymMSGEmCJGTlj0g==", new DateTime(2023, 10, 28, 13, 27, 31, 453, DateTimeKind.Utc).AddTicks(6223), "333d5644-2d06-4156-84d6-88ac5d52c157" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "49385fc4-940c-4d40-8581-4fb9503f6c28", "AQAAAAEAACcQAAAAEEbYDnVQmKY4UYKHx0THdFxNT4A8yVuuc0X33T9+ATooYx3Q1vuuo8C7rJdGtE1NYg==", new DateTime(2023, 10, 28, 13, 27, 31, 454, DateTimeKind.Utc).AddTicks(7692), "ff03f415-11e8-4733-831a-5dfecbb5bd13" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "1a7b0cc0-3fc8-453e-ace7-adbc6ac53713");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "400da6d2-34c0-4702-8bd0-89601f16ed75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "272aa99a-f9d4-4010-8e90-e36500895f0b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "f0dfbde5-fea2-43f3-8b38-d559fa4eea2c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "ee6e2d29-1220-4893-8e22-df4f4062f7af", "AQAAAAEAACcQAAAAEI90QdimyKR+AJMEDG0zPqvL7gNEx7x0c7c91y5be7IgHGvhPVlkOJgBoeVdpYsT8Q==", new DateTime(2023, 10, 26, 19, 8, 11, 864, DateTimeKind.Utc).AddTicks(2433), "9956f464-e4da-43b6-a8c0-603479cfcdfc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2b31ae81-54a8-4091-a0ba-4b84ca678f31", "AQAAAAEAACcQAAAAEFj/CSk+GZ2iXmNjCyWLnw6D9Fyvn/EE6NV9HFVwFXcaQIq/iOIfhrb0k06JYD6GYg==", new DateTime(2023, 10, 26, 19, 8, 11, 867, DateTimeKind.Utc).AddTicks(6658), "6e4e6701-fa42-4f13-b125-106d3c47d4fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "2afc433c-5abe-46f7-90b6-ce3bc3469612", "georgidimitov@abv.bg", "AQAAAAEAACcQAAAAEEnQ8QrfycY5pg7iTq6hbQ8t5uJfVZh7aj8nB6M0TZco1ioUq5CdwlXUYJXaxMw4Lw==", new DateTime(2023, 10, 26, 19, 8, 11, 865, DateTimeKind.Utc).AddTicks(4392), "8fa4c6c3-c7d1-47d9-b612-cd0f1fc27f02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "fcd8ae50-bbb6-4f2f-aab8-9e625f600ff6", "AQAAAAEAACcQAAAAEPrNufsaB7oYNgbP0L+pyutdO4dZ85sRrS+tad4aUKeVHZ+FfIUwxnl4+X+mmzTJLA==", new DateTime(2023, 10, 26, 19, 8, 11, 866, DateTimeKind.Utc).AddTicks(5683), "704300a8-05f6-4daa-a057-389ad78461fc" });
        }
    }
}
