using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class collectiondefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Amount",
            //    table: "Sp_GetPayments");

            //migrationBuilder.DropColumn(
            //    name: "BranchId",
            //    table: "Sp_GetPayments");

            //migrationBuilder.DropColumn(
            //    name: "BranchName",
            //    table: "Sp_GetPayments");

            //migrationBuilder.DropColumn(
            //    name: "CourseFee",
            //    table: "Sp_GetPayments");

            //migrationBuilder.DropColumn(
            //    name: "DebitinMonth",
            //    table: "Sp_GetPayments");

            //migrationBuilder.DropColumn(
            //    name: "DriverInformationId",
            //    table: "Sp_GetPayments");

            //migrationBuilder.DropColumn(
            //    name: "LastDebit",
            //    table: "Sp_GetPayments");

            //migrationBuilder.DropColumn(
            //    name: "Name",
            //    table: "Sp_GetPayments");

            migrationBuilder.DropColumn(
                name: "IsPrivateLesson",
                table: "CollectionDefinitions");

            //migrationBuilder.RenameColumn(
            //    name: "TotalDebitByPaymentDate",
            //    table: "Sp_GetPayments",
            //    newName: "PaymentPlanAmount");

            //migrationBuilder.RenameColumn(
            //    name: "TotalCourseCollectionAmount",
            //    table: "Sp_GetPayments",
            //    newName: "Debit");

            //migrationBuilder.RenameColumn(
            //    name: "Surname",
            //    table: "Sp_GetPayments",
            //    newName: "CollectionTypeNames");

            //migrationBuilder.RenameColumn(
            //    name: "SessionYear",
            //    table: "Sp_GetPayments",
            //    newName: "DriverPaymentPlanSequence");

            //migrationBuilder.RenameColumn(
            //    name: "SessionName",
            //    table: "Sp_GetPayments",
            //    newName: "CollectionIds");

            //migrationBuilder.RenameColumn(
            //    name: "SessionId",
            //    table: "Sp_GetPayments",
            //    newName: "DriverPaymentPlanDriverInformationId");

            //migrationBuilder.RenameColumn(
            //    name: "SessionDescription",
            //    table: "Sp_GetPayments",
            //    newName: "CollectionDetailIds");

            //migrationBuilder.RenameColumn(
            //    name: "OfficeName",
            //    table: "Sp_GetPayments",
            //    newName: "CollectionDates");

            //migrationBuilder.RenameColumn(
            //    name: "OfficeId",
            //    table: "Sp_GetPayments",
            //    newName: "ClosingCollectionCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "PaymentPlanAmount",
            //    table: "Sp_GetPayments",
            //    newName: "TotalDebitByPaymentDate");

            //migrationBuilder.RenameColumn(
            //    name: "DriverPaymentPlanSequence",
            //    table: "Sp_GetPayments",
            //    newName: "SessionYear");

            //migrationBuilder.RenameColumn(
            //    name: "DriverPaymentPlanDriverInformationId",
            //    table: "Sp_GetPayments",
            //    newName: "SessionId");

            //migrationBuilder.RenameColumn(
            //    name: "Debit",
            //    table: "Sp_GetPayments",
            //    newName: "TotalCourseCollectionAmount");

            //migrationBuilder.RenameColumn(
            //    name: "CollectionTypeNames",
            //    table: "Sp_GetPayments",
            //    newName: "Surname");

            //migrationBuilder.RenameColumn(
            //    name: "CollectionIds",
            //    table: "Sp_GetPayments",
            //    newName: "SessionName");

            //migrationBuilder.RenameColumn(
            //    name: "CollectionDetailIds",
            //    table: "Sp_GetPayments",
            //    newName: "SessionDescription");

            //migrationBuilder.RenameColumn(
            //    name: "CollectionDates",
            //    table: "Sp_GetPayments",
            //    newName: "OfficeName");

            //migrationBuilder.RenameColumn(
            //    name: "ClosingCollectionCount",
            //    table: "Sp_GetPayments",
            //    newName: "OfficeId");

            //migrationBuilder.AddColumn<decimal>(
            //    name: "Amount",
            //    table: "Sp_GetPayments",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    defaultValue: 0m);

            //migrationBuilder.AddColumn<int>(
            //    name: "BranchId",
            //    table: "Sp_GetPayments",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "BranchName",
            //    table: "Sp_GetPayments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<decimal>(
            //    name: "CourseFee",
            //    table: "Sp_GetPayments",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    defaultValue: 0m);

            //migrationBuilder.AddColumn<decimal>(
            //    name: "DebitinMonth",
            //    table: "Sp_GetPayments",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    defaultValue: 0m);

            //migrationBuilder.AddColumn<int>(
            //    name: "DriverInformationId",
            //    table: "Sp_GetPayments",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<decimal>(
            //    name: "LastDebit",
            //    table: "Sp_GetPayments",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    defaultValue: 0m);

            //migrationBuilder.AddColumn<string>(
            //    name: "Name",
            //    table: "Sp_GetPayments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivateLesson",
                table: "CollectionDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
