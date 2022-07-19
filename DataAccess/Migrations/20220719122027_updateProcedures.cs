using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class updateProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "BranchId",
            //    table: "Sp_GetListOfDueCoursePayments");

            //migrationBuilder.DropColumn(
            //    name: "LastDebit",
            //    table: "Sp_GetListOfDueCoursePayments");

            //migrationBuilder.DropColumn(
            //    name: "TotalCourseCollectionAmount",
            //    table: "Sp_GetListOfDueCoursePayments");

            //migrationBuilder.RenameColumn(
            //    name: "TotalDebitByPaymentDate",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "CourseFeePlus");

            //migrationBuilder.RenameColumn(
            //    name: "Surname",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "Phone1");

            //migrationBuilder.RenameColumn(
            //    name: "SessionId",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "SessionSequence");

            //migrationBuilder.RenameColumn(
            //    name: "SessionDescription",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "NameSurname");

            //migrationBuilder.RenameColumn(
            //    name: "OfficeId",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "DriverPaymentPlanSequence");

            //migrationBuilder.RenameColumn(
            //    name: "Name",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "IdentityNo");

            //migrationBuilder.AlterColumn<string>(
            //    name: "PaymentDate",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

            //migrationBuilder.AddColumn<string>(
            //    name: "CollectionDefinitionTypeName",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Sp_GetListOfCollectionByOfficeIds",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CollectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        DriverInformationId = table.Column<int>(type: "int", nullable: false),
            //        NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IdentityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SessionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SessionYear = table.Column<int>(type: "int", nullable: false),
            //        SessionSequence = table.Column<int>(type: "int", nullable: false),
            //        TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Sp_GetListOfCollectionByOfficeIds");

            //migrationBuilder.DropColumn(
            //    name: "CollectionDefinitionTypeName",
            //    table: "Sp_GetListOfDueCoursePayments");

            //migrationBuilder.RenameColumn(
            //    name: "SessionSequence",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "SessionId");

            //migrationBuilder.RenameColumn(
            //    name: "Phone1",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "Surname");

            //migrationBuilder.RenameColumn(
            //    name: "NameSurname",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "SessionDescription");

            //migrationBuilder.RenameColumn(
            //    name: "IdentityNo",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "Name");

            //migrationBuilder.RenameColumn(
            //    name: "DriverPaymentPlanSequence",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "OfficeId");

            //migrationBuilder.RenameColumn(
            //    name: "CourseFeePlus",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    newName: "TotalDebitByPaymentDate");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "PaymentDate",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "BranchId",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<decimal>(
            //    name: "LastDebit",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    defaultValue: 0m);

            //migrationBuilder.AddColumn<decimal>(
            //    name: "TotalCourseCollectionAmount",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    defaultValue: 0m);
        }
    }
}
