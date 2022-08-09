using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class updatedatabaseExpenseDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsVehicleSelectionRequired",
                table: "ExpenseDefinitions",
                newName: "IsPersonnelSelectionRequired");

            migrationBuilder.RenameColumn(
                name: "IsVehicleCanBeSelected",
                table: "ExpenseDefinitions",
                newName: "IsPersonnelCanBeSelected");

            migrationBuilder.RenameColumn(
                name: "IsPersonelSelectionRequired",
                table: "ExpenseDefinitions",
                newName: "IsFixtureSelectionRequired");

            migrationBuilder.RenameColumn(
                name: "IsPersonelCanBeSelected",
                table: "ExpenseDefinitions",
                newName: "IsFixtureCanBeSelected");

            //migrationBuilder.CreateTable(
            //    name: "Sp_GetListOfExpenseByOfficeIds",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ExpenseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PaymentTypeId = table.Column<int>(type: "int", nullable: false),
            //        PaymentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        ExpenseDefinitionId = table.Column<int>(type: "int", nullable: false),
            //        ExpenseDefinitionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ExpenseDefinitionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        FixtureDefinitionId = table.Column<int>(type: "int", nullable: true),
            //        FixtureDefinitionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        FixtureDefinitionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PersonnelDefinitionId = table.Column<int>(type: "int", nullable: true),
            //        NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IdentityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        OfficeId = table.Column<int>(type: "int", nullable: false),
            //        OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Sp_GetListOfExpenseByOfficeIds");

            migrationBuilder.RenameColumn(
                name: "IsPersonnelSelectionRequired",
                table: "ExpenseDefinitions",
                newName: "IsVehicleSelectionRequired");

            migrationBuilder.RenameColumn(
                name: "IsPersonnelCanBeSelected",
                table: "ExpenseDefinitions",
                newName: "IsVehicleCanBeSelected");

            migrationBuilder.RenameColumn(
                name: "IsFixtureSelectionRequired",
                table: "ExpenseDefinitions",
                newName: "IsPersonelSelectionRequired");

            migrationBuilder.RenameColumn(
                name: "IsFixtureCanBeSelected",
                table: "ExpenseDefinitions",
                newName: "IsPersonelCanBeSelected");
        }
    }
}
