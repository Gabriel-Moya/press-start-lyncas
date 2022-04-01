using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressStartApi.Migrations
{
    public partial class SeedDataContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "Email", "Lastname", "Name", "Phone" },
                values: new object[] { 1, new DateTime(2022, 4, 1, 11, 0, 47, 588, DateTimeKind.Local).AddTicks(3347), "admin@lyncas.net", "admin", "admin", "67998456580" });

            migrationBuilder.InsertData(
                table: "Authentication",
                columns: new[] { "Id", "IsActive", "Password", "UserId" },
                values: new object[] { 1, true, "lyncas123", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authentication",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
