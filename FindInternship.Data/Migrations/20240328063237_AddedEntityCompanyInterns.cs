using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class AddedEntityCompanyInterns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyInternsId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyInterns",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInterns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyInterns_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyInterns_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "6f249264-4ef2-496b-ac0d-971b0710c68a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "690b3336-c6b0-4abd-995c-e196d45bc507");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "f3c9a9e4-b29b-49a0-a35a-972f2e64de8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "745ed2cb-ec3d-45f3-85ca-8f6bff57bd43");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "6a8a70cc-c6bf-4e9b-808c-09c15692fdc3", "AQAAAAEAACcQAAAAEIRA/0dWQnMIho06SKagl6eEVvs8YR8Sv7ty4Iz3cQLGP/plYSz7UhuUTzXe4EiHpw==", new DateTime(2024, 3, 28, 6, 32, 37, 74, DateTimeKind.Utc).AddTicks(8419), "052267ca-e98b-46a9-9780-eb594afb88d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "96177a96-94b7-43ad-8f6a-a8ebfcc15dfc", "AQAAAAEAACcQAAAAECk8ixrhYubxMbT+KsVJVhjXmK6o+aNakcDWoYebz7HC8vS2DblYLgwxBGBW9+sIoQ==", new DateTime(2024, 3, 28, 6, 32, 37, 80, DateTimeKind.Utc).AddTicks(80), "0910c396-b7e7-4df2-bb43-b03b2fdb8fff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "050e4325-37b4-4e79-a4b3-c73f186c0ee9", "AQAAAAEAACcQAAAAEOlNm3osuxpQ3kqvnGSulMBlViIPNi0h3avn2doyEhg3sjfViofOwZKPJj8bb2/sOg==", new DateTime(2024, 3, 28, 6, 32, 37, 77, DateTimeKind.Utc).AddTicks(9106), "b1d308d5-e478-4f75-b2d6-8540a8f08a96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "01f3dab9-ffc4-40a6-bf1e-dfd95f51e04c", "AQAAAAEAACcQAAAAEO/IKJoWN0MPB+q1OISurttV0QwDN4VgI66JdRwCu2OO1nZcdIrlTE/98VvVDlVXJA==", new DateTime(2024, 3, 28, 6, 32, 37, 78, DateTimeKind.Utc).AddTicks(9594), "fc191dd6-8215-4b18-b9d2-60e908d293e0" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CompanyInternsId",
                table: "Students",
                column: "CompanyInternsId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInterns_CompanyId",
                table: "CompanyInterns",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInterns_TeacherId",
                table: "CompanyInterns",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_CompanyInterns_CompanyInternsId",
                table: "Students",
                column: "CompanyInternsId",
                principalTable: "CompanyInterns",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_CompanyInterns_CompanyInternsId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "CompanyInterns");

            migrationBuilder.DropIndex(
                name: "IX_Students_CompanyInternsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CompanyInternsId",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "3229e2b5-2472-4269-b185-f0ab0cf0ea46");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "877d8099-f2df-4ee8-86c6-8e5d33e5e7c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "a055007b-d58d-4509-8682-bf7fee4fc643");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "c8dcce8f-60f7-479f-95f3-84a6af3b1626");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "156a1415-d3bd-42a4-b19f-151832c4ec49", "AQAAAAEAACcQAAAAEHdCuybyKBvgviPseNZEieLGwEAgsUh45SW4nKjSIpDFQABGalVXY7FjvVcVJUqIXw==", new DateTime(2024, 3, 5, 7, 20, 40, 44, DateTimeKind.Utc).AddTicks(1236), "db01f74f-3018-4d6a-b408-b974a046a204" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "9a6363d4-8130-43a9-8026-4ce72732e926", "AQAAAAEAACcQAAAAEKBwS4yqQ+81F7CczB5MAVHnit5imY9S9BCUXTr8FRZtIL/mvLD3BI0EXHYBX1a6bA==", new DateTime(2024, 3, 5, 7, 20, 40, 49, DateTimeKind.Utc).AddTicks(3907), "c832e96d-a271-46b9-9fb7-9ada0e21f710" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "fc873e52-d123-4796-b44e-2358c1aaa5a0", "AQAAAAEAACcQAAAAEI8Wk51LjxRNXuj8nWollLTHaj4zMEavBjvGPid1I/BCqTxmLzdTIrmgYOCozrjOrQ==", new DateTime(2024, 3, 5, 7, 20, 40, 47, DateTimeKind.Utc).AddTicks(2923), "b51c8210-ceca-4dce-81ce-ad4a04629b5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "47d40efe-6bbe-4fc4-acdb-e0785b0a6de8", "AQAAAAEAACcQAAAAECyQ5Z6ikb9O+lnrJnxA+Baocp6fCifaQm0xteGOMJmiP9c7LdWrHnkus5Bedcds0g==", new DateTime(2024, 3, 5, 7, 20, 40, 48, DateTimeKind.Utc).AddTicks(3780), "12d0561b-4fbc-44c1-9e29-261c46edf034" });
        }
    }
}
