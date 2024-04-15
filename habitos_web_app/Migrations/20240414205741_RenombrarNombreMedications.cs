using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace habitos_web_app.Migrations
{
    public partial class RenombrarNombreMedications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Medication",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Medication",
                newName: "Nombre");
        }
    }
}
