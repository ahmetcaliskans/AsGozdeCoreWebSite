using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class rolesupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialRole1Description",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SpecialRole2Description",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SpecialRole3Description",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SpecialRole4Description",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SpecialRole5Description",
                table: "Roles");

            //migrationBuilder.AddColumn<int>(
            //    name: "RoleFormDefinitionId",
            //    table: "Sp_GetRoles",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole1Description",
                table: "RoleFormDefinitions",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole2Description",
                table: "RoleFormDefinitions",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole3Description",
                table: "RoleFormDefinitions",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole4Description",
                table: "RoleFormDefinitions",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole5Description",
                table: "RoleFormDefinitions",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "RoleFormDefinitionId",
            //    table: "Sp_GetRoles");

            migrationBuilder.DropColumn(
                name: "SpecialRole1Description",
                table: "RoleFormDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole2Description",
                table: "RoleFormDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole3Description",
                table: "RoleFormDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole4Description",
                table: "RoleFormDefinitions");

            migrationBuilder.DropColumn(
                name: "SpecialRole5Description",
                table: "RoleFormDefinitions");

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole1Description",
                table: "Roles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole2Description",
                table: "Roles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole3Description",
                table: "Roles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole4Description",
                table: "Roles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRole5Description",
                table: "Roles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
