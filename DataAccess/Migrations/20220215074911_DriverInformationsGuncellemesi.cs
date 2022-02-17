using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DriverInformationsGuncellemesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress1",
                table: "DriverInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress2",
                table: "DriverInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "DriverInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "DriverInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone1",
                table: "DriverInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone2",
                table: "DriverInformations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress1",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "Adress2",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "City",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "County",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "Phone1",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "Phone2",
                table: "DriverInformations");
        }
    }
}
