using Microsoft.EntityFrameworkCore.Migrations;

namespace Jandaya.Data.Migrations
{
    public partial class BookingType_AddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaidTimeOff",
                table: "BookingTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubtractDaysLeft",
                table: "BookingTypes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaidTimeOff",
                table: "BookingTypes");

            migrationBuilder.DropColumn(
                name: "IsSubtractDaysLeft",
                table: "BookingTypes");
        }
    }
}
