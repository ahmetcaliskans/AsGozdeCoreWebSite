using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class sp_getpayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Sp_GetPayments",
            //    columns: table => new
            //    {
            //        OfficeId = table.Column<int>(type: "int", nullable: false),
            //        OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SessionId = table.Column<int>(type: "int", nullable: false),
            //        SessionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SessionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SessionYear = table.Column<int>(type: "int", nullable: false),
            //        BranchId = table.Column<int>(type: "int", nullable: false),
            //        BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        DriverInformationId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CourseFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        DriverPaymentPlanId = table.Column<int>(type: "int", nullable: false),
            //        PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        TotalCourseCollectionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        TotalDebitByPaymentDate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        DebitinMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        LastDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Sp_GetPayments");
        }
    }
}
