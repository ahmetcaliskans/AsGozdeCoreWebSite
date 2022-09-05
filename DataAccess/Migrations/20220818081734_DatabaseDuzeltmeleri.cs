using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DatabaseDuzeltmeleri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Sp_GetRoles",
            //    table: "Sp_GetRoles");

            //migrationBuilder.AlterColumn<string>(
            //    name: "FormName",
            //    table: "Sp_GetRoles",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Sp_GetRoles",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddColumn<string>(
            //    name: "Description",
            //    table: "Sp_GetListOfExpenseByOfficeIds",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FormName",
                table: "Roles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FormName",
                table: "RoleDefinitions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);

            //migrationBuilder.CreateTable(
            //    name: "Sp_rCashReport1DetailExpenses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ExpenseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PaymentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ExpenseDefinitionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        FixtureDefinitionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PersonnelNameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Sp_rCashReport1DetailExpenses");

            //migrationBuilder.DropColumn(
            //    name: "Description",
            //    table: "Sp_GetListOfExpenseByOfficeIds");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Sp_GetRoles",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "FormName",
            //    table: "Sp_GetRoles",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FormName",
                table: "Roles",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "FormName",
                table: "RoleDefinitions",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Sp_GetRoles",
            //    table: "Sp_GetRoles",
            //    column: "Id");
        }
    }
}
