using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class collectionduzenlendicollectiondetaileklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CollectionDefinitions_CollectionDefinitionId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_PaymentTypes_PaymentTypeId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_CollectionDefinitionId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_PaymentTypeId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CollectionDefinitionId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Collections");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Collections",
                newName: "TotalAmount");

            migrationBuilder.CreateTable(
                name: "CollectionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    CollectionDefinitionId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AddedUserId = table.Column<int>(type: "int", nullable: false),
                    AddedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionDetails_CollectionDefinitions_CollectionDefinitionId",
                        column: x => x.CollectionDefinitionId,
                        principalTable: "CollectionDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CollectionDetails_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionDetails_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionDetails_CollectionDefinitionId",
                table: "CollectionDetails",
                column: "CollectionDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionDetails_CollectionId",
                table: "CollectionDetails",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionDetails_PaymentTypeId",
                table: "CollectionDetails",
                column: "PaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionDetails");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Collections",
                newName: "Amount");

            migrationBuilder.AddColumn<int>(
                name: "CollectionDefinitionId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CollectionDefinitionId",
                table: "Collections",
                column: "CollectionDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_PaymentTypeId",
                table: "Collections",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CollectionDefinitions_CollectionDefinitionId",
                table: "Collections",
                column: "CollectionDefinitionId",
                principalTable: "CollectionDefinitions",
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
    }
}
