using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorsClient.Migrations
{
    public partial class deleteidsymptom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "outpatient_cardid",
                table: "Symptoms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<int>>(
                name: "outpatient_cardid",
                table: "Symptoms",
                type: "integer[]",
                nullable: true);
        }
    }
}
