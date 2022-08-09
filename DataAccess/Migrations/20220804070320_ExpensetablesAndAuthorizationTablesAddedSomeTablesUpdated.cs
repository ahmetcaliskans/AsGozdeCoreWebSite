using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ExpensetablesAndAuthorizationTablesAddedSomeTablesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorizationTypeId",
                table: "Users",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CertificateDeliveredDate",
                table: "DriverInformations",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCertificateDelivered",
                table: "DriverInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AuthorizationDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    FormSubName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    Insert = table.Column<bool>(type: "bit", nullable: false),
                    Update = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Print = table.Column<bool>(type: "bit", nullable: false),
                    Export = table.Column<bool>(type: "bit", nullable: false),
                    SpecialAuthorization1 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization2 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization3 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization4 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization5 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization5Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsVehicleCanBeSelected = table.Column<bool>(type: "bit", nullable: false),
                    IsVehicleSelectionRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsPersonelCanBeSelected = table.Column<bool>(type: "bit", nullable: false),
                    IsPersonelSelectionRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FixtureDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Age = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixtureDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonelDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdentityNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    County = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelDefinitions_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateTable(
            //    name: "Sp_GetAuthorizations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AuthorizationTypeId = table.Column<int>(type: "int", nullable: false),
            //        AuthorizationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        AuthorizationTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        AuthorizationDefinitionId = table.Column<int>(type: "int", nullable: false),
            //        FormName = table.Column<int>(type: "int", nullable: false),
            //        FormSubName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Show = table.Column<bool>(type: "bit", nullable: false),
            //        Insert = table.Column<bool>(type: "bit", nullable: false),
            //        Update = table.Column<bool>(type: "bit", nullable: false),
            //        Delete = table.Column<bool>(type: "bit", nullable: false),
            //        Print = table.Column<bool>(type: "bit", nullable: false),
            //        Export = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization1 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialAuthorization2 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialAuthorization3 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialAuthorization4 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SpecialAuthorization5 = table.Column<bool>(type: "bit", nullable: false),
            //        SpecialAuthorization5Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Sp_GetAuthorizations", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Sp_rCashReport1DetailCollections",
            //    columns: table => new
            //    {
            //        DriverInformationId = table.Column<int>(type: "int", nullable: false),
            //        NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IdentityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SessionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PaymentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CollectionDefinitionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CollectionDefinitionSequence = table.Column<int>(type: "int", nullable: false),
            //        CollectionDefinitionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Hour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CollectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CollectionId = table.Column<int>(type: "int", nullable: false),
            //        CollectionDetailId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Sp_rCashReport1s",
            //    columns: table => new
            //    {
            //        PaymentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        TotalCollectionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        TotalExpenseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        TotalBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //    });

            migrationBuilder.CreateTable(
                name: "Authorizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorizationTypeId = table.Column<int>(type: "int", nullable: false),
                    FormName = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    FormSubName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    Insert = table.Column<bool>(type: "bit", nullable: false),
                    Update = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Print = table.Column<bool>(type: "bit", nullable: false),
                    Export = table.Column<bool>(type: "bit", nullable: false),
                    SpecialAuthorization1 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization2 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization3 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization4 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAuthorization5 = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    SpecialAuthorization5Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authorizations_AuthorizationTypes_AuthorizationTypeId",
                        column: x => x.AuthorizationTypeId,
                        principalTable: "AuthorizationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    DocumentNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    ExpenseDefinitionId = table.Column<int>(type: "int", nullable: false),
                    FixtureDefinitionId = table.Column<int>(type: "int", nullable: false),
                    PersonelDefinitionId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AddedUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AddedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseDefinitions_ExpenseDefinitionId",
                        column: x => x.ExpenseDefinitionId,
                        principalTable: "ExpenseDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_FixtureDefinitions_FixtureDefinitionId",
                        column: x => x.FixtureDefinitionId,
                        principalTable: "FixtureDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_PersonelDefinitions_PersonelDefinitionId",
                        column: x => x.PersonelDefinitionId,
                        principalTable: "PersonelDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthorizationTypeId",
                table: "Users",
                column: "AuthorizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_AuthorizationTypeId",
                table: "Authorizations",
                column: "AuthorizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseDefinitionId",
                table: "Expenses",
                column: "ExpenseDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_FixtureDefinitionId",
                table: "Expenses",
                column: "FixtureDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_OfficeId",
                table: "Expenses",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PaymentTypeId",
                table: "Expenses",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PersonelDefinitionId",
                table: "Expenses",
                column: "PersonelDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelDefinitions_OfficeId",
                table: "PersonelDefinitions",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AuthorizationTypes_AuthorizationTypeId",
                table: "Users",
                column: "AuthorizationTypeId",
                principalTable: "AuthorizationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AuthorizationTypes_AuthorizationTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AuthorizationDefinitions");

            migrationBuilder.DropTable(
                name: "Authorizations");

            migrationBuilder.DropTable(
                name: "Expenses");

            //migrationBuilder.DropTable(
            //    name: "Sp_GetAuthorizations");

            //migrationBuilder.DropTable(
            //    name: "Sp_rCashReport1DetailCollections");

            //migrationBuilder.DropTable(
            //    name: "Sp_rCashReport1s");

            migrationBuilder.DropTable(
                name: "AuthorizationTypes");

            migrationBuilder.DropTable(
                name: "ExpenseDefinitions");

            migrationBuilder.DropTable(
                name: "FixtureDefinitions");

            migrationBuilder.DropTable(
                name: "PersonelDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_Users_AuthorizationTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthorizationTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CertificateDeliveredDate",
                table: "DriverInformations");

            migrationBuilder.DropColumn(
                name: "IsCertificateDelivered",
                table: "DriverInformations");
        }
    }
}
