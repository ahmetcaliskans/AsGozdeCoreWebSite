using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class sp_GetSequentialPaymentAddColumnCollectionDetailPaidBySelf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<bool>(
            //    name: "CollectionDetailPaidBySelf",
            //    table: "Sp_GetSequentialPayments",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "CollectionDetailPaidBySelf",
            //    table: "Sp_GetSequentialPayments");
        }
    }
}
