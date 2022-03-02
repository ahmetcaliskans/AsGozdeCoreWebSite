using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class collectiontabledriverinformationguncellemesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_DriverInformations_DriverInformationId",
                table: "Collections");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_DriverInformations_DriverInformationId",
                table: "Collections",
                column: "DriverInformationId",
                principalTable: "DriverInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_DriverInformations_DriverInformationId",
                table: "Collections");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_DriverInformations_DriverInformationId",
                table: "Collections",
                column: "DriverInformationId",
                principalTable: "DriverInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
