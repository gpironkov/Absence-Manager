using Microsoft.EntityFrameworkCore.Migrations;

namespace Jandaya.Data.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
