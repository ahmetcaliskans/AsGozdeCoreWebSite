using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class roletablesupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_RoleTypes_RoleTypeId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "FormName",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "FormSubName",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "Export",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "Insert",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "Print",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "Show",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole1",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole1Description",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole2",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole2Description",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole3",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole3Description",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole4",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole4Description",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole5",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole5Description",
                table: "RoleDefinitions");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "RoleDefinitions");

            migrationBuilder.AddColumn<int>(
                name: "RoleFormDefinitionId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleFormDefinitionId",
                table: "Roles",
                column: "RoleFormDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_RoleDefinitions_RoleFormDefinitionId",
                table: "Roles",
                column: "RoleFormDefinitionId",
                principalTable: "RoleDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_RoleTypes_RoleTypeId",
                table: "Roles",
                column: "RoleTypeId",
                principalTable: "RoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_RoleDefinitions_RoleFormDefinitionId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_RoleTypes_RoleTypeId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleFormDefinitionId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleFormDefinitionId",
                table: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormName",
                table: "Roles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormSubName",
                table: "Roles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "RoleDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Export",
                table: "RoleDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Insert",
                table: "RoleDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Print",
                table: "RoleDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Show",
                table: "RoleDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SpecialRole1",
                table: "RoleDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole1Description",
                table: "RoleDefinitions",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SpecialRole2",
                table: "RoleDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole2Description",
                table: "RoleDefinitions",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SpecialRole3",
                table: "RoleDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole3Description",
                table: "RoleDefinitions",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SpecialRole4",
                table: "RoleDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole4Description",
                table: "RoleDefinitions",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SpecialRole5",
                table: "RoleDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole5Description",
                table: "RoleDefinitions",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Update",
                table: "RoleDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_RoleTypes_RoleTypeId",
                table: "Roles",
                column: "RoleTypeId",
                principalTable: "RoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
