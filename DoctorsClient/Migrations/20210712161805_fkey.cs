using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorsClient.Migrations
{
    public partial class fkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idpatient",
                table: "Appointments",
                newName: "patientid");

            migrationBuilder.RenameColumn(
                name: "iddoctor",
                table: "Appointments",
                newName: "doctorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "patientid",
                table: "Appointments",
                newName: "idpatient");

            migrationBuilder.RenameColumn(
                name: "doctorid",
                table: "Appointments",
                newName: "iddoctor");
        }
    }
}
