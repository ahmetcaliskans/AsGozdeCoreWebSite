using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class personneldefinitiontablenamechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_PersonelDefinitions_PersonelDefinitionId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "PersonelDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PersonelDefinitionId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "PersonnelDefinitionId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonnelDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdentityNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    County = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelDefinitions_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PersonnelDefinitionId",
                table: "Expenses",
                column: "PersonnelDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelDefinitions_OfficeId",
                table: "PersonnelDefinitions",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_PersonnelDefinitions_PersonnelDefinitionId",
                table: "Expenses",
                column: "PersonnelDefinitionId",
                principalTable: "PersonnelDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_PersonnelDefinitions_PersonnelDefinitionId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "PersonnelDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PersonnelDefinitionId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PersonnelDefinitionId",
                table: "Expenses");

            migrationBuilder.CreateTable(
                name: "PersonelDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    County = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdentityNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    Phone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelDefinitions_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PersonelDefinitionId",
                table: "Expenses",
                column: "PersonelDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelDefinitions_OfficeId",
                table: "PersonelDefinitions",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_PersonelDefinitions_PersonelDefinitionId",
                table: "Expenses",
                column: "PersonelDefinitionId",
                principalTable: "PersonelDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
