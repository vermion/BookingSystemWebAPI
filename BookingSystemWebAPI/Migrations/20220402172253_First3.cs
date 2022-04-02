using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystemWebAPI.Migrations
{
    public partial class First3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Facilities_FacilityId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_FacilityId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FacilityId1",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacilityId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FacilityId1",
                table: "Bookings",
                column: "FacilityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Facilities_FacilityId1",
                table: "Bookings",
                column: "FacilityId1",
                principalTable: "Facilities",
                principalColumn: "Id");
        }
    }
}
