using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class nullableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<int>(
            //    name: "PaymentTypeId",
            //    table: "Sp_GetSequentialPayments",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<int>(
            //    name: "DriverInformationId",
            //    table: "Sp_GetSequentialPayments",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<int>(
            //    name: "CollectionId",
            //    table: "Sp_GetSequentialPayments",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<int>(
            //    name: "CollectionDetailId",
            //    table: "Sp_GetSequentialPayments",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "CollectionDetailAmount",
            //    table: "Sp_GetSequentialPayments",
            //    type: "decimal(18,2)",
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(18,2)");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CollectionDate",
            //    table: "Sp_GetSequentialPayments",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<int>(
            //    name: "PaymentTypeId",
            //    table: "Sp_GetSequentialPayments",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "DriverInformationId",
            //    table: "Sp_GetSequentialPayments",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "CollectionId",
            //    table: "Sp_GetSequentialPayments",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "CollectionDetailId",
            //    table: "Sp_GetSequentialPayments",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "CollectionDetailAmount",
            //    table: "Sp_GetSequentialPayments",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    defaultValue: 0m,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(18,2)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CollectionDate",
            //    table: "Sp_GetSequentialPayments",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);
        }
    }
}
