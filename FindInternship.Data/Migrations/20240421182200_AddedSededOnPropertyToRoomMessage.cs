using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedSededOnPropertyToRoomMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SendedOn",
                table: "RoomMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "c9ec7f05-7c7a-423b-b2cf-d917f7031a4c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "8be49829-56ea-45d9-b44f-af33ad83482e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "cec87f41-1aa9-48b7-9fce-82da4a04a16f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "01da7285-b8e0-4f97-99ba-196a8237ed07");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "e997e5c3-4877-40b7-a304-06bf14828f10", "AQAAAAEAACcQAAAAEM4OqFlO041lWLsSGdRVZdz6x+iM48SIg9kJVZVcTyWp7E/Ah8+GcUs4xfa4ArB0Og==", new DateTime(2024, 4, 21, 18, 22, 0, 332, DateTimeKind.Utc).AddTicks(485), "22d2ec97-89f9-43a4-a2ab-954c7747dcc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "1ef4c120-bccf-4211-9ff4-8fa32ebede66", "AQAAAAEAACcQAAAAEOWnW9a9fO6VZw7AnIPb1MkBuwq/pi9z0wW0IZdKfG+e0QAjnyydfDKL5AgaFodcqQ==", new DateTime(2024, 4, 21, 18, 22, 0, 337, DateTimeKind.Utc).AddTicks(4886), "1eac4873-45d6-4942-8379-d2c4d283f339" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "c06f5bcd-f662-40e9-86da-b0b0f77360dd", "AQAAAAEAACcQAAAAENb+5UML3yU2cagYjZEmISCGvw50BFEfJZydbbQhzGGaAbKiBl5GSKcH8mj/qFL/IQ==", new DateTime(2024, 4, 21, 18, 22, 0, 335, DateTimeKind.Utc).AddTicks(3345), "69885633-e6a4-4877-a74a-3ef0249a4a73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "f44aca43-5fa2-40b7-afcb-f24206951813", "AQAAAAEAACcQAAAAEKaadEwTTozy3HchKsd1JN8Rl0YGQwp+Y+W+bov5yZxz+SMyhvcmvshnrNZ7jHCCdA==", new DateTime(2024, 4, 21, 18, 22, 0, 336, DateTimeKind.Utc).AddTicks(4960), "5324ae01-d5bb-4f27-ba55-6aca449a4e50" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendedOn",
                table: "RoomMessages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "cd35717d-194b-438d-9ddc-ebafaa3bcc23");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "fb62bbc2-304e-4188-9b43-e2ee2be3e2ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "c0f5e676-4243-4d52-a7d6-2d4ba5b15ba5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "3da92204-baec-4611-b31d-61db4e632264");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "3508ef18-6637-4e47-a0c7-5a266bc331e5", "AQAAAAEAACcQAAAAEGW4vd5LASBJIdNVmDVlWruA+H5KwxDNyk3IVxAsM2BSE9Q7VLzVFdK/pTmhYyJOvA==", new DateTime(2024, 4, 21, 17, 58, 16, 699, DateTimeKind.Utc).AddTicks(9237), "0382f75c-bd33-428e-b019-aa3949d22726" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "814293c4-2ec4-4dbf-9b43-291f50f29dde", "AQAAAAEAACcQAAAAEAFbJeSUJ/gSAlwG31ZbevIWqIVxQed9iDnFO+4/ho+F/WDRHMWasZtF/oMBk5AeTw==", new DateTime(2024, 4, 21, 17, 58, 16, 706, DateTimeKind.Utc).AddTicks(7135), "4a2abe6e-a740-4af4-82dc-305440361f0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "ccd537ed-1b3e-4ab4-8659-2aedbee7dc59", "AQAAAAEAACcQAAAAEActHJrpymy4cnik49WTOt7Pf+DsJqEGwTxrSBz1rgdwTwVKXbTaBtlD2VW03Sq3ng==", new DateTime(2024, 4, 21, 17, 58, 16, 704, DateTimeKind.Utc).AddTicks(6217), "409ae5f9-5dc3-4284-89f3-1176fbca2019" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "fa472868-6229-4e19-a3ad-b113be0bee15", "AQAAAAEAACcQAAAAEFI5fsdq1EWy7gPVmipbrQV/1xhduC+gyIrCAStBlOY4Xq4tNS3uyKP+5xLvX8wgNg==", new DateTime(2024, 4, 21, 17, 58, 16, 705, DateTimeKind.Utc).AddTicks(7003), "115568f7-bc01-4f2b-a65d-e49c8414fb26" });
        }
    }
}
