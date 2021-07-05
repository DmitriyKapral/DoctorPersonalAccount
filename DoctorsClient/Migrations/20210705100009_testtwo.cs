using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorsClient.Migrations
{
    public partial class testtwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Testtwo_testtwoid",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_testtwoid",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "accountid",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "testtwoid",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "testid",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "accountid",
                table: "Test",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "testtwoid",
                table: "Test",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<List<int>>(
                name: "testid",
                table: "Accounts",
                type: "integer[]",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Test_testtwoid",
                table: "Test",
                column: "testtwoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Testtwo_testtwoid",
                table: "Test",
                column: "testtwoid",
                principalTable: "Testtwo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
