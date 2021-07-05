using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorsClient.Migrations
{
    public partial class testmore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Accounts_accountid",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_accountid",
                table: "Test");

            migrationBuilder.AddColumn<List<int>>(
                name: "testid",
                table: "Accounts",
                type: "integer[]",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountTest",
                columns: table => new
                {
                    Accountid = table.Column<int>(type: "integer", nullable: false),
                    Testid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTest", x => new { x.Accountid, x.Testid });
                    table.ForeignKey(
                        name: "FK_AccountTest_Accounts_Accountid",
                        column: x => x.Accountid,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTest_Test_Testid",
                        column: x => x.Testid,
                        principalTable: "Test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTest_Testid",
                table: "AccountTest",
                column: "Testid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTest");

            migrationBuilder.DropColumn(
                name: "testid",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Test_accountid",
                table: "Test",
                column: "accountid");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Accounts_accountid",
                table: "Test",
                column: "accountid",
                principalTable: "Accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
