using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class sp_getPaymentAddColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "CollectionDefinitionId",
            //    table: "Sp_GetPayments",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "CollectionDefinitionTypeId",
            //    table: "Sp_GetPayments",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "CollectionDefinitionId",
            //    table: "Sp_GetPayments");

            //migrationBuilder.DropColumn(
            //    name: "CollectionDefinitionTypeId",
            //    table: "Sp_GetPayments");
        }
    }
}
