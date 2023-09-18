using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DriverInformationPersonnelDefinitionOfficeTablesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonnelDefinitions_Branches_BranchId",
                table: "PersonnelDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_PersonnelDefinitions_BranchId",
                table: "PersonnelDefinitions");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "PersonnelDefinitions");

            migrationBuilder.AddColumn<string>(
                name: "BranchFileNo",
                table: "PersonnelDefinitions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchsName",
                table: "PersonnelDefinitions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceofBranchFileGiven",
                table: "PersonnelDefinitions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Offices",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "DriverInformations",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "DriverInformations",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchFileNo",
                table: "PersonnelDefinitions");

            migrationBuilder.DropColumn(
                name: "BranchsName",
                table: "PersonnelDefinitions");

            migrationBuilder.DropColumn(
                name: "PlaceofBranchFileGiven",
                table: "PersonnelDefinitions");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "DriverInformations");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "PersonnelDefinitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelDefinitions_BranchId",
                table: "PersonnelDefinitions",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonnelDefinitions_Branches_BranchId",
                table: "PersonnelDefinitions",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
