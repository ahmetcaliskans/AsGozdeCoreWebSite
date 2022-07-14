using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CollectionDetailUpdateAdedNoteHourPaidBySelfColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Hour",
                table: "CollectionDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "CollectionDetails",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PaidBySelf",
                table: "CollectionDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "CollectionDetails");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "CollectionDetails");

            migrationBuilder.DropColumn(
                name: "PaidBySelf",
                table: "CollectionDetails");
        }
    }
}
