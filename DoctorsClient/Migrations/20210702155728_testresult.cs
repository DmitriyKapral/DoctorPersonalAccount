using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DoctorsClient.Migrations
{
    public partial class testresult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "position",
                table: "Doctors");

            migrationBuilder.AddColumn<List<int>>(
                name: "test_resultid",
                table: "Outpatient_cards",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "positionid",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Test_Results",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    urlresult = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<string>(type: "text", nullable: true),
                    outpatient_cardid = table.Column<List<int>>(type: "integer[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test_Results", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Outpatient_cardTest_result",
                columns: table => new
                {
                    Outpatient_Cardid = table.Column<int>(type: "integer", nullable: false),
                    Test_Resultid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outpatient_cardTest_result", x => new { x.Outpatient_Cardid, x.Test_Resultid });
                    table.ForeignKey(
                        name: "FK_Outpatient_cardTest_result_Outpatient_cards_Outpatient_Card~",
                        column: x => x.Outpatient_Cardid,
                        principalTable: "Outpatient_cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outpatient_cardTest_result_Test_Results_Test_Resultid",
                        column: x => x.Test_Resultid,
                        principalTable: "Test_Results",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_positionid",
                table: "Doctors",
                column: "positionid");

            migrationBuilder.CreateIndex(
                name: "IX_Outpatient_cardTest_result_Test_Resultid",
                table: "Outpatient_cardTest_result",
                column: "Test_Resultid");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Positions_positionid",
                table: "Doctors",
                column: "positionid",
                principalTable: "Positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Positions_positionid",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Outpatient_cardTest_result");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Test_Results");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_positionid",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "test_resultid",
                table: "Outpatient_cards");

            migrationBuilder.DropColumn(
                name: "positionid",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "position",
                table: "Doctors",
                type: "text",
                nullable: true);
        }
    }
}
