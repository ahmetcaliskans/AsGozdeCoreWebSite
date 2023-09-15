using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class PersonnelDefinitionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "PersonnelDefinitions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMasterTrainer",
                table: "PersonnelDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsMasterTrainer",
                table: "PersonnelDefinitions");
        }
    }
}
