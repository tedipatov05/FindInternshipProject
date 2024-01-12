using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindInternship.Data.Migrations
{
    public partial class RemoveChatMessageMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "8626e057-3e7d-41b0-9ece-5d637bf61e17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "8d266d48-afd4-412a-aff5-8bee105ff991");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "cecf1275-92cb-48ec-a5d0-9c22806a7d5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "95234ed3-b41e-4511-8cf9-8c68bf1ba50b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "e1a55d8d-2293-4289-8e4d-d1675efc0b15", "AQAAAAEAACcQAAAAEDhDjmw7EMS0VqO8GPSCbYH31s3oCL9k1EFq2l2n77Q5jemVCOfbr+PyUUBa6fT52g==", new DateTime(2024, 1, 12, 8, 8, 31, 526, DateTimeKind.Utc).AddTicks(3106), "06f3f788-c5c0-44af-86f1-7d2bcb8b6dd0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "cbd4eb55-a082-46a2-a48f-fe0eb2638a94", "AQAAAAEAACcQAAAAEE4U2ql3fVVsGF/XRaSWXznEBw0Y9lqT7JIa4imEtKfII8eU5clWy4oPTf5+PFw/8w==", new DateTime(2024, 1, 12, 8, 8, 31, 529, DateTimeKind.Utc).AddTicks(8153), "361f0bc8-6154-4630-b501-85f9cbc14c9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "8cbe4318-9432-4c25-a6cd-9e66f3b2e00f", "AQAAAAEAACcQAAAAEO5D/ZvxEz8rCXMUSY8ZjZGjV6t+ghu3LPEq2tLRJNuCeWlASsfnOzG9jKukT7zmNg==", new DateTime(2024, 1, 12, 8, 8, 31, 527, DateTimeKind.Utc).AddTicks(5834), "7a1138cf-3473-4d22-894b-f94c1f44a8cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "03d19166-5b99-4dfb-a234-d06d139d8fc8", "AQAAAAEAACcQAAAAEDMM9CRoUeGnHxfov+2jjHlZfXGh1zZ/sEhASG4XPuIbXnuXQ9TlrTnvwpfyCq/iEg==", new DateTime(2024, 1, 12, 8, 8, 31, 528, DateTimeKind.Utc).AddTicks(6902), "14135e13-12c5-41f8-b68f-56af25309497" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "ChatMessages",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f3054b-c9a2-4198-a6c9-a96f3142ff53",
                column: "ConcurrencyStamp",
                value: "20ec695e-50af-447b-844f-68dcb80ae42b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ae84ad-bb53-48ad-9503-bfe33221785d",
                column: "ConcurrencyStamp",
                value: "d2ff790a-4824-4786-a69f-7017c296389a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6cb22-631b-47c7-9ac0-19f89455b2a5",
                column: "ConcurrencyStamp",
                value: "e3a888aa-8672-45a2-b1c2-2f7ab75a4a47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fc051f-3440-4f69-89e1-8a696c027fc2",
                column: "ConcurrencyStamp",
                value: "c2bb937c-78ef-464e-9410-487bbd49075b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "ac6b1bcf-2386-4509-a3a8-e4387fd5d02a", "AQAAAAEAACcQAAAAEGFoOC4tnOYaEwED8BcRW29eXv/9pgPUp+f0PbYqLBQtGKiP/l6tMHA6dX1mSDlMnQ==", new DateTime(2023, 12, 31, 10, 12, 46, 566, DateTimeKind.Utc).AddTicks(4627), "78a56c8e-9771-429d-a354-d6e755c31904" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20dcf707-dfd9-4aae-b8c3-f3b9844e09d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "be10f2fe-9b3a-4d3f-89f6-8106cdd46ee6", "AQAAAAEAACcQAAAAEDw/51D0p5UkB5J1o29I6UWj19lKfwdg+c3TM+tX3n4SM+FpCZcE3s5/ygAS+BKU0Q==", new DateTime(2023, 12, 31, 10, 12, 46, 570, DateTimeKind.Utc).AddTicks(9650), "24103a0f-efe7-42f3-9b48-dd03fed1d92b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93418f37-da3b-4c78-b0ae-8f0022b09681",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "731b9fd0-9b9a-4bf9-b24f-ddd586dbf509", "AQAAAAEAACcQAAAAEKPP9jKl7o2KHdbI/b2ZeMPYd8nQ+BAum7GsGmFMlJPojBRTAafKahNceuS3PdcY1g==", new DateTime(2023, 12, 31, 10, 12, 46, 567, DateTimeKind.Utc).AddTicks(9542), "a36814cb-4d7f-453e-ba31-e024f5c45f1e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisteredOn", "SecurityStamp" },
                values: new object[] { "30b7c224-bed0-4ea2-be63-966d1d79838d", "AQAAAAEAACcQAAAAEDE8XJsrYman9Su4W6mVnFM/OAjlf6vnSnwndTW5+ca5rMFJDjGxJjBCXydKGhT5fA==", new DateTime(2023, 12, 31, 10, 12, 46, 569, DateTimeKind.Utc).AddTicks(4796), "5e7a5a00-c426-4602-a248-771bfceab27f" });
        }
    }
}
