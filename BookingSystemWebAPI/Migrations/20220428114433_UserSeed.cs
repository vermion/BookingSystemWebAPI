using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystemWebAPI.Migrations
{
    public partial class UserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { 1, new byte[] { 0, 0 }, new byte[] { 0, 0, 0 }, "tereng" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
