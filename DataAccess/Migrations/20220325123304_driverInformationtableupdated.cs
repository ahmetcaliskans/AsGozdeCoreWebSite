using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class driverInformationtableupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "SurName",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "Surname");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNo",
                table: "DriverInformations",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "Surname",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "SurName");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNo",
                table: "DriverInformations",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }
    }
}
