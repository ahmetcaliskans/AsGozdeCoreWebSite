using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class roledefinitiontablenamechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_RoleDefinitions_RoleFormDefinitionId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleDefinitions",
                table: "RoleDefinitions");

            migrationBuilder.RenameTable(
                name: "RoleDefinitions",
                newName: "RoleFormDefinitions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleFormDefinitions",
                table: "RoleFormDefinitions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_RoleFormDefinitions_RoleFormDefinitionId",
                table: "Roles",
                column: "RoleFormDefinitionId",
                principalTable: "RoleFormDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_RoleFormDefinitions_RoleFormDefinitionId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleFormDefinitions",
                table: "RoleFormDefinitions");

            migrationBuilder.RenameTable(
                name: "RoleFormDefinitions",
                newName: "RoleDefinitions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleDefinitions",
                table: "RoleDefinitions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_RoleDefinitions_RoleFormDefinitionId",
                table: "Roles",
                column: "RoleFormDefinitionId",
                principalTable: "RoleDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
