using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class sp_GetSequentialPaymentAddColumnHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<decimal>(
            //    name: "Hour",
            //    table: "Sp_GetSequentialPayments",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Hour",
            //    table: "Sp_GetSequentialPayments");
        }
    }
}
