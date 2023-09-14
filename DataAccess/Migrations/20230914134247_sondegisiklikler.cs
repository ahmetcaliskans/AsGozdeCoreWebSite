using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class sondegisiklikler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ReportLayouts",
            //    columns: table => new
            //    {
            //        ReportId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DisplayName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        LayoutData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ReportLayouts", x => x.ReportId);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ReportLayouts");
        }
    }
}
