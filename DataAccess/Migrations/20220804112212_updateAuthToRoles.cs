using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class updateAuthToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AuthorizationTypes_AuthorizationTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AuthorizationDefinitions");

            migrationBuilder.DropTable(
                name: "Authorizations");

            //migrationBuilder.DropTable(
            //    name: "Sp_GetAuthorizations");

            migrationBuilder.DropTable(
                name: "AuthorizationTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_AuthorizationTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthorizationTypeId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "RoleTypeId");

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsCertificateDelivered",
            //    table: "Sp_GetListOfDriverInformationByOfficeIds",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RoleDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    FormSubName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    Insert = table.Column<bool>(type: "bit", nullable: false),
                    Update = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Print = table.Column<bool>(type: "bit", nullable: false),
                    Export = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole1 = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole1Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SpecialRole2 = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole2Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SpecialRole3 = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole3Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SpecialRole4 = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole4Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SpecialRole5 = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole5Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleTypes", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Sp_GetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleTypeId = table.Column<int>(type: "int", nullable: false),
            //        RoleTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        RoleTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        RoleDefinitionId = table.Column<int>(type: "int", nullable: false),
            //        FormName = table.Column<int>(type: "int", nullable: false),
            //        FormSubName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Show = table.Column<bool>(type: "bit", nullable: false),
            //        Insert = table.Column<bool>(type: "bit", nullable: false),
            //        Update = table.Column<bool>(type: "bit", nullable: false),
            //        Delete = table.Column<bool>(type: "bit", nullable: false),
            //        Print = table.Column<bool>(type: "bit", nullable: false),
            //        Export = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialRole1 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialRole1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialRole2 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialRole2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialRole3 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialRole3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialRole4 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialRole4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialRole5 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialRole5Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Sp_GetRoles", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleTypeId = table.Column<int>(type: "int", nullable: false),
                    FormName = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    FormSubName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    Insert = table.Column<bool>(type: "bit", nullable: false),
                    Update = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Print = table.Column<bool>(type: "bit", nullable: false),
                    Export = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole1 = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole1Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SpecialRole2 = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole2Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SpecialRole3 = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole3Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SpecialRole4 = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole4Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SpecialRole5 = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRole5Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_RoleTypes_RoleTypeId",
                        column: x => x.RoleTypeId,
                        principalTable: "RoleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleTypeId",
                table: "Users",
                column: "RoleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleTypeId",
                table: "Roles",
                column: "RoleTypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Users_RoleTypes_RoleTypeId",
            //    table: "Users",
            //    column: "RoleTypeId",
            //    principalTable: "RoleTypes",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_RoleTypes_RoleTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RoleDefinitions");

            migrationBuilder.DropTable(
                name: "Roles");

            //migrationBuilder.DropTable(
            //    name: "Sp_GetRoles");

            migrationBuilder.DropTable(
                name: "RoleTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleTypeId",
                table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "IsCertificateDelivered",
            //    table: "Sp_GetListOfDriverInformationByOfficeIds");

            migrationBuilder.RenameColumn(
                name: "RoleTypeId",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.AddColumn<int>(
                name: "AuthorizationTypeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AuthorizationDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Export = table.Column<bool>(type: "bit", nullable: false),
                    FormName = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    FormSubName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Insert = table.Column<bool>(type: "bit", nullable: false),
                    Print = table.Column<bool>(type: "bit", nullable: false),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    SpecialAuthorization1 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization2 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization3 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization4 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization5 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization5Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Update = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationTypes", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Sp_GetAuthorizations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AuthorizationDefinitionId = table.Column<int>(type: "int", nullable: false),
            //        AuthorizationTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        AuthorizationTypeId = table.Column<int>(type: "int", nullable: false),
            //        AuthorizationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Delete = table.Column<bool>(type: "bit", nullable: false),
            //        Export = table.Column<bool>(type: "bit", nullable: false),
            //        FormName = table.Column<int>(type: "int", nullable: false),
            //        FormSubName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Insert = table.Column<bool>(type: "bit", nullable: false),
            //        Print = table.Column<bool>(type: "bit", nullable: false),
            //        Show = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization1 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialAuthorization2 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialAuthorization3 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialAuthorization4 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialAuthorization5 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization5Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Update = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Sp_GetAuthorizations", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Authorizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorizationTypeId = table.Column<int>(type: "int", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Export = table.Column<bool>(type: "bit", nullable: false),
                    FormName = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    FormSubName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Insert = table.Column<bool>(type: "bit", nullable: false),
                    Print = table.Column<bool>(type: "bit", nullable: false),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    SpecialAuthorization1 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization2 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization3 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization4 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization5 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization5Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Update = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authorizations_AuthorizationTypes_AuthorizationTypeId",
                        column: x => x.AuthorizationTypeId,
                        principalTable: "AuthorizationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthorizationTypeId",
                table: "Users",
                column: "AuthorizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_AuthorizationTypeId",
                table: "Authorizations",
                column: "AuthorizationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AuthorizationTypes_AuthorizationTypeId",
                table: "Users",
                column: "AuthorizationTypeId",
                principalTable: "AuthorizationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
