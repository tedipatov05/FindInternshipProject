using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class MeetingIsOnlineProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Meetings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "Meetings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "9af3f575-8941-406d-be0d-1558d975347c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "009a2155-0ae9-4f98-af4b-7c37d223bea6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "d9fe3c83-287d-4162-9f15-0af0b4cc57d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "a8f5ad7a-d51f-402c-abf6-e27c52dd5f39");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "18377906-db5b-44da-b8ad-e0adf61da8fe", "AQAAAAEAACcQAAAAEBxP5tPsTdfpp9MkHawWyv4rM57DTyNQb1I3CUbfPl3/X4f98bY+dWSCcM+Xyvi9FA==", new DateTime(2024, 4, 11, 6, 55, 8, 426, DateTimeKind.Utc).AddTicks(4081), "2b864c23-cdef-4616-8618-82be55bb26cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "d5c30cbc-4864-4403-aaa1-4a5c38f5d1c9", "AQAAAAEAACcQAAAAEGLA7ZIcha/xJxDtjKTO7q5rCWIUy9m7lWFlF2cEKQx5GdcBtBvHrYbCncz2lOj4pg==", new DateTime(2024, 4, 11, 6, 55, 8, 431, DateTimeKind.Utc).AddTicks(6536), "ac7a2987-882f-47d3-9bb4-89694b66576f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "9e3f208e-bed7-4749-831f-68f51f82a3cc", "AQAAAAEAACcQAAAAEHMTi5RtANpc1r3NTHUjtKRdFhvquKF9mpM7ZgqNQQAwvmruZl0xuW44XpBMAqKjzg==", new DateTime(2024, 4, 11, 6, 55, 8, 429, DateTimeKind.Utc).AddTicks(6103), "06cd3b26-04e4-42c4-8d8e-83924a0dca94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "7008b62e-ccc8-4ad2-be44-e92e2fe1b7e7", "AQAAAAEAACcQAAAAEDSJ060wJ428X7uLZ9+6fkoKI4Vx1G/9vHrtKwmWtqBmVqivqM/mUCEfxLCoHxo3ZQ==", new DateTime(2024, 4, 11, 6, 55, 8, 430, DateTimeKind.Utc).AddTicks(6946), "59e16f00-5e6d-4c95-b5cd-2b0acfd5319d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "Meetings");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Meetings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "d97edc97-66d2-45fc-a459-43040b01ef80");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "908d7921-fd35-4f86-a760-0a6f1d32ce66");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "d8903531-d6f1-49f3-93cc-9259806c39b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "d7123da8-7d48-420c-a9fb-979a19aa1e5f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "6a673668-6c20-46bf-9a39-a7c0c3576f78", "AQAAAAEAACcQAAAAECelpDJSX6bmR6qqt9+PewBwwyv/9gbFwwToVF8xvM24yJIud8/EYjmjth9puRUfsw==", new DateTime(2024, 4, 11, 5, 16, 54, 654, DateTimeKind.Utc).AddTicks(6196), "e5982f74-4e85-4730-aeda-c59a72f32df3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "4dc681a1-f827-4c23-8e1b-a3258f3e6ffa", "AQAAAAEAACcQAAAAEHnvAyCNg53w/+8pXHHOUrn7FIUfKnPuvubUwQSoq5ZANsSGcDNiXdd/+E4PBnmGSA==", new DateTime(2024, 4, 11, 5, 16, 54, 674, DateTimeKind.Utc).AddTicks(7820), "adcad4a5-9874-4c53-afd7-b89517e8961f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "9c0cea2f-9e05-42f6-9318-f59658fa82ac", "AQAAAAEAACcQAAAAEBuUsEd4HNohfWMvS7Ysz3jnLOMPE/RNEP1L4Vj/dgy0SjWhcfXKWEKYSZH901ZOdw==", new DateTime(2024, 4, 11, 5, 16, 54, 672, DateTimeKind.Utc).AddTicks(5536), "d00afbb5-3163-4654-882c-0ae6be379278" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "12e04436-c371-4ef6-a1ee-45f184f10514", "AQAAAAEAACcQAAAAEDucrYVUS5Gqz+ymRxc5IRwRN4iplMMI+n6BzrAy+MOx1NTpFK8jfUJyacxkpW1UeQ==", new DateTime(2024, 4, 11, 5, 16, 54, 673, DateTimeKind.Utc).AddTicks(7033), "2e649e62-15a3-435c-bb4a-653d37b9afd1" });
        }
    }
}
