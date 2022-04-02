using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystemWebAPI.Migrations
{
    public partial class First1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingTypeId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingTypeId",
                table: "Bookings",
                column: "BookingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BookingTypes_BookingTypeId",
                table: "Bookings",
                column: "BookingTypeId",
                principalTable: "BookingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BookingTypes_BookingTypeId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookingTypeId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingTypeId",
                table: "Bookings");
        }
    }
}
