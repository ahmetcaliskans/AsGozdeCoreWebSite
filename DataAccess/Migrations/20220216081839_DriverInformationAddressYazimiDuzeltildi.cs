using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DriverInformationAddressYazimiDuzeltildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress2",
                table: "DriverInformations",
                newName: "Address2");

            migrationBuilder.RenameColumn(
                name: "Adress1",
                table: "DriverInformations",
                newName: "Address1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address2",
                table: "DriverInformations",
                newName: "Adress2");

            migrationBuilder.RenameColumn(
                name: "Address1",
                table: "DriverInformations",
                newName: "Adress1");
        }
    }
}
