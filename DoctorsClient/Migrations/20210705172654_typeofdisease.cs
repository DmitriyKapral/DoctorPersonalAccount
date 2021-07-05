using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DoctorsClient.Migrations
{
    public partial class typeofdisease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "typeofdiseaseid",
                table: "Outpatient_cards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeOfDiseases",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfDiseases", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Outpatient_cards_typeofdiseaseid",
                table: "Outpatient_cards",
                column: "typeofdiseaseid");

            migrationBuilder.AddForeignKey(
                name: "FK_Outpatient_cards_TypeOfDiseases_typeofdiseaseid",
                table: "Outpatient_cards",
                column: "typeofdiseaseid",
                principalTable: "TypeOfDiseases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outpatient_cards_TypeOfDiseases_typeofdiseaseid",
                table: "Outpatient_cards");

            migrationBuilder.DropTable(
                name: "TypeOfDiseases");

            migrationBuilder.DropIndex(
                name: "IX_Outpatient_cards_typeofdiseaseid",
                table: "Outpatient_cards");

            migrationBuilder.DropColumn(
                name: "typeofdiseaseid",
                table: "Outpatient_cards");
        }
    }
}
