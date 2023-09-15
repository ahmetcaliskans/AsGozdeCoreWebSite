using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class driverinfirmationtableupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "DriverInformations",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CourseEndDate",
                table: "DriverInformations",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CourseStartDate",
                table: "DriverInformations",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordNumber",
                table: "DriverInformations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SessionDate",
                table: "DriverInformations",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "CourseEndDate",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "CourseStartDate",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "RecordNumber",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "SessionDate",
                table: "DriverInformations");
        }
    }
}
