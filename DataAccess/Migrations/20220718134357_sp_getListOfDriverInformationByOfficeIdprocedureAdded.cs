using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class sp_getListOfDriverInformationByOfficeIdprocedureAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_DriverInformations_DriverInformationId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Branches_BranchId",
                table: "DriverInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Offices_OfficeId",
                table: "DriverInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Sessions_SessionId",
                table: "DriverInformations");

            //migrationBuilder.CreateTable(
            //    name: "Sp_GetListOfDriverInformationByOfficeIds",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IdentityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CourseFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        CourseFeePlus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SessionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SessionYear = table.Column<int>(type: "int", nullable: false),
            //        SessionSequence = table.Column<int>(type: "int", nullable: false),
            //        BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_DriverInformations_DriverInformationId",
                table: "Collections",
                column: "DriverInformationId",
                principalTable: "DriverInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Collections_DriverInformations_DriverInformationId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Branches_BranchId",
                table: "DriverInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Offices_OfficeId",
                table: "DriverInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverInformations_Sessions_SessionId",
                table: "DriverInformations");

            //migrationBuilder.DropTable(
            //    name: "Sp_GetListOfDriverInformationByOfficeIds");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_DriverInformations_DriverInformationId",
                table: "Collections",
                column: "DriverInformationId",
                principalTable: "DriverInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
