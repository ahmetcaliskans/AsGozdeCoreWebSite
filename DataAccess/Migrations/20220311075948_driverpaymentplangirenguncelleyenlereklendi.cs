using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class driverpaymentplangirenguncelleyenlereklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDatetime",
                table: "DriverPaymentPlans",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AddedUserName",
                table: "DriverPaymentPlans",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDatetime",
                table: "DriverPaymentPlans",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUserName",
                table: "DriverPaymentPlans",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDatetime",
                table: "DriverPaymentPlans");

            migrationBuilder.DropColumn(
                name: "AddedUserName",
                table: "DriverPaymentPlans");

            migrationBuilder.DropColumn(
                name: "UpdatedDatetime",
                table: "DriverPaymentPlans");

            migrationBuilder.DropColumn(
                name: "UpdatedUserName",
                table: "DriverPaymentPlans");
        }
    }
}
