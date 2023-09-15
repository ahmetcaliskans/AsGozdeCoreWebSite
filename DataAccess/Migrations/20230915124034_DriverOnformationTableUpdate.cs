using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DriverOnformationTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonnelDefinitionId",
                table: "DriverInformations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverInformations_PersonnelDefinitionId",
                table: "DriverInformations",
                column: "PersonnelDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_PersonnelDefinitions_PersonnelDefinitionId",
                table: "DriverInformations",
                column: "PersonnelDefinitionId",
                principalTable: "PersonnelDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_PersonnelDefinitions_PersonnelDefinitionId",
                table: "DriverInformations");

            migrationBuilder.DropIndex(
                name: "IX_DriverInformations_PersonnelDefinitionId",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "PersonnelDefinitionId",
                table: "DriverInformations");
        }
    }
}
