using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class OfficeAdressveDigerAlanlarGuncellemesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone1",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone2",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxOfficeName",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxOfficeNo",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TradeRegisterNumber",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebAddress",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "Phone1",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "Phone2",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "TaxOfficeName",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "TaxOfficeNo",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "TradeRegisterNumber",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "WebAddress",
                table: "Offices");
        }
    }
}
