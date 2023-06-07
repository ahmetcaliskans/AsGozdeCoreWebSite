using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class storedproceureguncellemesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "RoleDefinitionId",
            //    table: "Sp_GetRoles");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ExpenseDate",
            //    table: "Sp_rCashReport1DetailExpenses",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CollectionDate",
            //    table: "Sp_rCashReport1DetailCollections",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Sp_GetRoles",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "PaymentDate",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "PaymentDateMonthName",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "PaymentDateYear",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "PaymentDateMonthName",
            //    table: "Sp_GetListOfDueCoursePayments");

            //migrationBuilder.DropColumn(
            //    name: "PaymentDateYear",
            //    table: "Sp_GetListOfDueCoursePayments");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ExpenseDate",
            //    table: "Sp_rCashReport1DetailExpenses",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

            //migrationBuilder.AlterColumn<string>(
            //    name: "CollectionDate",
            //    table: "Sp_rCashReport1DetailCollections",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Sp_GetRoles",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "RoleDefinitionId",
            //    table: "Sp_GetRoles",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AlterColumn<string>(
            //    name: "PaymentDate",
            //    table: "Sp_GetListOfDueCoursePayments",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");
        }
    }
}
