using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Branches_BranchId",
                table: "DriverInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Sessions_SessionId",
                table: "DriverInformations");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_Branches_BranchId",
                table: "DriverInformations",
                column: "BranchId",
                principalTable: "Branches",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Branches_BranchId",
                table: "DriverInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Sessions_SessionId",
                table: "DriverInformations");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverInformations_Branches_BranchId",
                table: "DriverInformations",
                column: "BranchId",
                principalTable: "Branches",
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
    }
}
