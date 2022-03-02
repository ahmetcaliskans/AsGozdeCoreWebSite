using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class releatedtableofficeupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Offices_OfficeId",
                table: "DriverInformations");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_Offices_OfficeId",
                table: "DriverInformations",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Offices_OfficeId",
                table: "DriverInformations");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_Offices_OfficeId",
                table: "DriverInformations",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
