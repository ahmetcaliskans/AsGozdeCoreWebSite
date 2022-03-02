using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class collectiontableiliskiguncellenmesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CollectionDefinitions_CollectionDefinitionId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Offices_OfficeId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_PaymentTypes_PaymentTypeId",
                table: "Collections");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CollectionDefinitions_CollectionDefinitionId",
                table: "Collections",
                column: "CollectionDefinitionId",
                principalTable: "CollectionDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Offices_OfficeId",
                table: "Collections",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_PaymentTypes_PaymentTypeId",
                table: "Collections",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CollectionDefinitions_CollectionDefinitionId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Offices_OfficeId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_PaymentTypes_PaymentTypeId",
                table: "Collections");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CollectionDefinitions_CollectionDefinitionId",
                table: "Collections",
                column: "CollectionDefinitionId",
                principalTable: "CollectionDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Offices_OfficeId",
                table: "Collections",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_PaymentTypes_PaymentTypeId",
                table: "Collections",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
