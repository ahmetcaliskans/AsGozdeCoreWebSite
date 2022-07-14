using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class collectiondefinitiontypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionDefinitionTypeId",
                table: "CollectionDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CollectionDefinitionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsSequence = table.Column<bool>(type: "bit", nullable: false),
                    IsPayBySelf = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionDefinitionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionDefinitions_CollectionDefinitionTypeId",
                table: "CollectionDefinitions",
                column: "CollectionDefinitionTypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CollectionDefinitions_CollectionDefinitionTypes_CollectionDefinitionTypeId",
            //    table: "CollectionDefinitions",
            //    column: "CollectionDefinitionTypeId",
            //    principalTable: "CollectionDefinitionTypes",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionDefinitions_CollectionDefinitionTypes_CollectionDefinitionTypeId",
                table: "CollectionDefinitions");

            migrationBuilder.DropTable(
                name: "CollectionDefinitionTypes");

            migrationBuilder.DropIndex(
                name: "IX_CollectionDefinitions_CollectionDefinitionTypeId",
                table: "CollectionDefinitions");

            migrationBuilder.DropColumn(
                name: "CollectionDefinitionTypeId",
                table: "CollectionDefinitions");
        }
    }
}
