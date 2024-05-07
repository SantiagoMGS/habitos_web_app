using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace habitos_web_app.Migrations
{
    public partial class RenombrarIdMedications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Medication",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Medication",
                newName: "ID");
        }
    }
}
