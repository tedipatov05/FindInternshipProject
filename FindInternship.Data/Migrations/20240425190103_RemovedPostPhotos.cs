using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class RemovedPostPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostsPhotos");

            migrationBuilder.AddColumn<string>(
                name: "PostId",
                table: "Photos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "54a78b9c-5cf4-48ea-aa09-616dfeb6f321");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "7d14dcd2-3f62-49db-8366-03616488c307");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "2d494c12-1d9c-46de-b0ca-617547c7dba3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "4b183fd4-49bc-478a-a3ae-280f9c79fea6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "edd0504e-4223-4aab-9606-60a17301f07d", "AQAAAAEAACcQAAAAEB9G48d4Q4iDDDCr2Im79i6DFLuG2I0JwszsiYe2ojUf4FB5kEjAPLXwQqQS24dQlA==", new DateTime(2024, 4, 25, 19, 1, 2, 672, DateTimeKind.Utc).AddTicks(1205), "e6789d73-61c1-4bf0-9539-925da8937187" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "76aae069-8c59-48ff-a825-c61f46b664ca", "AQAAAAEAACcQAAAAEHpxybxVe8bgbtbSV3K1tvR1qm825NyBveXkAJV7X7eYQjdjs/8eF4SQ3nIdHQc3Yw==", new DateTime(2024, 4, 25, 19, 1, 2, 678, DateTimeKind.Utc).AddTicks(7455), "b316699d-96a5-4516-bf9e-bb0a366aeae8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "aef10dd3-3e94-4229-9c06-ddfb95b386c2", "AQAAAAEAACcQAAAAEBQ9BFt2mvwk2XBY+JX3PCL0PSTd3s2Ec0+vM2A3m79EN4cHtUunIQto8u84k8uFug==", new DateTime(2024, 4, 25, 19, 1, 2, 676, DateTimeKind.Utc).AddTicks(5927), "a2b23244-83b8-481a-9a80-d016b6917de0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "ae4f56f4-2423-47c5-919b-626499fc8c68", "AQAAAAEAACcQAAAAEAQGoOJIfiW9m+6kQRI315yKHTaei2j58IA+Stal8GBbs06yfgmBL0EdJJGnioO6Zw==", new DateTime(2024, 4, 25, 19, 1, 2, 677, DateTimeKind.Utc).AddTicks(7127), "cf1d6640-eb1c-4fe0-9b91-d801937a5189" });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PostId",
                table: "Photos",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PostId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Photos");

            migrationBuilder.CreateTable(
                name: "PostsPhotos",
                columns: table => new
                {
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhotoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsPhotos", x => new { x.PostId, x.PhotoId });
                    table.ForeignKey(
                        name: "FK_PostsPhotos_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostsPhotos_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PostsPhotos_PhotoId",
                table: "PostsPhotos",
                column: "PhotoId");
        }
    }
}
