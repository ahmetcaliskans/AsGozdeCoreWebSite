using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DriverInformationGuncellemesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Branches_BranchId",
                table: "DriverInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Offices_OfficeId",
                table: "DriverInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Sessions_SessionId",
                table: "DriverInformations");

            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "DriverInformations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OfficeId",
                table: "DriverInformations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "DriverInformations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_Branches_BranchId",
                table: "DriverInformations",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_Offices_OfficeId",
                table: "DriverInformations",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_Sessions_SessionId",
                table: "DriverInformations",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Branches_BranchId",
                table: "DriverInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Offices_OfficeId",
                table: "DriverInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Sessions_SessionId",
                table: "DriverInformations");

            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "DriverInformations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeId",
                table: "DriverInformations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "DriverInformations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_Branches_BranchId",
                table: "DriverInformations",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_Offices_OfficeId",
                table: "DriverInformations",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_Sessions_SessionId",
                table: "DriverInformations",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
