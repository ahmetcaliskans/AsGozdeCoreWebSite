using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class collectiondefinitionamountguncellemesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedUserId",
                table: "Collections");

            migrationBuilder.RenameColumn(
                name: "UpdatedDatetime",
                table: "DriverPaymentPlans",
                newName: "UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "AddedDatetime",
                table: "DriverPaymentPlans",
                newName: "AddedDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDateTime",
                table: "CollectionDefinitionAmounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AddedUserName",
                table: "CollectionDefinitionAmounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "CollectionDefinitionAmounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUserName",
                table: "CollectionDefinitionAmounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDateTime",
                table: "CollectionDefinitionAmounts");

            migrationBuilder.DropColumn(
                name: "AddedUserName",
                table: "CollectionDefinitionAmounts");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "CollectionDefinitionAmounts");

            migrationBuilder.DropColumn(
                name: "UpdatedUserName",
                table: "CollectionDefinitionAmounts");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "DriverPaymentPlans",
                newName: "UpdatedDatetime");

            migrationBuilder.RenameColumn(
                name: "AddedDateTime",
                table: "DriverPaymentPlans",
                newName: "AddedDatetime");

            migrationBuilder.AddColumn<int>(
                name: "AddedUserId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
