using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class spGetSequentialPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Sp_GetSequentialPayments",
            //    columns: table => new
            //    {
            //        CollectionDefinitionId = table.Column<int>(type: "int", nullable: false),
            //        CollectionDefinitionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CollectionDefinitionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CollectionDefinitionSequence = table.Column<int>(type: "int", nullable: false),
            //        CollectionDefinitionPayBySelf = table.Column<bool>(type: "bit", nullable: false),
            //        CollectionDefinitionTypeId = table.Column<int>(type: "int", nullable: false),
            //        CollectionDefinitionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CollectionDetailId = table.Column<int>(type: "int", nullable: false),
            //        PaymentTypeId = table.Column<int>(type: "int", nullable: false),
            //        CollectionId = table.Column<int>(type: "int", nullable: false),
            //        CollectionDetailAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CollectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DriverInformationId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Sp_GetSequentialPayments");
        }
    }
}
