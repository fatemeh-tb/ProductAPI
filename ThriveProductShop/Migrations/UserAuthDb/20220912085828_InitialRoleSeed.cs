using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriveProductShop.Migrations.UserAuthDb
{
    public partial class InitialRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0565e79-0130-43f1-8575-78b6fd3fbbdb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cab25f93-716b-409d-ac7b-73044359b2a4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12105dfb-ef02-4bcc-b6a5-2a3f29c5f2e4", "a33554bc-759a-47c0-a716-ca509f8ba07c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49b435ab-8934-401e-b27b-5f26d6651a6f", "e2c0aca0-4100-483c-a2a2-00c6b8194ab2", "Fatemeh", "FATEMEH" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12105dfb-ef02-4bcc-b6a5-2a3f29c5f2e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49b435ab-8934-401e-b27b-5f26d6651a6f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0565e79-0130-43f1-8575-78b6fd3fbbdb", "02b436a4-f76a-4d92-b249-f859f1977a00", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cab25f93-716b-409d-ac7b-73044359b2a4", "328dc714-50c3-48e1-a884-4d7284b4c0c0", "Fatemeh", "FATEMEH" });
        }
    }
}
