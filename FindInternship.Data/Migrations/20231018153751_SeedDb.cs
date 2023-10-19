using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Classes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03f3054b-c9a2-4198-a6c9-a96f3142ff53", "4cc2c52b-bb2d-4849-8c46-dffc3115a4d4", "Student", "STUDENT" },
                    { "36ae84ad-bb53-48ad-9503-bfe33221785d", "9a72560f-7706-4eb5-aec7-e153dc096e53", "Teacher", "TEACHER" },
                    { "e2f6cb22-631b-47c7-9ac0-19f89455b2a5", "38464e66-aa35-4894-8e38-dedc66d879da", "Admin", "ADMIN" },
                    { "e6fc051f-3440-4f69-89e1-8a696c027fc2", "6940e04e-9e3d-4cf7-ae41-7aadbbec445f", "Company", "COMPANY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "Gender", "IsActive", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "RegisteredOn", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "080a469a-b5a2-44cc-a660-eea8e6fd05a5", 0, "ул. Ал. Стамболийски 30 ет.3 ап.11", new DateTime(2008, 4, 12, 13, 24, 0, 0, DateTimeKind.Unspecified), "Казанлък", "639386f6-47c2-4f16-a39d-b71e33e985b0", "България", "petarpetrov@abv.bg", false, "Мъж", true, false, null, "Петър Петров", "PETARPETROV@ABV.BG", "PETAR", "AQAAAAEAACcQAAAAEMc3lK6YBPZfqVBwziiN0WOV+sI2tej9x7tHoYgNHtq8rKE/KPO27ExzEj8CDWhmVA==", "0885763826", false, "https://res.cloudinary.com/ddriqreo7/image/upload/v1697607303/projectImages/xbhwflepot9qpwmiiq6u.jpg", new DateTime(2023, 10, 18, 15, 37, 51, 40, DateTimeKind.Utc).AddTicks(4290), "847f8423-5042-43cc-a6c6-62f4b099ec30", false, "petar" },
                    { "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8", 0, "ул. Незабравка 3", new DateTime(2015, 7, 18, 11, 20, 0, 0, DateTimeKind.Unspecified), "Енина", "d7f9de51-c12b-4258-9e91-a55dadff2ebc", "България", "admin@abv.bg", false, "Мъж", true, false, null, "Admin", "ADMIN@ABV.BG", "ADMIN", "AQAAAAEAACcQAAAAEKH4tEQjFZ6jFnleCj4JitjNfNMoU3svB2BZQzT9Eg73OuKG4L3LxjLLvc1y0ShahA==", "0889864842", false, "https://res.cloudinary.com/ddriqreo7/image/upload/v1697617373/projectImages/pyb6v86l6myou9h1sxca.jpg", new DateTime(2023, 10, 18, 15, 37, 51, 43, DateTimeKind.Utc).AddTicks(8154), "bc32f0b8-5dca-452c-9543-417119c38d72", false, "Admin" },
                    { "93418f37-da3b-4c78-b0ae-8f0022b09681", 0, "ул.Възраждане 6 ет.2 ап.8", new DateTime(1968, 2, 8, 11, 20, 0, 0, DateTimeKind.Unspecified), "Казанлък", "bf9b01c8-454d-4331-855c-6567ab437f35", "България", "georgidimitov@abv.bg", false, "Мъж", true, false, null, "Георги Димитров", "GEORGIDIMITROV@ABV.BG", "GEORGI", "AQAAAAEAACcQAAAAEHDJyXrMyGPgFafqLklGAHdXS/zKJlN3pwsrq64nxh4BTmTwEbOszevbWDfZdM7eBg==", "0885789826", false, "https://res.cloudinary.com/ddriqreo7/image/upload/v1697608565/projectImages/mvorrsshjbw1e8bzfzgq.jpg", new DateTime(2023, 10, 18, 15, 37, 51, 41, DateTimeKind.Utc).AddTicks(5401), "51a33fe7-ffa9-4e2a-b633-c24fde6acaf2", false, "georgi" },
                    { "cb5ee792-90f6-4e50-8af1-da2f99d9f892", 0, "ул. Стара планина 63", new DateTime(2015, 5, 9, 11, 20, 0, 0, DateTimeKind.Unspecified), "Казанлък", "e661243f-134a-4135-bd12-5d13547039d7", "България", "newtechies@abv.bg", false, null, true, false, null, "New Techies", "NEWTECHIES@ABV.BG", "NEWTECHIES", "AQAAAAEAACcQAAAAEK9ZGzYQfuxl55XLNuuw4EIVMSC+8npYLtESJlSkbkSB1uU1beRYChjtEAPxCVKQvQ==", "0885789546", false, "https://res.cloudinary.com/ddriqreo7/image/upload/v1697617040/projectImages/n775bghppizokr5xifn4.png", new DateTime(2023, 10, 18, 15, 37, 51, 42, DateTimeKind.Utc).AddTicks(7196), "60bf63f2-225d-4135-acb7-7f10e5b98d8c", false, "NewTechies" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "CompanyId", "Grade", "School", "Speciality", "TeacherId" },
                values: new object[] { "0edc45cb-b2f1-48a2-8f6b-17910e09a147", null, "12 Б", "ППМГ Никола Обрешков", "Приложен програмист", "2644afb5-f916-4b3f-b451-9ff86c881de3" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "03f3054b-c9a2-4198-a6c9-a96f3142ff53", "080a469a-b5a2-44cc-a660-eea8e6fd05a5" },
                    { "e2f6cb22-631b-47c7-9ac0-19f89455b2a5", "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8" },
                    { "36ae84ad-bb53-48ad-9503-bfe33221785d", "93418f37-da3b-4c78-b0ae-8f0022b09681" },
                    { "e6fc051f-3440-4f69-89e1-8a696c027fc2", "cb5ee792-90f6-4e50-8af1-da2f99d9f892" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassId", "UserId" },
                values: new object[] { "30b28597-2305-4f3b-a21a-95b287cae818", "0edc45cb-b2f1-48a2-8f6b-17910e09a147", "080a469a-b5a2-44cc-a660-eea8e6fd05a5" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassId", "UserId" },
                values: new object[] { "2644afb5-f916-4b3f-b451-9ff86c881de3", "0edc45cb-b2f1-48a2-8f6b-17910e09a147", "93418f37-da3b-4c78-b0ae-8f0022b09681" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "03f3054b-c9a2-4198-a6c9-a96f3142ff53", "080a469a-b5a2-44cc-a660-eea8e6fd05a5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e2f6cb22-631b-47c7-9ac0-19f89455b2a5", "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "36ae84ad-bb53-48ad-9503-bfe33221785d", "93418f37-da3b-4c78-b0ae-8f0022b09681" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6fc051f-3440-4f69-89e1-8a696c027fc2", "cb5ee792-90f6-4e50-8af1-da2f99d9f892" });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "30b28597-2305-4f3b-a21a-95b287cae818");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "2644afb5-f916-4b3f-b451-9ff86c881de3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892");

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: "0edc45cb-b2f1-48a2-8f6b-17910e09a147");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Classes");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Classes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
